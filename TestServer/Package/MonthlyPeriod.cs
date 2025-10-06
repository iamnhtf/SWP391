using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestServer.Package
{
    public class MonthlyPeriod
    {
        [Key]
        public int PeriodId { get; set; } = 0;

        public int Month { get; set; } = 0;
        public int Year { get; set; } = 0;
        
    }
};