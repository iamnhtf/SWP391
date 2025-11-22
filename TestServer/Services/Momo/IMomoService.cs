using TestServer.Models.Momo;
using TestServer.Models.Order;

namespace TestServer.Services.Momo
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponse> CreatePaymentMomo(OrderInfo model);
        MomoExecuteResponeModel PaymentExecuteAsync(IQueryCollection collection);
    }
    
}