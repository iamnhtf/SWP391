namespace TestServer.Models.VNPAY
{
    public class PaymentInformationModel
    {
        
        public double Amount { get; set; }
        public string OrderDescription { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}