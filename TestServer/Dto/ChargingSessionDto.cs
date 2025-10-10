
namespace TestServer.Dto
{
    public class ChargingSessionDto
    {
        public int SessionId { get; set; }
        public int VehicleId { get; set; }
        public string PortId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StationName { get; set; }
        public string PortType { get; set; }
        public float EnergyConsumed { get; set; }
        public float TotalCost { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}