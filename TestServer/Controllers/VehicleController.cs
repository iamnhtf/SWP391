using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext db;

        public VehicleController(AppDbContext context)
        {
            db = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await db.Vehicles
            .Include(v => v.VehiclePorts)
            .ThenInclude(vp => vp.Connector)
            .Include(v => v.VehicleType)
            .ToListAsync();

            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Name = v.Name,
                LicensePlate = v.LicensePlate,
                BatteryCapacity = v.BatteryCapacity,
                VehicleType = v.VehicleType.Name,
                Status = v.Status.ToString(),
                ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            }).ToList();

            return Ok(vehicleDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await db.Vehicles
            .Include(v => v.VehiclePorts)
            .ThenInclude(vp => vp.Connector)
            .Include(v => v.VehicleType)
            .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
                return NotFound($"Vehicle with ID {id} not found.");

            var vehicleDto = new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                Name = vehicle.Name,
                LicensePlate = vehicle.LicensePlate,
                BatteryCapacity = vehicle.BatteryCapacity,
                VehicleType = vehicle.VehicleType.Name,
                Status = vehicle.Status.ToString(),
                ConnectorNames = vehicle.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            };

            return Ok(vehicleDto);
        }

        [HttpGet("forcustomer/{uid}")]
        public async Task<IActionResult> GetByUserId(string uid)
        {
            var vehicles = await db.Vehicles
            .Where(v => v.CustomerId == uid)
            .Include(v => v.VehiclePorts)
            .ThenInclude(vp => vp.Connector)
            .Include(v => v.VehicleType)
            .ToListAsync();

            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Name = v.Name,
                LicensePlate = v.LicensePlate,
                BatteryCapacity = v.BatteryCapacity,
                VehicleType = v.VehicleType.Name,
                Status = v.Status.ToString(),
                ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            }).ToList();
            return Ok(vehicleDtos);
        }

        [HttpGet("forcustomer/{uid}/{connectorName}")]
        public async Task<IActionResult> GetByUserIdAndConnector(string uid, string connectorName)
        {
            var vehicles = await db.Vehicles
            .Where(v => v.CustomerId == uid &&
                v.VehiclePorts.Any(vp => vp.Connector.Name == connectorName))
            .Include(v => v.VehiclePorts)
            .ThenInclude(vp => vp.Connector)
            .Include(v => v.VehicleType)
            .ToListAsync();

            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Name = v.Name,
                LicensePlate = v.LicensePlate,
                BatteryCapacity = v.BatteryCapacity,
                VehicleType = v.VehicleType.Name,
                Status = v.Status.ToString(),
                ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            }).ToList();

            return Ok(vehicleDtos);
        }
        
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await db.Vehicles
                .Include(v => v.VehiclePorts)
                .ThenInclude(vp => vp.Connector)
                .Include(v => v.VehicleType)
                .AsNoTracking()
                .ToListAsync();

            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Name = v.Name,
                LicensePlate = v.LicensePlate,
                BatteryCapacity = v.BatteryCapacity,
                VehicleType = v.VehicleType?.Name ?? string.Empty,
                Status = v.Status.ToString(),
                ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector?.Name ?? string.Empty)
                                               .Where(n => n != string.Empty).ToList()
            }).ToList();

            return Ok(vehicleDtos);
        }

        // GET api/vehicle/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdVehicle(int id)
        {
            var vehicle = await db.Vehicles
                .Include(v => v.VehiclePorts)
                .ThenInclude(vp => vp.Connector)
                .Include(v => v.VehicleType)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null) return NotFound();

            var vehicleDto = new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                Name = vehicle.Name,
                LicensePlate = vehicle.LicensePlate,
                BatteryCapacity = vehicle.BatteryCapacity,
                VehicleType = vehicle.VehicleType?.Name ?? string.Empty,
                Status = vehicle.Status.ToString(),
                ConnectorNames = vehicle.VehiclePorts.Select(vp => vp.Connector?.Name ?? string.Empty)
                                                    .Where(n => n != string.Empty).ToList()
            };

            return Ok(vehicleDto);
        }

        // POST api/vehicle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            if (vehicle == null) return BadRequest();

            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = vehicle.VehicleId }, vehicle);
        }

        // PUT api/vehicle/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle updatedVehicle)
        {
            if (updatedVehicle == null) return BadRequest();

            var existingVehicle = await db.Vehicles.FindAsync(id);
            if (existingVehicle == null) return NotFound();

            existingVehicle.CustomerId = updatedVehicle.CustomerId;
            existingVehicle.Name = updatedVehicle.Name;
            existingVehicle.LicensePlate = updatedVehicle.LicensePlate;
            existingVehicle.BatteryCapacity = updatedVehicle.BatteryCapacity;
            existingVehicle.VehicleTypeId = updatedVehicle.VehicleTypeId;
            existingVehicle.Status = updatedVehicle.Status;

            await db.SaveChangesAsync();
            return Ok(existingVehicle);
        }

        // DELETE api/vehicle/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null) return NotFound();

            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
