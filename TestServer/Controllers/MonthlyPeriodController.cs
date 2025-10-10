using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyPeriodController : ControllerBase
    {
        private readonly AppDbContext db;

        public MonthlyPeriodController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var monthlyPeriods = await db.MonthlyPeriods.ToListAsync();
            return Ok(monthlyPeriods);
        }
    }

}