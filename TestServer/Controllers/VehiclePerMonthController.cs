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
            var vehiclePerMonths = await db.VehiclePerMonths
                .Include(v => v.Vehicle)
                .Include(v => v.MonthlyPeriod)
                .ToListAsync();
            var dtos = vehiclePerMonths.Select(v => new VehiclePerMonthDto
            {
                Id = v.VehicleMonthId,
                VehicleId = v.VehicleId,
                LicensePlate = v.Vehicle.LicensePlate,
                Month = v.MonthlyPeriod.Month,
                Year = v.MonthlyPeriod.Year,
                TotalSessions = v.TotalSessions,
                TotalEnergy = v.TotalEnergy,
                TotalCost = v.TotalCost,
                AmountPaid = v.AmountPaid,               
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiclePerMonth = await db.VehiclePerMonths.
                Include(v => v.Vehicle)
                .Include(v => v.MonthlyPeriod)
                .FirstOrDefaultAsync(v => v.VehicleMonthId == id);
            if (vehiclePerMonth == null)
            {
                return NotFound();
            }
            var dto = new VehiclePerMonthDto
            {
                Id = vehiclePerMonth.VehicleMonthId,
                VehicleId = vehiclePerMonth.VehicleId,
                Month = vehiclePerMonth.MonthlyPeriod.Month,
                Year = vehiclePerMonth.MonthlyPeriod.Year,
                TotalSessions = vehiclePerMonth.TotalSessions,
                TotalEnergy = vehiclePerMonth.TotalEnergy,
                TotalCost = vehiclePerMonth.TotalCost,
                AmountPaid = vehiclePerMonth.AmountPaid,
                LicensePlate = vehiclePerMonth.Vehicle.LicensePlate,
            };
            return Ok(dto);
        }

        [HttpGet("forcustomer/{customerId}")]
        public async Task<IActionResult> GetForCustomer(string customerId)
        {
            var vehiclePerMonth = await db
                .VehiclePerMonths.Include(v => v.Vehicle)
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
                LicensePlate = v.Vehicle.LicensePlate,
                Month = v.MonthlyPeriod.Month,
                Year = v.MonthlyPeriod.Year,
                TotalSessions = v.TotalSessions,
                TotalEnergy = v.TotalEnergy,
                TotalCost = v.TotalCost,
                AmountPaid = v.AmountPaid,
            });

            return Ok(result);
        }
    }
}
