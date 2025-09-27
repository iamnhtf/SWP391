// ChargingPoint.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Models
{
    public class ChargingPoint
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [ForeignKey("ChargingStation")]
        public int StationId { get; set; }
        public ChargingStation ChargingStation { get; set; } = null!;

        public ICollection<ChargingPort> ChargingPorts { get; set; } = new List<ChargingPort>();

    }
}