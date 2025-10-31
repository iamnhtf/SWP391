namespace TestServer.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public int VehicleMonthId { get; set; }
        public string ResponseCode { get; set; } = string.Empty;
        public string TransactionStatus { get; set; } = string.Empty;
        public string OrderInfo { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
