namespace TestServer.Dto
{
    public record CreateChargingSessionRequest(int VehicleId, string PortId, DateTime StartTime);
}