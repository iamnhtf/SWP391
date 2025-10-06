using System; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace TestServer.Models;
public class ChargingStation
    {
        [Key]
        public int Id { get; set; } = 0;
        
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public ICollection<ChargingPoint> ChargingPoints { get; set; } = new List<ChargingPoint>();
    }