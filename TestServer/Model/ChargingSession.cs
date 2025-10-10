using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestServer.Models
{
    public class ChargingSession
    {
        [Key]
        public int Id { get; set; } = 0;

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; } = 0;
        public Vehicle Vehicle { get; set; } = null!;

        [ForeignKey("ChargingPort")]
        public string PortId { get; set; } = string.Empty;
        public ChargingPort ChargingPort { get; set; } = null!;

        // [ForeignKey("Price")]
        // public int PriceId { get; set; } = 0;
        // public PriceTable Price { get; set; } = null!;

        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; } = null;
        public float EnergyConsumed { get; set; } = 0;

        public float TotalCost { get; set; } = 0;
        public SessionStatus Status { get; set; } = SessionStatus.charging;
    }

    public enum SessionStatus
    {
        charging,
        Completed,
    }
}