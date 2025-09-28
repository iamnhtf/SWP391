// ChargingPortDto.cs
namespace TestServer.Models
{
    public class ChargingPortDto
    {
        public string Id { get; set; } = string.Empty;

        // Thông tin connector
        public string ConnectorName { get; set; } = string.Empty; // Lấy từ Connector.Name

        public int Power { get; set; } = 0;
        public string Status { get; set; } = string.Empty; // enum -> string
    }
}
