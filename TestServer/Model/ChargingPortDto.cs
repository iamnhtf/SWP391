// ChargingPortDto.cs
namespace TestServer.Models
{
    public class ChargingPortDto
    {
        public string Id { get; set; } = string.Empty;
        public string PointId { get; set; } = string.Empty;

        // Thông tin connector
        public int ConnectorId { get; set; }
        public string ConnectorName { get; set; } = string.Empty; // Lấy từ Connector.Name

        public string Power { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // enum -> string
    }
}
