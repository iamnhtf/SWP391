namespace TestServer.Models.DTOs;
public class ChargingSessionDto
{
    public int SessionId { get; set; }
    public int VehicleId { get; set; }
    public string PortId { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public string Status { get; set; } = string.Empty;
}