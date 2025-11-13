using System.ComponentModel.DataAnnotations;

namespace TestServer.Dto
{
    public class PriceTableDto
    {
        [Required]
        public float PricePerKWh { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public float PenaltyFeePerMinute { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }
    }
}
