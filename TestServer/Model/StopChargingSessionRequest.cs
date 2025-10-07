namespace TestServer.Models.DTOs;
public record StopChargingSessionRequest(int SessionId, DateTime EndTime, float EnergyConsumed, float TotalCost);