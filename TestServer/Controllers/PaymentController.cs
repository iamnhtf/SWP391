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
            // Cố gắng thực thi lệnh gọi service để lấy response model (có thể null nếu có lỗi)
            PaymentResponseModel response = null;
            try
            {
                response = _vnPayService.PaymentExecute(Request.Query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing VnPayService.PaymentExecute: {ex.Message}");
                // Tạo một response model mặc định nếu service lỗi
                response = new PaymentResponseModel { Success = false };
            }

            var q = Request.Query;

            // --- SỬA LỖI LẤY DỮ LIỆU TỪ QUERY ---
            string vnpResponseCode = q["vnp_ResponseCode"].FirstOrDefault() ?? ""; // Lấy mã, xử lý null
            string vnpTxnRef = q["vnp_TxnRef"].FirstOrDefault() ?? ""; // Lấy mã giao dịch, xử lý null
            string vnpOrderInfo = q["vnp_OrderInfo"].FirstOrDefault() ?? ""; // Lấy thông tin đơn hàng, xử lý null
            string vnpAmountRaw = q["vnp_Amount"].FirstOrDefault() ?? "0"; // Lấy số tiền, xử lý null, mặc định "0"
            string vnpTxnStatus = q["vnp_TransactionStatus"].FirstOrDefault() ?? ""; // Lấy trạng thái giao dịch (nếu có)
            // --- KẾT THÚC SỬA LỖI ---

            string message = ""; // Biến để lưu thông báo
            string status = "Pending";
            var vehicleMonthId = 0;
            double paidAmount = 0;

            var match = System.Text.RegularExpressions.Regex.Match(
                vnpOrderInfo,
                @"VehicleMonth\s*(\d+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );
            int.TryParse(match.Groups[1].Value, out vehicleMonthId);

            if (vnpResponseCode == "00") // Thành công
            {
                response.Success = true; // Đảm bảo Success là true
                message = "Thanh toán thành công!";
                status = "Success";
                Console.WriteLine($"VNPAY payment success for order {vnpTxnRef}");
                try
                {
                    // --- LOGIC CẬP NHẬT DATABASE KHI THÀNH CÔNG ---
                    if (match.Success)
                    {
                        var vpm = await _db.VehiclePerMonths.FirstOrDefaultAsync(x =>
                            x.VehicleMonthId == vehicleMonthId
                        );
                        if (vpm != null)
                        {
                            // Parse số tiền đã lấy an toàn ở trên
                            if (int.TryParse(vnpAmountRaw, out var amountInt))
                            {
                                paidAmount = amountInt / 100.0;
                            }
                            vpm.AmountPaid += (float)paidAmount;
                            if (vpm.AmountPaid > vpm.TotalCost)
                                vpm.AmountPaid = vpm.TotalCost;

                            await _db.SaveChangesAsync();
                            response.OrderId = vehicleMonthId.ToString(); // Gán OrderId nếu thành công và tìm thấy
                        }
                        else
                        {
                            Console.WriteLine(
                                $"VehiclePerMonth record not found for ID: {vehicleMonthId}"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Could not extract VehicleMonthId from OrderInfo: {vnpOrderInfo}"
                        );
                    }
                    // --- KẾT THÚC LOGIC CẬP NHẬT ---
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating DB after VNPAY success: {ex.Message}");
                    response.Success = false; // Set lại false nếu cập nhật DB lỗi
                    message = "Thanh toán thành công nhưng có lỗi khi cập nhật dữ liệu.";
                }
            }
            else if (vnpResponseCode == "24") // Bị hủy bởi người dùng
            {
                response.Success = false;
                message = "Giao dịch đã bị hủy."; // Thông báo hủy cụ thể
                status = "Cancelled";
                Console.WriteLine($"VNPAY payment cancelled {vnpTxnRef}. Code: {vnpResponseCode}");
            }
            else if (
                string.IsNullOrEmpty(vnpResponseCode)
                && Request?.Host.Value?.Contains("localhost", StringComparison.OrdinalIgnoreCase)
                    == true
            )
            {
                // Nếu không có mã phản hồi và đang chạy trên localhost, coi là giao dịch bị hủy
                response.Success = false;
                message = "Giao dịch tạm dừng/đã bị hủy (local).";
                Console.WriteLine(
                    $"VNPAY payment presumed cancelled for order {vnpTxnRef}. No response code. Host: {Request?.Host}"
                );
            }
            else // Các trường hợp thất bại khác
            {
                response.Success = false;
                message = $"Thanh toán thất bại. Mã lỗi VNPAY: {vnpResponseCode}"; // Thông báo lỗi chung
                status = "Failed";
                Console.WriteLine(
                    $"VNPAY payment failed for order {vnpTxnRef}. Code: {vnpResponseCode}"
                );
            }

            // Lưu log vào bảng PaymentTransactions
            _db.PaymentTransactions.Add(
                new PaymentTransaction
                {
                    VehicleMonthId = vehicleMonthId,
                    ResponseCode = vnpResponseCode,
                    TransactionStatus = vnpTxnStatus,
                    OrderInfo = vnpOrderInfo ?? "",
                    Amount = paidAmount,
                    CreatedAt = DateTime.UtcNow,
                }
            );
            await _db.SaveChangesAsync();

            Console.WriteLine(
                $"Payment transaction logged for VehicleMonthId {vehicleMonthId} with response code {vnpResponseCode}."
            );

            // Gán thông báo vào ViewBag để View có thể hiển thị
            ViewBag.ResultMessage = message;
            response.OrderDescription = vnpOrderInfo; // Gán lại các thông tin cần thiết khác nếu View cần

            // Lưu trạng thái vào cache
            _paymentStatusCache[vehicleMonthId] = status;

            // Trả về View với model response (chứa Success=true/false) và ViewBag (chứa thông báo chi tiết)
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
                // --- XÓA transaction sau khi đã đọc ---
                if (lastTx != null)
                {
                    _db.PaymentTransactions.Remove(lastTx);
                    await _db.SaveChangesAsync();
                    Console.WriteLine(
                        $"Deleted failed/cancelled transaction for VehicleMonthId={vehicleMonthId}"
                    );
                }

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

            if (lastTx != null && paid)
            {
                _db.PaymentTransactions.Remove(lastTx);
                await _db.SaveChangesAsync();
                Console.WriteLine(
                    $"Deleted transaction log after status check for VehicleMonthId={vehicleMonthId}"
                );
            }

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
                        CreatedAt = pt.CreatedAt
                    }
                )
                .ToListAsync();

            return Ok(list);
        }
        
        [HttpGet("transactions/{customerId}")]
        public async Task<IActionResult> GetTransactionsByCustomerId(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest("Invalid customerId.");

            var userId = await _db.Customers
                .Where(u => u.Id == customerId)
                .FirstOrDefaultAsync(); 

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
                        CreatedAt = pt.CreatedAt
                    }
                )
                .ToListAsync();

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
