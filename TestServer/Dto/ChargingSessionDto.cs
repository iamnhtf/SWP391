namespace TestServer.Dto
{
    public class ChargingSessionDto
    {
        public int SessionId { get; set; }
        public string SessionCode { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public ChargingPortInfoDto PortInfo { get; set; } = new ChargingPortInfoDto();
        public string StartTimeStr { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTimeStr { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public float EnergyConsumed { get; set; }
        public float TotalCost { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
