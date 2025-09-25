using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer.Package
{
    public class PriceList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }

        [ForeignKey("Connector")]
        public int ConnectorId { get; set; }
        public Connector? Connector { get; set; }

        [ForeignKey("PowerRange")]
        public int PowerRangeId { get; set; }
        public PowerRange? PowerRange { get; set; }

        [ForeignKey("TimeRange")]
        public int TimeRangeId { get; set; }
        public TimeRange? TimeRange { get; set; }

        public double Price { get; set; }
    }
}