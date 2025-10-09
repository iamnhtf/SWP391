using Microsoft.AspNetCore.Mvc;
using TestServer.Data;
using Microsoft.EntityFrameworkCore;
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
    }
}