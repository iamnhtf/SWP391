using System;

namespace TestServer.Models
{
    public class PackagePaymentTransaction
    {
        public int Id { get; set; }
        public int PackageSubscriptionId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string ResponseCode { get; set; } = string.Empty;
        public string TransactionStatus { get; set; } = string.Empty;
        public string OrderInfo { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
