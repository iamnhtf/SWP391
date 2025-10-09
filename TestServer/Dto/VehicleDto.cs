using System.Collections.Generic;

namespace TestServer.Dto
{
    public class VehicleDto
    {
        
        public int VehicleId { get; set; }            
        public string Name { get; set; } = string.Empty;  
        public string LicensePlate { get; set; } = string.Empty; 
        public int BatteryCapacity { get; set; } = 0;    
        public string VehicleType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // enum -> string
        
        public List<string> ConnectorNames { get; set; } = new List<string>();
    }
}
