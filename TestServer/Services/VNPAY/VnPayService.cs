using VNPAY.NET;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TestServer.Models.VNPAY;
using TestServer.Libraries;

namespace TestServer.Services.VNPAY
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;

        public VnPayService( IConfiguration configuration)
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

    pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
    pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
    pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
    pay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
    pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
    pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
    pay.AddRequestData("vnp_IpAddr", "127.0.0.1");
    pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
    pay.AddRequestData("vnp_OrderInfo", $"{model.Name} {model.OrderDescription} {model.Amount}");
    pay.AddRequestData("vnp_OrderType", "other"); // Luôn gửi giá trị này

    // ĐẢM BẢO DÒNG NÀY ĐƯỢC THÊM VÀO VÀ urlCallBack KHÔNG BỊ NULL
    pay.AddRequestData("vnp_ReturnUrl", urlCallBack); 

    pay.AddRequestData("vnp_TxnRef", tick);

    var paymentUrl =
        pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

    return paymentUrl;
}

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VNPAYLibraries();
            var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);

            return response;
        }


    }
}