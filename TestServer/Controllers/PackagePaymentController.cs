using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Services.VNPAY;
using TestServer.Models;
using TestServer.Models.VNPAY;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Linq;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagePaymentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IVnPayService _vnPayService;

        public PackagePaymentController(AppDbContext context, IVnPayService vnPayService)
        {
            _db = context;
            _vnPayService = vnPayService;
        }

        public class UnityPackagePaymentRequest
        {
            public string UserId { get; set; } = string.Empty;
            public int PackageId { get; set; }
            public int DiscountPercent { get; set; }
            public int ReservationTime { get; set; }
            public float Amount { get; set; }
        }

        public class UnityPackagePaymentResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public double Amount { get; set; }
            public string? PaymentUrl { get; set; }
        }

        [HttpPost("unity")]
        public async Task<IActionResult> PayFromUnity([FromBody] UnityPackagePaymentRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId) || request.PackageId <= 0)
                return BadRequest(
                    new UnityPackagePaymentResponse
                    {
                        Success = false,
                        Message = "Invalid request.",
                    }
                );

            var customer = _db.Customers
                .Where(c => c.Id == request.UserId)
                .Select(c => c.Id)
                .FirstOrDefault();

            if (customer == null)
                return NotFound(
                    new UnityPackagePaymentResponse
                    {
                        Success = false,
                        Message = $"Customer id {request.UserId} not found.",
                    }
                );

            var paymentModel = new PaymentInformationModel
            {
                Amount = request.Amount,
                Name = customer,
                OrderDescription = $"Payment for PackageId {request.PackageId} - UserId {request.UserId} - Discount {request.DiscountPercent} - Reservation {request.ReservationTime}",
            };

            var url = _vnPayService.CreatePaymentUrl(paymentModel, HttpContext);

            var resp = new UnityPackagePaymentResponse
            {
                Success = true,
                Message = "Redirect to payment gateway",
                Amount = paymentModel.Amount,
                PaymentUrl = url,
            };

            return Ok(resp);
        }

        // Callback endpoint for VNPAY to notify package payment result
        [HttpGet("callback-vnpay")]
        [HttpGet("/PackagePayment/PaymentCallbackVnpay")]
        public async Task<IActionResult> PackagePaymentCallback()
        {
            PaymentResponseModel response = new PaymentResponseModel();

            try
            {
                var exec = _vnPayService.PaymentExecute(Request.Query);
                if (exec != null)
                    response = exec;
            }
            catch
            {
                response = new PaymentResponseModel { Success = false };
            }

            var q = Request.Query;
            string vnpResponseCode = q["vnp_ResponseCode"].FirstOrDefault() ?? "";
            string vnpOrderInfo = q["vnp_OrderInfo"].FirstOrDefault() ?? "";
            string vnpAmountRaw = q["vnp_Amount"].FirstOrDefault() ?? "0";

            string userId = string.Empty;
            int packageId = 0;
            int discount = 0;
            int reservation = 0;

            // expected OrderDescription: "Payment for PackageId {id} - UserId {uid} - Discount {d} - Reservation {r}"
            var mPkg = Regex.Match(vnpOrderInfo, @"PackageId\s*(\d+)", RegexOptions.IgnoreCase);
            var mUser = Regex.Match(vnpOrderInfo, @"UserId\s*(\S+)", RegexOptions.IgnoreCase);
            var mDisc = Regex.Match(vnpOrderInfo, @"Discount\s*(\d+)", RegexOptions.IgnoreCase);
            var mRes = Regex.Match(vnpOrderInfo, @"Reservation\s*(\d+)", RegexOptions.IgnoreCase);

            if (mPkg.Success) int.TryParse(mPkg.Groups[1].Value, out packageId);
            if (mUser.Success) userId = mUser.Groups[1].Value;
            if (mDisc.Success) int.TryParse(mDisc.Groups[1].Value, out discount);
            if (mRes.Success) int.TryParse(mRes.Groups[1].Value, out reservation);

            double paidAmount = 0;

            if (vnpResponseCode == "00")
            {
                try
                {
                    if (int.TryParse(vnpAmountRaw, out var amtInt))
                        paidAmount = amtInt / 100.0;

                    // create subscription
                    var now = DateTime.UtcNow;
                    var sub = new PackageSubscription
                    {
                        UserId = userId,
                        PackageId = packageId,
                        PriceAtPurchase = (decimal)paidAmount,
                        DiscountPercentAtPurchase = discount,
                        ReservationMinutesAtPurchase = reservation,
                        StartDate = now,
                        EndDate = now.AddMonths(1),
                    };

                    await _db.PackageSubscriptions.AddAsync(sub);

                    await _db.SaveChangesAsync();

                    // record package payment transaction
                    var pkgTx = new PackagePaymentTransaction
                    {
                        PackageSubscriptionId = sub.Id,
                        CustomerId = userId ?? string.Empty,
                        ResponseCode = vnpResponseCode,
                        TransactionStatus = q["vnp_TransactionStatus"].FirstOrDefault() ?? string.Empty,
                        OrderInfo = vnpOrderInfo,
                        Amount = paidAmount,
                        CreatedAt = DateTime.UtcNow,
                    };

                    await _db.PackagePaymentTransactions.AddAsync(pkgTx);
                    await _db.SaveChangesAsync();

                    response.Success = true;
                }
                catch
                {
                    response.Success = false;
                }
            }

            // if not success, still log a package payment attempt (no subscription id)
            else
            {
                var pkgTx = new PackagePaymentTransaction
                {
                    PackageSubscriptionId = 0,
                    CustomerId = userId ?? string.Empty,
                    ResponseCode = vnpResponseCode,
                    TransactionStatus = q["vnp_TransactionStatus"].FirstOrDefault() ?? string.Empty,
                    OrderInfo = vnpOrderInfo,
                    Amount = 0,
                    CreatedAt = DateTime.UtcNow,
                };
                await _db.PackagePaymentTransactions.AddAsync(pkgTx);
                await _db.SaveChangesAsync();
            }

            // For web compatibility return the same PaymentResult view used by PaymentController
            return View("PaymentResult", response);
        }

        // GET api/packagepayment/status/subscription/{subscriptionId}
        [HttpGet("status/{uid}")]
        public async Task<IActionResult> GetPackagePaymentStatus(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return BadRequest(new { Success = false, Message = "Invalid subscriptionId." });

            var sub = await _db.PackageSubscriptions.FirstOrDefaultAsync(p => p.UserId == uid);
            if (sub == null)
                return NotFound(new { Success = false, Message = "Subscription not found." });

            var lastTx = await _db.PackagePaymentTransactions
                .Where(t => t.PackageSubscriptionId == sub.Id)
                .OrderByDescending(t => t.CreatedAt)
                .FirstOrDefaultAsync();

            string status = "Pending";
            if (lastTx != null)
            {
                if (lastTx.ResponseCode == "00" || lastTx.TransactionStatus == "00")
                    status = "Success";
                else if (lastTx.ResponseCode == "24")
                    status = "Cancelled";
                else
                    status = "Failed";
            }

            if (status == "Cancelled" || status == "Failed")
            {
                return Ok(new
                {
                    Success = false,
                    SubscriptionId = sub.Id,
                    PriceAtPurchase = sub.PriceAtPurchase,
                    Paid = false,
                    LastTransaction = lastTx
                });
            }

            return Ok(new
            {
                Success = true,
                SubscriptionId = sub.Id,
                PriceAtPurchase = sub.PriceAtPurchase,
                Paid = status == "Success",
                LastTransaction = lastTx
            });
        }
    }
}