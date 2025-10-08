using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestServer.Package;
namespace TestServer.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int BatteryCapacity { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; } 
        public VehicleType? VehicleType { get; set; }
        public VehicleStatus Status { get; set; } = VehicleStatus.Available;
        
        public ICollection<VehiclePort> VehiclePorts { get; set; } = new List<VehiclePort>();

    }

    public enum VehicleStatus
    {
        Available,
        InUse,
        Faulty
    }
}