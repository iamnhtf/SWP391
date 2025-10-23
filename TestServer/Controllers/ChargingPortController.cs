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
            var ports = await db.ChargingPorts.Include(p => p.Connector).ToListAsync();

            var portDtos = ports
                .Select(p => new ChargingPortDto
                {
                    Id = p.Id,
                    ConnectorName = p.Connector.Name,
                    Power = p.Power,
                    Status = p.Status.ToString(),
                })
                .ToList();

            return Ok(portDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var port = await db
                .ChargingPorts.Include(p => p.Connector)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (port == null)
                return NotFound($"Charging port with ID {id} not found.");

            var portDto = new ChargingPortDto
            {
                Id = port.Id,
                ConnectorName = port.Connector.Name,
                Power = port.Power,
                Status = port.Status.ToString(),
            };

            return Ok(portDto);
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetInfo(string id)
        {
            var port = await db
                .ChargingPorts.Include(p => p.Connector)
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

        [HttpPut]
        public async Task<IActionResult> UpdatePort([FromBody] ChargingPortDto portDto)
        {
            var port = await db.ChargingPorts.FirstOrDefaultAsync(p => p.Id == portDto.Id);

            if (port == null)
                return NotFound(new { message = $"Charging port with ID {portDto.Id} not found." });

            port.Power = portDto.Power;

            var point = await db.ChargingPoints.FirstOrDefaultAsync(p => p.Id == port.PointId);
            if (point != null)
            {
                var station = await db.ChargingStations.FirstOrDefaultAsync(s => s.Id == point.StationId);

                if (station != null)
                {
                    if (port.Power == 0)
                    {
                        port.Status = Models.ChargingPortStatus.Inactive;

                        bool allInactive = true;

                        foreach (var p in point.ChargingPorts)
                        {
                            if (p.Status != Models.ChargingPortStatus.Inactive)
                            {
                                allInactive = false;
                                break;
                            }
                        }

                        if (allInactive)    
                            point.Status = Models.ChargingPointStatus.Inactive;
                    }
                    else 
                    {
                        port.Status = Models.ChargingPortStatus.Available;
                        point.Status = Models.ChargingPointStatus.Active;
                        station.Status = Models.ChargingStationStatus.Active;
                    }
                }
            }

            await db.SaveChangesAsync();

            return Ok(new { message = $"Charging port {portDto.Id} activated successfully." });
        }
    }
}
