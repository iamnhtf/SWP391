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
            return Ok(await db.Connectors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Connector connector)
        {
            db.Connectors.Add(connector);
            await db.SaveChangesAsync();
            return Ok(connector);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Connector connector)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingConnector = await db.Connectors.FindAsync(id);
            if (existingConnector == null)
                return NotFound($"Connector with ID {id} not found.");

            existingConnector.Name = connector.Name;
            existingConnector.Status = connector.Status;

            db.Connectors.Update(existingConnector);
            await db.SaveChangesAsync();

            return Ok(existingConnector);
        }
    }
}