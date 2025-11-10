using System;

namespace TestServer.Dto
{
    public class MostActiveVehicleDto
    {
        public string VehicleName { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public int TotalSessions { get; set; }
        public double TotalEnergy { get; set; }
        public double TotalCost { get; set; }
    }

    public class TopCustomerDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TotalSessions { get; set; }
        public double TotalSpent { get; set; }
        public DateTime? LastSession { get; set; }
    }

    public class StationReportDto
    {
        public int StationId { get; set; }
        public string StationName { get; set; } = string.Empty;
        public int TotalSessions { get; set; }
        public double EnergyKWh { get; set; }
        public double Revenue { get; set; }
        public double AvgSessionMinutes { get; set; }
    }

    public class AdminSummaryDto
    {
        public int TotalSessions { get; set; }
        public double TotalRevenue { get; set; }
        public double EnergyConsumed { get; set; }
        public double AvgSessionMinutes { get; set; }
    }
}
