using System.Collections.Generic;

namespace TestServer.Dto
{
    public class ChargingPointDto
    {
        public string Id { get; set; } = string.Empty;

        public List<ChargingPortDto> Ports { get; set; } = new List<ChargingPortDto>();
    }
}
