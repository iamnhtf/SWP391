using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationController : ControllerBase
    {
        private readonly AppDbContext db;

        public ChargingStationController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stations = await db
                .ChargingStations.Select(station => new
                {
                    station.Id,
                    station.Name,
                    station.Location,
                    station.Latitude,
                    station.Longitude,
                    station.Status,
                })
                .ToListAsync();

            return Ok(stations);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var station = await db
                .ChargingStations.Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Location,
                    s.Latitude,
                    s.Longitude,
                    s.Status,
                })
                .FirstOrDefaultAsync();

            return station != null
                ? Ok(station)
                : NotFound($"Charging station with ID {id} not found.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNested()
        {
            var stations = await db
                .ChargingStations.Include(station => station.ChargingPoints)
                .ThenInclude(point => point.ChargingPorts)
                .ThenInclude(port => port.Connector)
                .ToListAsync();

            var stationDtos = stations
                .Select(station => new ChargingStationDto
                {
                    Id = station.Id,
                    Name = station.Name,
                    Location = station.Location,
                    Latitude = station.Latitude,
                    Longitude = station.Longitude,
                    Status = station.Status.ToString(),
                    Points = station
                        .ChargingPoints.Select(point => new ChargingPointDto
                        {
                            Id = point.Id,
                            Status = point.Status.ToString(),
                            Ports = point
                                .ChargingPorts.Select(port => new ChargingPortDto
                                {
                                    Id = port.Id,
                                    ConnectorName = port.Connector.Name,
                                    Power = port.Power,
                                    Status = port.Status.ToString(),
                                })
                                .ToList(),
                        })
                        .ToList(),
                })
                .ToList();

            return Ok(stationDtos);
        }

        [HttpGet("all/{name}")]
        public async Task<IActionResult> GetAllNestedByName(string name)
        {
            var stations = await db
                .ChargingStations.Where(s =>
                    s.Name.ToLower().Contains(name.ToLower())
                    || s.Location.ToLower().Contains(name.ToLower())
                )
                .Include(station => station.ChargingPoints)
                .ThenInclude(point => point.ChargingPorts)
                .ThenInclude(port => port.Connector)
                .ToListAsync();

            var stationDtos = stations
                .Select(station => new ChargingStationDto
                {
                    Id = station.Id,
                    Name = station.Name,
                    Location = station.Location,
                    Latitude = station.Latitude,
                    Longitude = station.Longitude,
                    Points = station
                        .ChargingPoints.Select(point => new ChargingPointDto
                        {
                            Id = point.Id,
                            Ports = point
                                .ChargingPorts.Select(port => new ChargingPortDto
                                {
                                    Id = port.Id,
                                    ConnectorName = port.Connector.Name,
                                    Power = port.Power,
                                    Status = port.Status.ToString(),
                                })
                                .ToList(),
                        })
                        .ToList(),
                })
                .ToList();

            return Ok(stationDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChargingStationDto stationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var station = new ChargingStation
            {
                Id = stationDto.Id,
                Name = stationDto.Name,
                Location = stationDto.Location,
                Latitude = stationDto.Latitude,
                Longitude = stationDto.Longitude,
                Status = ChargingStationStatus.Inactive,
            };

            db.ChargingStations.Add(station);
            await db.SaveChangesAsync();

            return Ok(station);
        }
        // Deactivate station and cascade: all points -> deactivated, all ports -> Faulty/Unavailable (or custom 'Deactive')
        // POST api/ChargingStation/stop/{id}
        [HttpPut("stop/{id:int}")]
        public async Task<IActionResult> DeactivateStation(int id)
        {
            var station = await db.ChargingStations
                .Include(s => s.ChargingPoints)
                .ThenInclude(p => p.ChargingPorts)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (station == null)
                return NotFound(new { message = $"Charging station with ID {id} not found." });

            // Here we interpret "deactivate station" as marking ports as Faulty (or you can add a new status Deactive)
            foreach (var point in station.ChargingPoints)
            {
                // if you have a ChargingPoint status field, set it here (not present in model)
                foreach (var port in point.ChargingPorts)
                {
                    // Set port to Inactive to indicate unavailable
                    port.Status = ChargingPortStatus.Inactive;
                }

                point.Status = ChargingPointStatus.Inactive;
            }

            await db.SaveChangesAsync();

            return Ok(new { message = $"Charging station {id} deactivated (ports set to Inactive)." });
        }

        // Activate station: set ports to Available and any point-level status to active
        // POST api/ChargingStation/start/{id}
        [HttpPost("start/{id:int}")]
        public async Task<IActionResult> ActivateStation(int id)
        {
            var station = await db.ChargingStations
                .Include(s => s.ChargingPoints)
                .ThenInclude(p => p.ChargingPorts)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (station == null)
                return NotFound(new { message = $"Charging station with ID {id} not found." });

            foreach (var point in station.ChargingPoints)
            {
                bool allInactive = true;

                foreach (var port in point.ChargingPorts)
                {
                    if (port.Power != 0)
                    {
                        allInactive = false;
                        port.Status = ChargingPortStatus.Available;
                    }
                    else
                    {
                        port.Status = ChargingPortStatus.Inactive;
                    }
                }
                if (allInactive == false)
                {
                    point.Status = ChargingPointStatus.Active;
                }
                else
                {
                    point.Status = ChargingPointStatus.Inactive;
                }
            }

            await db.SaveChangesAsync();

            return Ok(new { message = $"Charging station {id} activated (ports set to Available)." });
        }
    }
}
