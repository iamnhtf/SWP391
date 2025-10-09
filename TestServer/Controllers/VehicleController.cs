using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Dto;

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
    }
}
