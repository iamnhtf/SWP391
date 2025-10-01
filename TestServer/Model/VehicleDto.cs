using System.Collections.Generic;

namespace TestServer.Models
{
    public class VehicleDto
    {
        
        public int VehicleId { get; set; }            
        public string Name { get; set; } = string.Empty;  
        public string LicensePlate { get; set; } = string.Empty; 
        public int BatteryCapacity { get; set; } = 0;    

        public List<string> ConnectorNames { get; set; } = new List<string>();
    }
}
