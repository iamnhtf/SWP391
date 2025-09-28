using System.ComponentModel.DataAnnotations;
using TestServer.Models;

namespace TestServer.Package
{
    public class AccountPackage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double MinTotalSpend { get; set; }

        public double DiscountPercent { get; set; }

         public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}