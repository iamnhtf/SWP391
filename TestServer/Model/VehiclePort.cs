using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestServer.Package;  

namespace TestServer.Models
{
    public class VehiclePort
    {
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        [ForeignKey("Connector")]
        public int ConnectorId { get; set; }
        public Connector Connector { get; set; } = null!;

    }
}