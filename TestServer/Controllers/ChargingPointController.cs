using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingPointController : ControllerBase
    {
        private readonly AppDbContext db;

        public ChargingPointController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var points = await db.ChargingPoints
                .Include(p => p.ChargingStation)
                .Include(p => p.ChargingPorts)
                    .ThenInclude(port => port.Connector)
                .ToListAsync();

            var pointDtos = points.Select(p => new ChargingPointDto
            {
                Id = p.Id,
                Ports = p.ChargingPorts.Select(port => new ChargingPortDto
                {
                    Id = port.Id,
                    ConnectorName = port.Connector.Name,
                    Power = port.Power,
                    Status = port.Status.ToString()
                }).ToList()
            }).ToList();

            return Ok(pointDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var point = await db.ChargingPoints
            .Include(p => p.ChargingStation)
            .Include(p => p.ChargingPorts)
                .ThenInclude(port => port.Connector)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (point == null)
                return NotFound($"Charging point with ID {id} not found.");

            var pointDto = new ChargingPointDto
            {
                Id = point.Id,
                Ports = point.ChargingPorts.Select(port => new ChargingPortDto
                {
                    Id = port.Id,
                    ConnectorName = port.Connector.Name,
                    Power = port.Power,
                    Status = port.Status.ToString()
                }).ToList()
            };

            return Ok(pointDto);
        }
    }
}