using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingSessionController : ControllerBase
    {
        private readonly AppDbContext db;

        public ChargingSessionController(AppDbContext context)
        {
            db = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChargingSession([FromBody] CreateChargingSessionRequest req)
        {
            if (req == null) return BadRequest("Request body required.");
            if (req.VehicleId <= 0 || string.IsNullOrWhiteSpace(req.PortId))
                return BadRequest("vehicleId and portid required.");

            // validate vehicle + port
            var vehicle = await db.Vehicles.FindAsync(req.VehicleId);
            if (vehicle == null) return NotFound($"Vehicle {req.VehicleId} not found.");

            var port = await db.ChargingPorts.FindAsync(req.PortId);
            if (port == null) return NotFound($"Port {req.PortId} not found.");

            // create session
            var session = new ChargingSession
            {
                VehicleId = req.VehicleId,
                PortId = req.PortId,
                StartTime = req.StartTime,
                Status = SessionStatus.charging
            };
            db.ChargingSessions.Add(session);

            // set port status: handle string or enum Status property
            var statusProp = port.GetType().GetProperty("Status");
            if (statusProp != null)
            {
                if (statusProp.PropertyType == typeof(string))
                {
                    statusProp.SetValue(port, "InUse");
                }
                else if (statusProp.PropertyType.IsEnum)
                {
                    try
                    {
                        var enumVal = Enum.Parse(statusProp.PropertyType, "InUse", ignoreCase: true);
                        statusProp.SetValue(port, enumVal);
                    }
                    catch { /* ignore if enum value not present */ }
                }
                db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            // --- update MonthlyPeriod / VehiclePerMonth ---
            var month = req.StartTime.Month;
            var year = req.StartTime.Year;

            // find period (use EF.Property for Month/Year to avoid compile-time dependency on exact MonthlyPeriod shape)
            var period = await db.MonthlyPeriods
                .FirstOrDefaultAsync(p => EF.Property<int>(p, "Month") == month && EF.Property<int>(p, "Year") == year);

            if (period == null)
            {
                // create new MonthlyPeriod with Month/Year — adjust property names if different
                period = Activator.CreateInstance(typeof(MonthlyPeriod)) as MonthlyPeriod;
                if (period != null)
                {
                    var mpMonth = period.GetType().GetProperty("Month");
                    var mpYear = period.GetType().GetProperty("Year");
                    if (mpMonth != null) mpMonth.SetValue(period, month);
                    if (mpYear != null) mpYear.SetValue(period, year);
                    db.MonthlyPeriods.Add(period);
                    await db.SaveChangesAsync(); // ensure PK is generated
                }
            }

            // determine periodId (try common PK names)
            int periodId = 0;
            if (period != null)
            {
                var idProp = period.GetType().GetProperty("MonthlyPeriodId")
                            ?? period.GetType().GetProperty("Id")
                            ?? period.GetType().GetProperty("PeriodId");
                if (idProp != null)
                {
                    periodId = (int)(idProp.GetValue(period) ?? 0);
                }
                else
                {
                    try
                    {
                        periodId = (int)db.Entry(period).Property("Id").CurrentValue;
                    }
                    catch { /* ignore */ }
                }
            }

            // update VehiclePerMonth using strongly-typed model
            if (periodId != 0)
            {
                var vehicleMonth = await db.VehiclePerMonths
                    .FirstOrDefaultAsync(vm => vm.VehicleId == vehicle.VehicleId && vm.PeriodId == periodId);

                if (vehicleMonth == null)
                {
                    vehicleMonth = new VehiclePerMonth
                    {
                        VehicleId = vehicle.VehicleId,
                        PeriodId = periodId,
                        TotalSessions = 0,
                        TotalEnergy = 0,
                        TotalCost = 0,
                        AmountPaid = 0
                    };
                    db.VehiclePerMonths.Add(vehicleMonth);
                }

                vehicleMonth.TotalSessions += 1;
                //db.Entry(vehicleMonth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            await db.SaveChangesAsync();

            // return sessionId only
            return Ok(new { sessionId = session.Id });
        }

        [HttpPost("stop")]
        public async Task<IActionResult> StopChargingSession([FromBody] StopChargingSessionRequest req)
        {
            if (req == null) return BadRequest("Request body required.");

            var session = await db.ChargingSessions.FindAsync(req.SessionId);
            if (session == null) return NotFound($"Session {req.SessionId} not found.");
            if (session.Status == SessionStatus.Completed) return BadRequest("Session already completed.");

            session.EndTime = req.EndTime;
            session.EnergyConsumed = req.EnergyConsumed;
            session.TotalCost = req.TotalCost;
            session.Status = SessionStatus.Completed;
            db.Entry(session).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // update VehiclePerMonth totals for the month of session.StartTime
            var start = session.StartTime;
            var month = start.Month;
            var year = start.Year;

            var period = await db.MonthlyPeriods
                .FirstOrDefaultAsync(p => EF.Property<int>(p, "Month") == month && EF.Property<int>(p, "Year") == year);

            int periodId = 0;
            if (period != null)
            {
                var idProp = period.GetType().GetProperty("MonthlyPeriodId")
                            ?? period.GetType().GetProperty("Id")
                            ?? period.GetType().GetProperty("PeriodId");
                if (idProp != null)
                {
                    periodId = (int)(idProp.GetValue(period) ?? 0);
                }
                else
                {
                    try
                    {
                        periodId = (int)db.Entry(period).Property("Id").CurrentValue;
                    }
                    catch { /* ignore */ }
                }
            }

            // update VehiclePerMonth using strongly-typed model (VehicleId)
            if (periodId != 0)
            {
                var vehicleMonth = await db.VehiclePerMonths
                    .FirstOrDefaultAsync(vm => vm.VehicleId == session.VehicleId && vm.PeriodId == periodId);

                if (vehicleMonth != null)
                {
                    vehicleMonth.TotalEnergy += req.EnergyConsumed;
                    vehicleMonth.TotalCost += req.TotalCost;
                    db.Entry(vehicleMonth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }

            // free port if exists
            var port = await db.ChargingPorts.FindAsync(session.PortId);
            var statusProp = port.GetType().GetProperty("Status");
            if (statusProp != null)
            {
                if (statusProp.PropertyType == typeof(string))
                {
                    statusProp.SetValue(port, "Available");
                }
                else if (statusProp.PropertyType.IsEnum)
                {
                    try
                    {
                        var enumVal = Enum.Parse(statusProp.PropertyType, "Available", ignoreCase: true);
                        statusProp.SetValue(port, enumVal);
                    }
                    catch { /* ignore if enum value not present */ }
                }
                db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            await db.SaveChangesAsync();

            return Ok(new { sessionId = session.Id });
        }    
    }
}