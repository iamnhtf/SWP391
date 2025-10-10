using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TestServer.Models.VNPAY;

namespace TestServer.Services.VNPAY
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}