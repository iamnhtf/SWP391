using System.Collections.Generic;

namespace TestServer.Models
{
    public class ChargingPointDto
    {
        public string Id { get; set; } = string.Empty;
        public int StationId { get; set; }
        public string StationName { get; set; } = string.Empty; // tên ChargingStation nếu muốn hiển thị

        public List<ChargingPortDto> Ports { get; set; } = new List<ChargingPortDto>();
    }
}
