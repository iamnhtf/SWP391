using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectorController : ControllerBase
    {
        private readonly AppDbContext db;

        public ConnectorController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var connectors = await db.Connectors.ToListAsync();

            var connectorDtos = connectors.Select(c => new ConnectorTypeDto
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status.ToString()
            });

            return Ok(connectorDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConnectorTypeDto connector)
        {
            var newConnector = new Connector
            {
                Name = connector.Name,
                Status = Enum.Parse<ConnectorTypeStatus>(connector.Status)
            };

            db.Connectors.Add(newConnector);
            await db.SaveChangesAsync();
            return Ok(newConnector);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ConnectorTypeDto connector)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingConnector = await db.Connectors.FindAsync(id);
            if (existingConnector == null)
                return NotFound($"Connector with ID {id} not found.");

            existingConnector.Name = connector.Name;
            existingConnector.Status = Enum.Parse<ConnectorTypeStatus>(connector.Status);

            db.Connectors.Update(existingConnector);
            await db.SaveChangesAsync();

            return Ok(existingConnector);
        }
        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var connector = await db.Connectors.FindAsync(id);
            if (connector == null)
                return NotFound($"Connector with ID {id} not found.");

            return Ok(new { connector.Id, Status = connector.Status.ToString() });
        }
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var connector = await db.Connectors.FindAsync(id);
            if (connector == null)
                return NotFound($"Connector with ID {id} not found.");

            connector.Status = Enum.Parse<ConnectorTypeStatus>(status);
            db.Connectors.Update(connector);
            await db.SaveChangesAsync();

            return Ok(new { connector.Id, connector.Status });
        }
        

    }
}