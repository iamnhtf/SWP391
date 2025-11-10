using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Dto;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/admin/most-active-vehicles?take=10
        [HttpGet("most-active-vehicles")]
        public async Task<ActionResult<IEnumerable<MostActiveVehicleDto>>> GetMostActiveVehicles([FromQuery] int take = 10)
        {
            var stats = await _db.ChargingSessions
                .GroupBy(s => s.VehicleId)
                .Select(g => new
                {
                    VehicleId = g.Key,
                    TotalSessions = g.Count(),
                    TotalEnergy = g.Sum(s => (double)s.EnergyConsumed),
                    TotalCost = g.Sum(s => (double)s.TotalCost)
                })
                .OrderByDescending(x => x.TotalSessions)
                .Take(take)
                .ToListAsync();

            var vehicleIds = stats.Select(s => s.VehicleId).ToList();
            var vehicles = await _db.Vehicles.Where(v => vehicleIds.Contains(v.VehicleId)).ToListAsync();

            var result = stats.Select(s =>
            {
                var v = vehicles.FirstOrDefault(x => x.VehicleId == s.VehicleId);
                return new MostActiveVehicleDto
                {
                    VehicleName = v?.Name ?? "-",
                    LicensePlate = v?.LicensePlate ?? "-",
                    TotalSessions = s.TotalSessions,
                    TotalEnergy = Math.Round(s.TotalEnergy, 1),
                    TotalCost = s.TotalCost
                };
            }).ToList();

            return Ok(result);
        }

        // GET: api/admin/top-customers?take=3
        [HttpGet("top-customers")]
        public async Task<ActionResult<IEnumerable<TopCustomerDto>>> GetTopCustomers([FromQuery] int take = 3)
        {
            var grouped = await (from s in _db.ChargingSessions
                                join v in _db.Vehicles on s.VehicleId equals v.VehicleId
                                join c in _db.Customers on v.CustomerId equals c.Id
                                group s by new { c.Id, c.Name, c.Email } into g
                                select new TopCustomerDto
                                {
                                    CustomerName = g.Key.Name,
                                    Email = g.Key.Email,
                                    TotalSessions = g.Count(),
                                    TotalSpent = g.Sum(x => (double)x.TotalCost),
                                    LastSession = g.Max(x => x.EndTime)
                                })
                                .OrderByDescending(x => x.TotalSpent)
                                .Take(take)
                                .ToListAsync();

            return Ok(grouped);
        }

        // GET: api/admin/summary
        [HttpGet("summary")]
        public async Task<ActionResult<AdminSummaryDto>> GetSummary()
        {
            var totalSessions = await _db.ChargingSessions.CountAsync();
            var totalRevenue = await _db.ChargingSessions.SumAsync(s => (double)s.TotalCost);
            var energyConsumed = await _db.ChargingSessions.SumAsync(s => (double)s.EnergyConsumed);

            // average session duration in minutes (only include sessions that have EndTime)
            var durations = await _db.ChargingSessions
                .Where(s => s.EndTime.HasValue)
                .Select(s => new { s.StartTime, s.EndTime })
                .ToListAsync();

            double avgMinutes = 0;
            if (durations.Count > 0)
            {
                avgMinutes = durations.Average(x => (x.EndTime!.Value - x.StartTime).TotalMinutes);
            }

            var dto = new AdminSummaryDto
            {
                TotalSessions = totalSessions,
                TotalRevenue = totalRevenue,
                EnergyConsumed = energyConsumed,
                AvgSessionMinutes = Math.Round(avgMinutes, 0)
            };

            return Ok(dto);
        }

        // GET: api/admin/top-stations?take=7
        [HttpGet("top-stations")]
        public async Task<ActionResult<IEnumerable<StationReportDto>>> GetTopStations([FromQuery] int take = 7)
        {
            // gather session rows joined to station via port -> point -> station
            var rows = await (from s in _db.ChargingSessions
                            join p in _db.ChargingPorts on s.PortId equals p.Id
                            join pt in _db.ChargingPoints on p.PointId equals pt.Id
                            join st in _db.ChargingStations on pt.StationId equals st.Id
                            select new
                            {
                                StationId = st.Id,
                                StationName = st.Name,
                                Energy = (double)s.EnergyConsumed,
                                Revenue = (double)s.TotalCost,
                                Start = s.StartTime,
                                End = s.EndTime
                            })
                            .ToListAsync();

            var grouped = rows.GroupBy(x => new { x.StationId, x.StationName })
                .Select(g => new StationReportDto
                {
                    StationId = g.Key.StationId,
                    StationName = g.Key.StationName,
                    TotalSessions = g.Count(),
                    EnergyKWh = Math.Round(g.Sum(x => x.Energy), 1),
                    Revenue = g.Sum(x => x.Revenue),
                    AvgSessionMinutes = g.Where(x => x.End.HasValue).Any()
                        ? Math.Round(g.Where(x => x.End.HasValue).Average(x => (x.End!.Value - x.Start).TotalMinutes), 0)
                        : 0
                })
                .OrderByDescending(s => s.Revenue)
                .Take(take)
                .ToList();

            return Ok(grouped);
        }
    }
}