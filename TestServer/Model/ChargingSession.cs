using System; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace TestServer.Models;
public class ChargingSession
    {
        [Key]
        public int Id { get; set; } = 0;

        [ForeignKey("VehicleConnectorType")]
        public int vehicleId { get; set; } = 0;

        [ForeignKey("ChargingPort")]
        public int PortId { get; set; } = 0;

        [ForeignKey("Price")]
        public int PriceId { get; set; } = 0;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; } = null;

        public float EnergyConsumed { get; set; } = 0;

        public float TotalCost { get; set; } = 0;

        public enum SessionStatus
        {
            charging,
            Completed,
        }
        public ICollection<ChargingPoint> ChargingPoints { get; set; } = new List<ChargingPoint>();
    }