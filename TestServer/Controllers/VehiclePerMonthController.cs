using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclePerMonthController : ControllerBase
    {
        private readonly AppDbContext db;

        public VehiclePerMonthController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiclePerMonth = await db.VehiclePerMonths.ToListAsync();
            return Ok(vehiclePerMonth);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiclePerMonth = await db.VehiclePerMonths.FindAsync(id);
            if (vehiclePerMonth == null)
            {
                return NotFound();
            }
            return Ok(vehiclePerMonth);
        }

        [HttpGet("forcustomer/{customerId}")]
        public async Task<IActionResult> GetForCustomer(string customerId)
        {
            var vehiclePerMonth = await db.VehiclePerMonths
                .Include(v => v.Vehicle)
                .Include(v => v.MonthlyPeriod)
                .Where(v => v.Vehicle.CustomerId == customerId)
                .OrderByDescending(v => v.MonthlyPeriod.Year)
                .ThenByDescending(v => v.MonthlyPeriod.Month)
                .ToListAsync();

            if (!vehiclePerMonth.Any())
            {
                return NotFound($"No vehicle data found for customer: {customerId}");
            }

            var result = vehiclePerMonth.Select(v => new VehiclePerMonthDto
            {
                Id = v.VehicleMonthId,
                VehicleId = v.VehicleId,
                Month = v.MonthlyPeriod.Month,
                Year = v.MonthlyPeriod.Year,
                TotalSessions = v.TotalSessions,
                TotalEnergy = v.TotalEnergy,
                TotalCost = v.TotalCost,
                AmountPaid = v.AmountPaid
            });

            return Ok(result);
        }
    }

}