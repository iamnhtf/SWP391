using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Models.VNPAY;
using TestServer.Services.VNPAY;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
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
            var response = _vnPayService.PaymentExecute(Request.Query);

            // Debugging: Log the response details
            Console.WriteLine("VNPAY Payment Response:" + response);

            try
            {
                var q = Request.Query;
                string vnpResponseCode = q["vnp_ResponseCode"].ToString();
                string vnpTxnRef = q["vnp_TxnRef"].ToString();
                string vnpAmountRaw = q["vnp_Amount"].ToString();
                string vnpOrderInfo = q["vnp_OrderInfo"].ToString();
                string vnpTxnStatus = q["vnp_TransactionStatus"].ToString();

                double paidAmount = 0;
                if (int.TryParse(vnpAmountRaw, out var amountInt))
                {
                    paidAmount = amountInt / 100.0;
                }

                // Extract VehicleMonthId from order info (created earlier)
                var match = System.Text.RegularExpressions.Regex.Match(
                    vnpOrderInfo ?? string.Empty,
                    @"VehicleMonth\s*(\d+)",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase
                );
                if (match.Success && int.TryParse(match.Groups[1].Value, out var vehicleMonthId))
                {
                    var vpm = await _db.VehiclePerMonths.FirstOrDefaultAsync(x =>
                        x.VehicleMonthId == vehicleMonthId
                    );
                    if (vpm != null)
                    {
                        var success =
                            string.Equals(vnpResponseCode, "00")
                            || string.Equals(vnpTxnStatus, "00");
                        if (success)
                        {
                            vpm.AmountPaid += (float)paidAmount;
                            if (vpm.AmountPaid > vpm.TotalCost)
                                vpm.AmountPaid = vpm.TotalCost;
                            await _db.SaveChangesAsync();
                        }
                        response.OrderDescription = vnpOrderInfo ?? string.Empty;
                        response.OrderId = vehicleMonthId.ToString();
                        response.Success = success;
                    }
                }
            }
			catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "Error processing VNPAY callback.",
                        Detail = ex.Message,
                        Response = response,
                    }
                );
            }

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

            bool paid = vpm.AmountPaid >= vpm.TotalCost;
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
