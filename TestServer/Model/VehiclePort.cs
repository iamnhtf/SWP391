using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestServer.Package;  

namespace TestServer.Models
{
    public class VehiclePort
    {
        [ForeignKey("Vehicle")]
        public string VehicleId { get; set; } = string.Empty;

        [ForeignKey("Connector")]
        public int ConnectorId { get; set; }

    }
}