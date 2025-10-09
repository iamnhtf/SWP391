using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestServer.Package;
using System.Collections.Generic;

namespace TestServer.Dto
{
    public class VehicleConnectorTypeDto
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; } = string.Empty;

        public int ConnectorId { get; set; }
        public string ConnectorName { get; set; } = string.Empty;
    }
}
