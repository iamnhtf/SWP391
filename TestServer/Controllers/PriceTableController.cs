using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

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
            var priceTable = await db
                .PriceTables.Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.PricePerKWh,
                    p.PenaltyFeePerMinute,
                    ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd HH:mm:ss"),
                    ValidTo = p.ValidTo.ToString("yyyy-MM-dd HH:mm:ss"),
                })
                .FirstOrDefaultAsync();

            if (priceTable == null)
                return NotFound(new { message = $"PriceTable with ID {id} not found." });

            return Ok(priceTable);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var activePriceTables = await db
                .PriceTables.Where(p => p.ValidFrom <= DateTime.Now && p.ValidTo >= DateTime.Now)
                .Where(p => p.Status == PriceTableStatus.Active)
                .Select(p => new
                {
                    p.Id,
                    p.PricePerKWh,
                    p.PenaltyFeePerMinute,
                    ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd"),
                    ValidTo = p.ValidTo.ToString("yyyy-MM-dd"),
                })
                .FirstOrDefaultAsync();

            return Ok(activePriceTables);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PriceTableDto priceTableDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var priceTable = new PriceTable
            {
                PricePerKWh = priceTableDto.PricePerKWh,
                PenaltyFeePerMinute = priceTableDto.PenaltyFeePerMinute,
                ValidFrom = priceTableDto.ValidFrom,
                ValidTo = priceTableDto.ValidTo,
                Status = PriceTableStatus.Inactive // default to Inactive on create
            };

            db.PriceTables.Add(priceTable);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = priceTable.Id }, priceTable);
        }

        // Activate a price table by id and deactivate all others
        [HttpPost("activate/{id:int}")]
        public async Task<IActionResult> Activate(int id)
        {
            var target = await db.PriceTables.FirstOrDefaultAsync(p => p.Id == id);
            if (target == null)
                return NotFound(new { message = $"PriceTable with ID {id} not found." });

            // deactivate any currently active price tables
            var actives = await db.PriceTables.Where(p => p.Status == PriceTableStatus.Active && p.Id != id).ToListAsync();
            foreach (var a in actives)
            {
                a.Status = PriceTableStatus.Inactive;
            }

            // activate target
            target.Status = PriceTableStatus.Active;

            await db.SaveChangesAsync();

            return Ok(new { message = $"PriceTable {id} activated." });
        }
    }
}
