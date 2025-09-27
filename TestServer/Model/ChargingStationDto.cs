using System.Collections.Generic;

namespace TestServer.Models
{
    public class ChargingStationDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public List<ChargingPointDto> Points { get; set; } = new List<ChargingPointDto>();
    }
}