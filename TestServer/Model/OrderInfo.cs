namespace TestServer.Models.Order
{
    public class OrderInfo
    {
        public string FullName { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string OrderInformation { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}