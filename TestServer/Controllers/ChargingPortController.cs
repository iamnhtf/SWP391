using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingPortController : ControllerBase
    {
        private readonly AppDbContext db;

        public ChargingPortController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ports = await db.ChargingPorts
            .Include(p => p.Connector)
            .ToListAsync();

            var portDtos = ports.Select(p => new ChargingPortDto
            {
                Id = p.Id,
                ConnectorName = p.Connector.Name,
                Power = p.Power,
                Status = p.Status.ToString()
            }).ToList();

            return Ok(portDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var port = await db.ChargingPorts
            .Include(p => p.Connector)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (port == null)
                return NotFound($"Charging port with ID {id} not found.");

            var portDto = new ChargingPortDto
            {
                Id = port.Id,
                ConnectorName = port.Connector.Name,
                Power = port.Power,
                Status = port.Status.ToString()
            };

            return Ok(portDto);
        }
        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetInfo(string id)
        {
             var port = await db.ChargingPorts
            .Include(p => p.Connector)
            .Include(p => p.ChargingPoint)
            .ThenInclude(cp => cp.ChargingStation)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (port == null)
                return NotFound($"Charging port with ID {id} not found.");

            var portInfoDto = new ChargingPortInfoDto
            {
                Id = port.Id,
                ConnectorName = port.Connector.Name,
                Power = port.Power,
                Status = port.Status.ToString(),
                ChargingPointId = port.ChargingPoint.Id,
                ChargingStationName = port.ChargingPoint.ChargingStation.Name,

            };

            return Ok(portInfoDto);
        }
    }
}