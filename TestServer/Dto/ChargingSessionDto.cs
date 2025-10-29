namespace TestServer.Dto
{
    public class ChargingSessionDto
    {
        public int SessionId { get; set; }
        public string SessionCode { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public ChargingPortInfoDto PortInfo { get; set; } = new ChargingPortInfoDto();
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; } = string.Empty;
        public float EnergyConsumed { get; set; }
        public float TotalCost { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
