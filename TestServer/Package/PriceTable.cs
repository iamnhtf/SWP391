using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestServer.Package
{
    public class PriceTable
    {
        [Key]
        public int Id { get; set; }
        public float PricePerKWh { get; set; } = 0;
        public float PenaltyFeePerMinute { get; set; } = 0;

        public DateTime ValidFrom { get; set; } = DateTime.Now;
        public DateTime ValidTo { get; set; } = DateTime.Now.AddYears(1);

        public PriceTableStatus Status { get; set; } = PriceTableStatus.Active;
    }

    public enum PriceTableStatus {
        Active,
        Inactive
    }
};