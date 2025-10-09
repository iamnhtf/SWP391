using Microsoft.AspNetCore.Mvc;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclePortController : ControllerBase
    {
        private readonly AppDbContext db;

        public VehiclePortController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiclePorts = await db.VehiclePorts
            .ToListAsync();
            return Ok(vehiclePorts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiclePorts = await db.VehiclePorts
            .Where(vp => vp.VehicleId == id)
            .ToListAsync();

            if (vehiclePorts.Count == 0)
            return NotFound($"No vehicle ports found for Vehicle ID {id}.");

            return Ok(vehiclePorts);
        }
    }
}