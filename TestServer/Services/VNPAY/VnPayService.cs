using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TestServer.Libraries;
using TestServer.Models.VNPAY;
using VNPAY.NET;

namespace TestServer.Services.VNPAY
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;

        public VnPayService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreatePaymentUrl(PaymentInformationModel model, HttpContext context)
        {
            var timeZoneId = _configuration["TimeZoneId"] ?? "SE Asia Standard Time";
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = Guid.NewGuid().ToString();
            var pay = new VNPAYLibraries();

            // LẤY URL TRẢ VỀ TỪ FILE CẤU HÌNH
            var urlCallBack = _configuration["Vnpay:ReturnUrl"];
            // Nếu chưa cấu hình hoặc đang trỏ về localhost (ví dụ khi deploy), tạo fallback từ HttpContext
            if (string.IsNullOrWhiteSpace(urlCallBack) || urlCallBack.Contains("localhost"))
            {
                try
                {
                    if (context != null && context.Request != null)
                    {
                        // sử dụng route api callback để nhất quán
                        urlCallBack = $"{context.Request.Scheme}://{context.Request.Host}/api/payment/callback-vnpay";
                    }
                }
                catch { /* ignore and keep urlCallBack as-is */ }
            }

            // Read configuration values with safe fallbacks
            var vnpVersion = _configuration["Vnpay:Version"] ?? string.Empty;
            var vnpCommand = _configuration["Vnpay:Command"] ?? string.Empty;
            var vnpTmnCode = _configuration["Vnpay:TmnCode"] ?? string.Empty;
            var vnpCurrCode = _configuration["Vnpay:CurrCode"] ?? string.Empty;
            var vnpLocale = _configuration["Vnpay:Locale"] ?? string.Empty;

            pay.AddRequestData("vnp_Version", vnpVersion);
            pay.AddRequestData("vnp_Command", vnpCommand);
            pay.AddRequestData("vnp_TmnCode", vnpTmnCode);
            pay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", vnpCurrCode);
            pay.AddRequestData("vnp_IpAddr", "127.0.0.1");
            pay.AddRequestData("vnp_Locale", vnpLocale);
            pay.AddRequestData(
                "vnp_OrderInfo",
                $"{model.Name} {model.OrderDescription} {model.Amount}"
            );
            pay.AddRequestData("vnp_OrderType", "other"); // Luôn gửi giá trị này

            // ĐẢM BẢO DÒNG NÀY ĐƯỢC THÊM VÀO VÀ urlCallBack KHÔNG BỊ NULL
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack ?? string.Empty);

            pay.AddRequestData("vnp_TxnRef", tick);

            var vnpBaseUrl = _configuration["Vnpay:BaseUrl"] ?? string.Empty;
            var vnpHashSecret = _configuration["Vnpay:HashSecret"] ?? string.Empty;

            var paymentUrl = pay.CreateRequestUrl(vnpBaseUrl, vnpHashSecret);

            return paymentUrl;
        }

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VNPAYLibraries();
            var vnpHashSecretResp = _configuration["Vnpay:HashSecret"] ?? string.Empty;
            var response = pay.GetFullResponseData(collections, vnpHashSecretResp);

            return response;
        }
    }
}
