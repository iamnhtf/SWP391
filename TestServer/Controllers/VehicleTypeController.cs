using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly AppDbContext db;

        public VehicleTypeController(AppDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.VehicleTypes.ToListAsync());
        }
    }
}