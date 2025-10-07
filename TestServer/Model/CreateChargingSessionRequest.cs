namespace TestServer.Models.DTOs;
public record CreateChargingSessionRequest(int VehicleId, string PortId, DateTime StartTime);