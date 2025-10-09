using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;

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
            var stations = await db.ChargingStations
                .Select(station => new
                {
                    station.Id,
                    station.Name,
                    station.Location,
                    station.Latitude,
                    station.Longitude
                })
                .ToListAsync();

            return Ok(stations);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var station = await db.ChargingStations
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Location,
                    s.Latitude,
                    s.Longitude
                })
                .FirstOrDefaultAsync();

            return station != null
                ? Ok(station)
                : NotFound($"Charging station with ID {id} not found.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNested()
        {
            var stations = await db.ChargingStations
                .Include(station => station.ChargingPoints)
                    .ThenInclude(point => point.ChargingPorts)
                        .ThenInclude(port => port.Connector)
                .ToListAsync();

            var stationDtos = stations.Select(station => new ChargingStationDto
            {
                Id = station.Id,
                Name = station.Name,
                Location = station.Location,
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                Points = station.ChargingPoints.Select(point => new ChargingPointDto
                {
                    Id = point.Id,
                    Ports = point.ChargingPorts.Select(port => new ChargingPortDto
                    {
                        Id = port.Id,
                        ConnectorName = port.Connector.Name,
                        Power = port.Power,
                        Status = port.Status.ToString()
                    }).ToList()
                }).ToList()
            }).ToList();

            return Ok(stationDtos);
        }

        [HttpGet("all/{name}")]
        public async Task<IActionResult> GetAllNestedByName(string name)
        {
                var stations = await db.ChargingStations
                .Where(s => s.Name.ToLower().Contains(name.ToLower()) || s.Location.ToLower().Contains(name.ToLower()))
                .Include(station => station.ChargingPoints)
                    .ThenInclude(point => point.ChargingPorts)
                        .ThenInclude(port => port.Connector)
                .ToListAsync();

            var stationDtos = stations.Select(station => new ChargingStationDto
            {
                Id = station.Id,
                Name = station.Name,
                Location = station.Location,
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                Points = station.ChargingPoints.Select(point => new ChargingPointDto
                {
                    Id = point.Id,
                    Ports = point.ChargingPorts.Select(port => new ChargingPortDto
                    {
                        Id = port.Id,
                        ConnectorName = port.Connector.Name,
                        Power = port.Power,
                        Status = port.Status.ToString()
                    }).ToList()
                }).ToList()
            }).ToList();

            return Ok(stationDtos);
        }
    }
}