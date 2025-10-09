namespace TestServer.Dto
{
    public record StopChargingSessionRequest(int SessionId, DateTime EndTime, float EnergyConsumed, float TotalCost);
}