using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int BatteryCapacity { get; set; }
        public int VehicleTypeId { get; set; } 

    }
}