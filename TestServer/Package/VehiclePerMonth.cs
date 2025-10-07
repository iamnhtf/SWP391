using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestServer.Models;


namespace TestServer.Package
{
    public class VehiclePerMonth
    {
        [Key]
        public int VehicleMonthId { get; set; } = 0;

        [ForeignKey("Customer")]
        public string Id { get; set; } = string.Empty;
        public Customer Customer { get; set; } = null!;

        [ForeignKey("MonthlyPeriod")]
        public int PeriodId { get; set; } = 0;
        public MonthlyPeriod MonthlyPeriod { get; set; } = null!;

        public int TotalSessions { get; set; } = 0;

        public float TotalEnergy { get; set; } = 0;

        public float AmountPaid { get; set; } = 0;
    }
};