using System.Collections.Generic;

namespace TestServer.Dto
{
    public class ChargingStationDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public List<ChargingPointDto> Points { get; set; } = new List<ChargingPointDto>();
    }
}