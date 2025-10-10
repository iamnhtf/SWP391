namespace TestServer.Dto
{
    public class VehiclePerMonthDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalSessions { get; set; }
        public float TotalEnergy { get; set; }
        public float TotalCost { get; set; }
        public float AmountPaid { get; set; }
    }
}