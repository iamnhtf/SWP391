using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.DTOs;
using TestServer.Models;
using TestServer.Models.VNPAY;
using TestServer.Services.VNPAY;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private static readonly Dictionary<int, string> _paymentStatusCache = new();
        private readonly IVnPayService _vnPayService;
        private readonly AppDbContext _db;

        public PaymentController(IVnPayService vnPayService, AppDbContext db)
        {
            _vnPayService = vnPayService;
            _db = db;
        }

        // Existing web flow endpoint (kept for web redirects)
        [HttpPost("create-vnpay-url")]
        public IActionResult CreatePaymentUrlVnpay([FromBody] PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
            // Trả về một đối tượng JSON chứa URL
            return Ok(new { paymentUrl = url });
        }

        // Existing callback endpoint used by VNPAY to notify result
        [HttpGet("callback-vnpay")]
        [HttpGet("/Payment/PaymentCallbackVnpay")]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
            PaymentResponseModel response = null;

            try
            {
                response = _vnPayService.PaymentExecute(Request.Query);
            }
            catch
            {
                response = new PaymentResponseModel { Success = false };
            }

            var q = Request.Query;

            string vnpResponseCode = q["vnp_ResponseCode"].FirstOrDefault() ?? "";
            string vnpTxnRef = q["vnp_TxnRef"].FirstOrDefault() ?? "";
            string vnpOrderInfo = q["vnp_OrderInfo"].FirstOrDefault() ?? "";
            string vnpAmountRaw = q["vnp_Amount"].FirstOrDefault() ?? "0";
            string vnpTxnStatus = q["vnp_TransactionStatus"].FirstOrDefault() ?? "";

            string message = "";
            string status = "Pending";

            double paidAmount = 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                vnpOrderInfo,
                @"VehicleMonth\s*(\d+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );

            int vehicleMonthId = 0;
            int.TryParse(match.Groups[1].Value, out vehicleMonthId);

            int vehicleId = 0;
            string customerId = "";

            if (vehicleMonthId > 0)
            {
                var vpmFull = await _db
                    .VehiclePerMonths.Include(v => v.Vehicle)
                    .FirstOrDefaultAsync(vpm => vpm.VehicleMonthId == vehicleMonthId);

                if (vpmFull != null)
                {
                    vehicleId = vpmFull.VehicleId;
                    customerId = vpmFull.Vehicle.CustomerId;
                }
            }

            if (vnpResponseCode == "00")
            {
                response.Success = true;
                message = "Thanh toán thành công!";
                status = "Success";

                try
                {
                    if (int.TryParse(vnpAmountRaw, out var amountInt))
                        paidAmount = amountInt / 100.0;

                    var vpm = await _db.VehiclePerMonths.FirstOrDefaultAsync(x =>
                        x.VehicleMonthId == vehicleMonthId
                    );

                    if (vpm != null)
                    {
                        vpm.AmountPaid += (float)paidAmount;
                        if (vpm.AmountPaid > vpm.TotalCost)
                            vpm.AmountPaid = vpm.TotalCost;

                        await _db.SaveChangesAsync();
                        response.OrderId = vehicleMonthId.ToString();
                    }
                }
                catch
                {
                    response.Success = false;
                    message = "Thanh toán thành công nhưng cập nhật dữ liệu thất bại.";
                }
            }
            else if (vnpResponseCode == "24")
            {
                message = "Giao dịch đã bị hủy.";
                status = "Cancelled";
            }
            else if (
                string.IsNullOrEmpty(vnpResponseCode)
                && Request.Host.Value.Contains("localhost", StringComparison.OrdinalIgnoreCase)
            )
            {
                message = "Giao dịch tạm dừng/đã bị hủy (local).";
                status = "Cancelled";
            }
            else
            {
                message = $"Thanh toán thất bại. Mã lỗi: {vnpResponseCode}";
                status = "Failed";
            }

            _db.PaymentTransactions.Add(
                new PaymentTransaction
                {
                    VehicleMonthId = vehicleMonthId,
                    VehicleId = vehicleId,
                    CustomerId = customerId,
                    ResponseCode = vnpResponseCode,
                    TransactionStatus = vnpTxnStatus,
                    OrderInfo = vnpOrderInfo,
                    Amount = paidAmount,
                    CreatedAt = DateTime.UtcNow,
                }
            );

            await _db.SaveChangesAsync();

            ViewBag.ResultMessage = message;
            _paymentStatusCache[vehicleMonthId] = status;

            return View("PaymentResult", response);
        }

        // GET api/payment/status/{vehicleMonthId}
        [HttpGet("status/{vehicleMonthId:int}")]
        public async Task<IActionResult> GetPaymentStatus(int vehicleMonthId)
        {
            if (vehicleMonthId <= 0)
                return BadRequest(new { Success = false, Message = "Invalid vehicleMonthId." });

            var vpm = await _db.VehiclePerMonths.FirstOrDefaultAsync(v =>
                v.VehicleMonthId == vehicleMonthId
            );
            if (vpm == null)
                return NotFound(new { Success = false, Message = "VehiclePerMonth not found." });

            var lastTx = await _db
                .PaymentTransactions.Where(p => p.VehicleMonthId == vehicleMonthId)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();

            string status = "Pending";

            if (lastTx != null)
            {
                if (lastTx.ResponseCode == "00" || lastTx.TransactionStatus == "00")
                {
                    status = "Success";
                }
                else if (lastTx.ResponseCode == "24")
                {
                    status = "Cancelled";
                }
                else
                {
                    status = "Failed";
                }
            }

            if (status == "Cancelled" || status == "Failed")
            {
                // if (lastTx != null)
                // {
                //     _db.PaymentTransactions.Remove(lastTx);
                //     await _db.SaveChangesAsync();
                //     Console.WriteLine(
                //         $"Deleted failed/cancelled transaction for VehicleMonthId={vehicleMonthId}"
                //     );
                // }

                return Ok(
                    new
                    {
                        Success = false,
                        VehicleMonthId = vpm.VehicleMonthId,
                        TotalCost = vpm.TotalCost,
                        AmountPaid = vpm.AmountPaid,
                        Paid = false,
                    }
                );
            }

            bool paid = vpm.AmountPaid >= vpm.TotalCost;

            // if (lastTx != null && paid)
            // {
            //     _db.PaymentTransactions.Remove(lastTx);
            //     await _db.SaveChangesAsync();
            //     Console.WriteLine(
            //         $"Deleted transaction log after status check for VehicleMonthId={vehicleMonthId}"
            //     );
            // }

            return Ok(
                new
                {
                    Success = true,
                    VehicleMonthId = vpm.VehicleMonthId,
                    TotalCost = vpm.TotalCost,
                    AmountPaid = vpm.AmountPaid,
                    Paid = paid,
                }
            );
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            // Join PaymentTransactions -> VehiclePerMonths -> Vehicles to construct DTOs
            var list = await (
                from pt in _db.PaymentTransactions
                join vpm in _db.VehiclePerMonths on pt.VehicleMonthId equals vpm.VehicleMonthId
                join v in _db.Vehicles on vpm.VehicleId equals v.VehicleId
                orderby pt.CreatedAt descending
                select new PaymentTransactionDto
                {
                    Id = pt.Id,
                    VehicleMonthId = pt.VehicleMonthId,
                    VehicleId = v.VehicleId,
                    CustomerId = v.CustomerId,
                    ResponseCode = pt.ResponseCode,
                    TransactionStatus = pt.TransactionStatus,
                    OrderInfo = pt.OrderInfo,
                    Amount = pt.Amount,
                    CreatedAt = pt.CreatedAt,
                }
            ).ToListAsync();

            return Ok(list);
        }

        [HttpGet("transactions/{customerId}")]
        public async Task<IActionResult> GetTransactionsByCustomerId(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest("Invalid customerId.");

            var userId = await _db.Customers.Where(u => u.Id == customerId).FirstOrDefaultAsync();

            if (userId == null)
                return NotFound("User not found.");
            // Join PaymentTransactions -> VehiclePerMonths -> Vehicles to construct DTOs
            var list = await (
                from pt in _db.PaymentTransactions
                join vpm in _db.VehiclePerMonths on pt.VehicleMonthId equals vpm.VehicleMonthId
                join v in _db.Vehicles on vpm.VehicleId equals v.VehicleId
                where v.CustomerId == customerId
                orderby pt.CreatedAt descending
                select new PaymentTransactionDto
                {
                    Id = pt.Id,
                    VehicleMonthId = pt.VehicleMonthId,
                    VehicleId = v.VehicleId,
                    CustomerId = v.CustomerId,
                    ResponseCode = pt.ResponseCode,
                    TransactionStatus = pt.TransactionStatus,
                    OrderInfo = pt.OrderInfo,
                    Amount = pt.Amount,
                    CreatedAt = pt.CreatedAt,
                }
            ).ToListAsync();

            return Ok(list);
        }

        // Unity-friendly endpoint
        // POST api/payment/unity
        // Body: { "vehicleMonthId": 123, "simulate": true }
        public class UnityPaymentRequest
        {
            public int VehicleMonthId { get; set; }
            public bool Simulate { get; set; } = false;
        }

        public class UnityPaymentResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public double Amount { get; set; }
            public string? PaymentUrl { get; set; }
        }

        [HttpPost("unity")]
        public async Task<IActionResult> PayFromUnity([FromBody] UnityPaymentRequest request)
        {
            if (request == null || request.VehicleMonthId <= 0)
                return BadRequest(
                    new UnityPaymentResponse
                    {
                        Success = false,
                        Message = "Invalid request or VehicleMonthId.",
                    }
                );

            var vpm = await _db
                .VehiclePerMonths.Include(v => v.Vehicle)
                .FirstOrDefaultAsync(x => x.VehicleMonthId == request.VehicleMonthId);

            if (vpm == null)
                return NotFound(
                    new UnityPaymentResponse
                    {
                        Success = false,
                        Message = $"VehiclePerMonth id {request.VehicleMonthId} not found.",
                    }
                );

            // Calculate outstanding amount
            var due = Math.Round((double)(vpm.TotalCost - vpm.AmountPaid), 2);

            if (due <= 0)
                return BadRequest(
                    new UnityPaymentResponse
                    {
                        Success = false,
                        Message = "No outstanding amount to pay.",
                        Amount = 0,
                    }
                );

            // If simulate flag set, mark as paid (for testing in Unity)
            if (request.Simulate)
            {
                vpm.AmountPaid += (float)due;
                await _db.SaveChangesAsync();

                return Ok(
                    new UnityPaymentResponse
                    {
                        Success = true,
                        Message = "Payment simulated and recorded.",
                        Amount = due,
                        PaymentUrl = null,
                    }
                );
            }

            // Otherwise, create VNPAY payment URL and return to Unity so it can open a web view
            var paymentModel = new PaymentInformationModel
            {
                Amount = due,
                Name = vpm.Vehicle?.Name ?? vpm.Vehicle?.LicensePlate ?? "VehiclePayment",
                OrderDescription =
                    $"Payment for VehicleMonth {vpm.VehicleMonthId} - VehicleId {vpm.VehicleId}",
            };

            var url = _vnPayService.CreatePaymentUrl(paymentModel, HttpContext);

            var resp = new UnityPaymentResponse
            {
                Success = true,
                Message = "Redirect to payment gateway",
                Amount = due,
                PaymentUrl = url,
            };

            return Ok(resp);
        }
    }
}
