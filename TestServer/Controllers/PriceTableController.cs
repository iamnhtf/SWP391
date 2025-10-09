using Microsoft.AspNetCore.Mvc;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceTableController : ControllerBase
    {
        private readonly AppDbContext db;

        public PriceTableController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.PriceTables.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
             var priceTable = await db.PriceTables
            .Where(p => p.Id == id)
            .Select(p => new {
                p.Id,
                p.PricePerKWh,
                p.PenaltyFeePerMinute,
                ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd HH:mm:ss"),
                ValidTo = p.ValidTo.ToString("yyyy-MM-dd HH:mm:ss")
            })
            .FirstOrDefaultAsync();

            if (priceTable == null)
            return NotFound(new { message = $"PriceTable with ID {id} not found." });

            return Ok(priceTable);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var activePriceTables = await db.PriceTables
            .Where(p => p.ValidFrom <= DateTime.Now && p.ValidTo >= DateTime.Now)
            .Where(p => p.Status == PriceTableStatus.Active)
            .Select(p => new
        {
            p.Id,
            p.PricePerKWh,
            p.PenaltyFeePerMinute,
            ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd"),
            ValidTo = p.ValidTo.ToString("yyyy-MM-dd")
        })
            .FirstOrDefaultAsync();

            return Ok(activePriceTables);
        }
    }
}