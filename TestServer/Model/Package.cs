using System.ComponentModel.DataAnnotations;

namespace TestServer.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MonthlyPrice { get; set; }
        public int DiscountPercent { get; set; } 
        public int ReservationTime { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}