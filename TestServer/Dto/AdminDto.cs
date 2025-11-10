namespace TestServer.DTOs
{
    public class AdminSummaryDto
    {
        public int TotalSessions { get; set; }
        public double TotalRevenue { get; set; }
        public double EnergyConsumed { get; set; }
        public double AvgSessionMinutes { get; set; }
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
}