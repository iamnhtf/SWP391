using Microsoft.AspNetCore.Mvc;
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
            return await db.VehicleTypes.ToListAsync();
        }
    }

    

}