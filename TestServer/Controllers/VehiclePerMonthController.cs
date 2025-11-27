using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

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
            var vehiclePerMonths = await db
                .VehiclePerMonths.Include(v => v.Vehicle)
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
            var vehiclePerMonth = await db
                .VehiclePerMonths.Include(v => v.Vehicle)
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

        [HttpPost("{periodId}")]
        public async Task<IActionResult> Create(int periodId)
        {
            var monthlyPeriod = await db.MonthlyPeriods.FindAsync(periodId);
            if (monthlyPeriod == null)
            {
                return NotFound($"Monthly period with ID {periodId} not found.");
            }
            if (monthlyPeriod.Status == Models.PeriodStatus.Closed)
            {
                return BadRequest("Cannot add data to a closed monthly period.");
            }
            // Determine month/year for filtering sessions
            int month = monthlyPeriod.Month;
            int year = monthlyPeriod.Year;

            // Get completed sessions within the given month/year grouped by vehicle
            var sessionsQuery = db.ChargingSessions.Where(s =>
                s.Status == Models.SessionStatus.Completed
                && s.StartTime.Month == month
                && s.StartTime.Year == year
            );

            var grouped = await sessionsQuery
                .GroupBy(s => s.VehicleId)
                .Select(g => new
                {
                    VehicleId = g.Key,
                    TotalSessions = g.Count(),
                    TotalEnergy = g.Sum(x => x.EnergyConsumed),
                    TotalCost = g.Sum(x => x.TotalCost),
                })
                .ToListAsync();

            // Map vehicleId -> aggregate
            var aggregates = grouped.ToDictionary(x => x.VehicleId, x => x);

            // Get all vehicles
            var vehicles = await db.Vehicles.ToListAsync();

            var existing = await db
                .VehiclePerMonths.Where(v => v.PeriodId == periodId)
                .Select(v => v.VehicleId)
                .ToListAsync();

            var toCreate = new List<Models.VehiclePerMonth>();

            foreach (var v in vehicles)
            {
                if (existing.Contains(v.VehicleId))
                    continue; // skip already-existing row for this vehicle/period

                if (aggregates.TryGetValue(v.VehicleId, out var agg))
                {
                    toCreate.Add(
                        new Models.VehiclePerMonth
                        {
                            VehicleId = v.VehicleId,
                            PeriodId = periodId,
                            TotalSessions = agg.TotalSessions,
                            TotalEnergy = agg.TotalEnergy,
                            TotalCost = agg.TotalCost,
                            AmountPaid = 0,
                        }
                    );
                }
            }

            if (!toCreate.Any())
            {
                return Ok(
                    new { Message = "No new VehiclePerMonth rows to create for this period." }
                );
            }

            //Update close status of the period
            monthlyPeriod.Status = Models.PeriodStatus.Closed;

            await db.VehiclePerMonths.AddRangeAsync(toCreate);

            await db.SaveChangesAsync();

            // Return created count and list of created ids
            var createdDtos = toCreate.Select(t => new VehiclePerMonthDto
            {
                Id = t.VehicleMonthId,
                VehicleId = t.VehicleId,
                LicensePlate =
                    vehicles.FirstOrDefault(x => x.VehicleId == t.VehicleId)?.LicensePlate
                    ?? string.Empty,
                Month = month,
                Year = year,
                TotalSessions = t.TotalSessions,
                TotalEnergy = t.TotalEnergy,
                TotalCost = t.TotalCost,
                AmountPaid = t.AmountPaid,
            });

            return CreatedAtAction(nameof(GetAll), createdDtos);
        }

        [HttpPut("checkexpired/{periodId}")]
        public async Task<IActionResult> CheckExpiredPeriod(int periodId)
        {
            var monthlyPeriod = await db.MonthlyPeriods.FindAsync(periodId);
            if (monthlyPeriod == null)
            {
                return NotFound($"Monthly period with ID {periodId} not found.");
            }
            if (monthlyPeriod.Status == PeriodStatus.Open)
            {
                return BadRequest("Monthly period is not generated.");
            }

            //Block all vehicle that have not paid full amount unitl day 15 of next month
            var vehicleMonths = await db
                .VehiclePerMonths.Where(v => v.PeriodId == periodId && v.AmountPaid < v.TotalCost)
                .ToListAsync();

            foreach (var vm in vehicleMonths)
            {
                // Implement blocking logic here
                var vehicle = await db.Vehicles.FindAsync(vm.VehicleId);
                if (vehicle != null)
                {
                    vehicle.Status = VehicleStatus.Blocked;
                }
            }
            await db.SaveChangesAsync();
            return Ok(new { Message = $"Expired period {periodId} has been processed." });
        }
    }
}
