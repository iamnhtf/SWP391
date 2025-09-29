// ChargingPortInfoDto.cs
namespace TestServer.Models
{
    public class ChargingPortInfoDto
    {
        public string Id { get; set; } = string.Empty;

        // Thông tin connector
        public string ConnectorName { get; set; } = string.Empty; // Lấy từ Connector.Name

        public int Power { get; set; } = 0;
        public string Status { get; set; } = string.Empty; // enum -> string

        // Thông tin ChargingPoint
        public string ChargingPointId { get; set; } = string.Empty;
        public string ChargingStationName { get; set; } = string.Empty;
    }
}