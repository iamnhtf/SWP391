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
            var points = await db
                .ChargingPoints.Include(p => p.ChargingStation)
                .Include(p => p.ChargingPorts)
                .ThenInclude(port => port.Connector)
                .ToListAsync();

            var pointDtos = points
                .Select(p => new ChargingPointDto
                {
                    Id = p.Id,
                    Ports = p
                        .ChargingPorts.Select(port => new ChargingPortDto
                        {
                            Id = port.Id,
                            ConnectorName = port.Connector.Name,
                            Power = port.Power,
                            Status = port.Status.ToString(),
                        })
                        .ToList(),
                })
                .ToList();

            return Ok(pointDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var point = await db
                .ChargingPoints.Include(p => p.ChargingStation)
                .Include(p => p.ChargingPorts)
                .ThenInclude(port => port.Connector)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (point == null)
                return NotFound($"Charging point with ID {id} not found.");

            var pointDto = new ChargingPointDto
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
            };

            return Ok(pointDto);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreatePoint(string id)
        {
            // if point exists, return conflict
            var existing = await db.ChargingPoints.FindAsync(id);
            if (existing != null)
                return Conflict(new { message = $"Charging point with ID {id} already exists." });

            int stationId = Int32.Parse(id.Split('.')[0]);

            var point = new Models.ChargingPoint
            {
                Id = id,
                StationId = stationId,
                Status = Models.ChargingPointStatus.Inactive
            };

            // connector ids seeded in AppDbContext: 1=AC, 2=CCS, 3=CHAdeMO
            var ports = new List<Models.ChargingPort>
            {
                new Models.ChargingPort { Id = id + ".1", PointId = id, ConnectorId = 1, Power = 0, Status = Models.ChargingPortStatus.Inactive },
                new Models.ChargingPort { Id = id + ".2", PointId = id, ConnectorId = 2, Power = 0, Status = Models.ChargingPortStatus.Inactive },
                new Models.ChargingPort { Id = id + ".3", PointId = id, ConnectorId = 3, Power = 0, Status = Models.ChargingPortStatus.Inactive }
            };

            point.ChargingPorts = ports;

            db.ChargingPoints.Add(point);
            await db.SaveChangesAsync();

            var pointDto = new ChargingPointDto
            {
                Id = point.Id,
                Ports = point.ChargingPorts.Select(port => new ChargingPortDto
                {
                    Id = port.Id,
                    ConnectorName = db.Connectors.First(c => c.Id == port.ConnectorId).Name,
                    Power = port.Power,
                    Status = port.Status.ToString()
                }).ToList()
            };

            return Ok(new { message = $"Charging point {id} created successfully.", data = pointDto });
        }


        [HttpPut("stop/{id}")]
        public async Task<IActionResult> DeactivatePoint(string id)
        {
            var point = await db.ChargingPoints
                .Include(p => p.ChargingPorts)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (point == null)
                return NotFound(new { message = $"Charging point with ID {id} not found." });

            foreach (var port in point.ChargingPorts)
            {
                port.Status = Models.ChargingPortStatus.Inactive;
            }

            point.Status = Models.ChargingPointStatus.Inactive;

            await db.SaveChangesAsync();

            return Ok(new { message = $"Charging point {id} deactivated (ports set to Inactive)." });
        }
    }
}
