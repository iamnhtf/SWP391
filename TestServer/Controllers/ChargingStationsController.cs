using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingStationsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChargingStationsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stations = await _db.ChargingStations
                .Select(s => new { s.Id, s.Name, s.Location, s.Latitude, s.Longitude })
                .ToListAsync();
            return Ok(stations);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var stations = await _db.ChargingStations
                .Include(s => s.ChargingPoints)
                    .ThenInclude(p => p.ChargingPorts)
                        .ThenInclude(port => port.Connector)
                .ToListAsync();

            var dtos = stations.Select(s => new ChargingStationDto
            {
                Id = s.Id,
                Name = s.Name,
                Location = s.Location,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Points = s.ChargingPoints.Select(p => new ChargingPointDto
                {
                    Id = p.Id,
                    Ports = p.ChargingPorts.Select(port => new ChargingPortDto
                    {
                        Id = port.Id,
                        ConnectorName = port.Connector.Name,
                        Power = port.Power,
                        Status = port.Status.ToString()
                    }).ToList()
                }).ToList()
            });

            return Ok(dtos);
        }

        [HttpGet("all/{name}")]
        public async Task<IActionResult> GetAllByName(string name)
        {
            var stations = await _db.ChargingStations
                .Where(s => s.Name.ToLower().Contains(name.ToLower()) || s.Location.ToLower().Contains(name.ToLower()))
                .Include(s => s.ChargingPoints)
                    .ThenInclude(p => p.ChargingPorts)
                        .ThenInclude(port => port.Connector)
                .ToListAsync();

            var dtos = stations.Select(s => new ChargingStationDto
            {
                Id = s.Id,
                Name = s.Name,
                Location = s.Location,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Points = s.ChargingPoints.Select(p => new ChargingPointDto
                {
                    Id = p.Id,
                    Ports = p.ChargingPorts.Select(port => new ChargingPortDto
                    {
                        Id = port.Id,
                        ConnectorName = port.Connector.Name,
                        Power = port.Power,
                        Status = port.Status.ToString()
                    }).ToList()
                }).ToList()
            });

            return Ok(dtos);
        }
    }
}