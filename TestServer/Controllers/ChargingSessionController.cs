using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            if (req == null)
                return BadRequest("Request body required.");
            if (req.VehicleId <= 0 || string.IsNullOrWhiteSpace(req.PortId))
                return BadRequest("vehicleId and portid required.");

            // validate vehicle + port
            var vehicle = await db.Vehicles.FindAsync(req.VehicleId);
            if (vehicle == null)
                return NotFound($"Vehicle {req.VehicleId} not found.");

            var port = await db.ChargingPorts.FindAsync(req.PortId);
            if (port == null)
                return NotFound($"Port {req.PortId} not found.");

            // create session
            var session = new ChargingSession
            {
                VehicleId = req.VehicleId,
                PortId = req.PortId,
                StartTime = req.StartTime,
                Status = SessionStatus.charging,
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
                        var enumVal = Enum.Parse(
                            statusProp.PropertyType,
                            "InUse",
                            ignoreCase: true
                        );
                        statusProp.SetValue(port, enumVal);
                    }
                    catch
                    { /* ignore if enum value not present */
                    }
                }
                db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            // set charging status for vehicle
            var vehicleStatusProp = vehicle.GetType().GetProperty("Status");
            if (vehicleStatusProp != null)
            {
                if (vehicleStatusProp.PropertyType == typeof(string))
                {
                    vehicleStatusProp.SetValue(vehicle, "Charging");
                }
                else if (vehicleStatusProp.PropertyType.IsEnum)
                {
                    try
                    {
                        var enumVal = Enum.Parse(
                            vehicleStatusProp.PropertyType,
                            "Charging",
                            ignoreCase: true
                        );
                        vehicleStatusProp.SetValue(vehicle, enumVal);
                    }
                    catch
                    { /* ignore if enum value not present */
                    }
                }
                db.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            await db.SaveChangesAsync();

            // return sessionId only
            return Ok(new { sessionId = session.Id });
        }

        [HttpPut("stop")]
        public async Task<IActionResult> StopChargingSession([FromBody] StopChargingSessionRequest req)
        {
            if (req == null)
                return BadRequest("Request body required.");

            var session = await db.ChargingSessions.FindAsync(req.SessionId);
            if (session == null)
                return NotFound($"Session {req.SessionId} not found.");
            if (session.Status == SessionStatus.Completed)
                return BadRequest("Session already completed.");

            // update session
            session.EndTime = req.EndTime;
            session.EnergyConsumed = req.EnergyConsumed;
            session.TotalCost = req.TotalCost;
            session.Status = SessionStatus.Completed;
            db.Entry(session).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            // set vehicle status to Active
            var vehicle = await db.Vehicles.FindAsync(session.VehicleId);
            if (vehicle != null)
            {
                var vehicleStatusProp = vehicle.GetType().GetProperty("Status");
                if (vehicleStatusProp != null)
                {
                    if (vehicleStatusProp.PropertyType == typeof(string))
                    {
                        vehicleStatusProp.SetValue(vehicle, "Active");
                    }
                    else if (vehicleStatusProp.PropertyType.IsEnum)
                    {
                        try
                        {
                            var enumVal = Enum.Parse(
                                vehicleStatusProp.PropertyType,
                                "Active",
                                ignoreCase: true
                            );
                            vehicleStatusProp.SetValue(vehicle, enumVal);
                        }
                        catch
                        { /* ignore if enum value not present */
                        }
                    }
                    db.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }

            // free port if exists
            var port = await db.ChargingPorts.FindAsync(session.PortId);
            if (port != null)
            {
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
                            var enumVal = Enum.Parse(
                                statusProp.PropertyType,
                                "Available",
                                ignoreCase: true
                            );
                            statusProp.SetValue(port, enumVal);
                        }
                        catch
                        { /* ignore if enum value not present */
                        }
                    }
                    db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }

            await db.SaveChangesAsync();

            var s = await db
                .ChargingSessions.AsNoTracking()
                .Where(x => x.Id == req.SessionId)
                .Include(x => x.Vehicle)
                .Include(x => x.ChargingPort)
                .ThenInclude(p => p.ChargingPoint)
                .ThenInclude(cp => cp.ChargingStation)
                .Include(x => x.ChargingPort)
                .ThenInclude(p => p.Connector)
                .OrderByDescending(x => x.EndTime)
                .ThenByDescending(x => x.StartTime)
                .FirstOrDefaultAsync();

            if (s == null)
                return NotFound();

            DateTime? end = s.EndTime;
            var hasEnd = end.HasValue;
            var endTimeStr = string.Empty;
            var endTime = string.Empty;
            var duration = string.Empty;
                if (hasEnd)
            {
                var e = end!.Value;
                endTimeStr = $"{e:dd/MM/yyyy}, {e:HH:mm:ss}";
                endTime = e.ToString();
                var span = e - s.StartTime;
                duration = $"{(int)span.TotalHours}h {span.Minutes}m {span.Seconds}s";
            }

            var chargingSessionDto = new ChargingSessionDto
            {
                SessionId = s.Id,
                VehicleId = s.VehicleId,
                VehicleName = s.Vehicle != null ? s.Vehicle.Name : string.Empty,
                SessionCode = (s.ChargingPort != null && s.ChargingPort.ChargingPoint != null && s.ChargingPort.ChargingPoint.ChargingStation != null)
                    ? $"ST{s.ChargingPort.ChargingPoint.ChargingStation.Id:D2}-{s.StartTime:yyyyMMdd}-{s.Id:D4}"
                    : $"ST-UNKNOWN-{s.StartTime:yyyyMMdd}-{s.Id:D4}",
                CustomerId = s.Vehicle != null ? s.Vehicle.CustomerId : string.Empty,
                PortInfo = new ChargingPortInfoDto
                {
                    Id = s.ChargingPort != null ? s.ChargingPort.Id : string.Empty,
                    ConnectorName = s.ChargingPort?.Connector?.Name ?? string.Empty,
                    Power = s.ChargingPort?.Power ?? 0,
                    Status = s.ChargingPort != null ? s.ChargingPort.Status.ToString() : string.Empty,
                    ChargingPointId = s.ChargingPort?.ChargingPoint?.Id ?? string.Empty,
                    ChargingStationName = s.ChargingPort?.ChargingPoint?.ChargingStation?.Name ?? string.Empty,
                },
                StartTimeStr = $"{s.StartTime:dd/MM/yyyy}, {s.StartTime:HH:mm:ss}",
                StartTime = s.StartTime.ToString(),
                EndTimeStr = endTimeStr,
                EndTime = endTime,
                Duration = duration,
                EnergyConsumed = s.EnergyConsumed,
                TotalCost = s.TotalCost,
                Status = s.Status.ToString(),
            };

            return Ok(chargingSessionDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await db
                .ChargingSessions.AsNoTracking()
                .Include(s => s.Vehicle)
                .Include(s => s.ChargingPort)
                .ThenInclude(p => p.ChargingPoint)
                .ThenInclude(cp => cp.ChargingStation)
                .Include(s => s.ChargingPort)
                .ThenInclude(p => p.Connector)
                .OrderByDescending(s => s.StartTime)
                .ToListAsync();

            var dtos = sessions
                .Select(s =>
                {
                    DateTime? end = s.EndTime;
                    var hasEnd = end.HasValue;
                    var endTimeStr = string.Empty;
                    var endTime = string.Empty;
                    var duration = string.Empty;
                    if (hasEnd)
                    {
                        var e = end!.Value;
                        endTimeStr = $"{e:dd/MM/yyyy}, {e:HH:mm:ss}";
                        endTime = e.ToString();
                        var span = e - s.StartTime;
                        duration = $"{(int)span.TotalHours}h {span.Minutes}m {span.Seconds}s";
                    }

                    var energy = s.Status == SessionStatus.charging ? 0f : s.EnergyConsumed;
                    var cost = s.Status == SessionStatus.charging ? 0f : s.TotalCost;

                    return new ChargingSessionDto
                    {
                        SessionId = s.Id,
                        VehicleId = s.VehicleId,
                        VehicleName = s.Vehicle != null ? s.Vehicle.Name : string.Empty,
                        SessionCode = (s.ChargingPort != null && s.ChargingPort.ChargingPoint != null && s.ChargingPort.ChargingPoint.ChargingStation != null)
                            ? $"ST{s.ChargingPort.ChargingPoint.ChargingStation.Id:D2}-{s.StartTime:yyyyMMdd}-{s.Id:D4}"
                            : $"ST-UNKNOWN-{s.StartTime:yyyyMMdd}-{s.Id:D4}",
                        CustomerId = s.Vehicle != null ? s.Vehicle.CustomerId : string.Empty,
                        PortInfo = new ChargingPortInfoDto
                        {
                            Id = s.ChargingPort != null ? s.ChargingPort.Id : string.Empty,
                            ConnectorName = s.ChargingPort?.Connector?.Name ?? string.Empty,
                            Power = s.ChargingPort?.Power ?? 0,
                            Status = s.ChargingPort != null ? s.ChargingPort.Status.ToString() : string.Empty,
                            ChargingPointId = s.ChargingPort?.ChargingPoint?.Id ?? string.Empty,
                            ChargingStationName = s.ChargingPort?.ChargingPoint?.ChargingStation?.Name ?? string.Empty,
                        },
                        StartTimeStr = $"{s.StartTime:dd/MM/yyyy}, {s.StartTime:HH:mm:ss}",
                        StartTime = s.StartTime.ToString(),
                        EndTimeStr = endTimeStr,
                        EndTime = endTime,
                        Duration = duration,
                        EnergyConsumed = energy,
                        TotalCost = cost,
                        Status = s.Status.ToString(),
                    };
                })
                .ToList();

            return Ok(dtos);
        }

        // GET api/ChargingSession/bycustomer/{customerId}
        [HttpGet("bycustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
                return BadRequest("customerId required.");

            var sessions = await db
                .ChargingSessions.AsNoTracking()
                .Include(s => s.Vehicle)
                .Where(s => s.Vehicle != null && s.Vehicle.CustomerId == customerId)
                .Where(s => s.Status != SessionStatus.charging)
                .Include(s => s.ChargingPort)
                .ThenInclude(p => p.ChargingPoint)
                .ThenInclude(cp => cp.ChargingStation)
                .Include(s => s.ChargingPort)
                .ThenInclude(p => p.Connector)
                .OrderByDescending(s => s.StartTime)
                .ToListAsync();

            var dtos = sessions
                .Select(s =>
                {
                    DateTime? end = s.EndTime;
                    var hasEnd = end.HasValue;
                    var endTimeStr = string.Empty;
                    var endTime = string.Empty;
                    var duration = string.Empty;
                    if (hasEnd)
                    {
                        var e = end!.Value;
                        endTimeStr = $"{e:dd/MM/yyyy}, {e:HH:mm:ss}";
                        endTime = e.ToString();
                        var span = e - s.StartTime;
                        duration = $"{(int)span.TotalHours}h {span.Minutes}m {span.Seconds}s";
                    }

                    return new ChargingSessionDto
                    {
                        SessionId = s.Id,
                        VehicleId = s.VehicleId,
                        VehicleName = s.Vehicle != null ? s.Vehicle.Name : string.Empty,
                        SessionCode = (s.ChargingPort != null && s.ChargingPort.ChargingPoint != null && s.ChargingPort.ChargingPoint.ChargingStation != null)
                            ? $"ST{s.ChargingPort.ChargingPoint.ChargingStation.Id:D2}-{s.StartTime:yyyyMMdd}-{s.Id:D4}"
                            : $"ST-UNKNOWN-{s.StartTime:yyyyMMdd}-{s.Id:D4}",
                        CustomerId = customerId,
                        PortInfo = new ChargingPortInfoDto
                        {
                            Id = s.ChargingPort != null ? s.ChargingPort.Id : string.Empty,
                            ConnectorName = s.ChargingPort?.Connector?.Name ?? string.Empty,
                            Power = s.ChargingPort?.Power ?? 0,
                            Status = s.ChargingPort != null ? s.ChargingPort.Status.ToString() : string.Empty,
                            ChargingPointId = s.ChargingPort?.ChargingPoint?.Id ?? string.Empty,
                            ChargingStationName = s.ChargingPort?.ChargingPoint?.ChargingStation?.Name ?? string.Empty,
                        },
                        StartTimeStr = $"{s.StartTime:dd/MM/yyyy}, {s.StartTime:HH:mm:ss}",
                        StartTime = s.StartTime.ToString(),
                        EndTimeStr = endTimeStr,
                        EndTime = endTime,
                        Duration = duration,
                        EnergyConsumed = s.EnergyConsumed,
                        TotalCost = s.TotalCost,
                        Status = s.Status.ToString(),
                    };
                })
                .ToList();

            return Ok(dtos);
        }
    }
}
