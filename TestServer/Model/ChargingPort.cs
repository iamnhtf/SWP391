// ChargingPort.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestServer.Package;

namespace TestServer.Models
{
    public class ChargingPort
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [ForeignKey("ChargingPoint")]
        public string PointId { get; set; } = string.Empty;
        public ChargingPoint ChargingPoint { get; set; } = null!;

        [ForeignKey("Connector")]
        public int ConnectorId { get; set; }
        public Connector Connector { get; set; } = null!;

        public int Power { get; set; }

        public ChargingPortStatus Status { get; set; } = ChargingPortStatus.Available;

    }

    public enum ChargingPortStatus
    {
        Available,
        InUse,
        Faulty
    }

    
}