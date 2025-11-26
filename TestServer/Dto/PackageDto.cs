namespace TestServer.Dto
{
    public class UserPackageDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public int DiscountPercentAtPurchase { get; set; }
        public int ReservationMinutesAtPurchase { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}