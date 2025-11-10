using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

namespace TestServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/reports/summary
    [HttpGet("summary")]
    public async Task<ActionResult<AdminSummaryDto>> GetSummary()
    {
        var totalSessions = await _db.ChargingSessions.CountAsync();
        var totalRevenue = await _db.ChargingSessions.SumAsync(s => (double)s.TotalCost);
        var energyConsumed = await _db.ChargingSessions.SumAsync(s => (double)s.EnergyConsumed);

        var durationPairs = await _db.ChargingSessions
            .Where(s => s.EndTime.HasValue)
            .Select(s => new { s.StartTime, s.EndTime })
            .ToListAsync();

        double avgMinutes = 0;
        if (durationPairs.Count > 0)
        {
            avgMinutes = durationPairs.Average(x => (x.EndTime!.Value - x.StartTime).TotalMinutes);
        }

        var summary = new AdminSummaryDto
        {
            TotalSessions = totalSessions,
            TotalRevenue = totalRevenue,
            EnergyConsumed = energyConsumed,
            AvgSessionMinutes = avgMinutes
        };

        return Ok(summary);
    }

    // GET: api/reports/topstations?take=7
    [HttpGet("topstations")]
    public async Task<ActionResult<IEnumerable<StationReportDto>>> GetTopStations([FromQuery] int take = 7)
    {
        // Fetch relevant session records joined with station info
        var raw = await (from s in _db.ChargingSessions
                         join p in _db.ChargingPorts on s.PortId equals p.Id
                         join pt in _db.ChargingPoints on p.PointId equals pt.Id
                         join st in _db.ChargingStations on pt.StationId equals st.Id
                         select new {
                             StationId = st.Id,
                             StationName = st.Name,
                             Energy = (double)s.EnergyConsumed,
                             Revenue = (double)s.TotalCost,
                             Start = s.StartTime,
                             End = s.EndTime
                         })
                         .ToListAsync();

        var grouped = raw
            .GroupBy(x => new { x.StationId, x.StationName })
            .Select(g => new StationReportDto
            {
                StationId = g.Key.StationId,
                StationName = g.Key.StationName,
                TotalSessions = g.Count(),
                EnergyKWh = g.Sum(x => x.Energy),
                Revenue = g.Sum(x => x.Revenue),
                AvgSessionMinutes = g.Where(x => x.End.HasValue).Any()
                    ? g.Where(x => x.End.HasValue).Average(x => (x.End!.Value - x.Start).TotalMinutes)
                    : 0
            })
            .OrderByDescending(s => s.Revenue)
            .Take(take)
            .ToList();

        return Ok(grouped);
    }
}
