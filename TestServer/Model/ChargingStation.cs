using System; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace TestServer.Models;
public class ChargingStation
    {
        [Key]
        public int Id { get; set; } = 0;
        
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public ICollection<ChargingPoint> ChargingPoints { get; set; } = new List<ChargingPoint>();
    }