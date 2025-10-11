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

        // POST api/vehicle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleDto vehicleDto)
        {
            if (vehicleDto == null) 
                return BadRequest("Vehicle data is required.");

            if (string.IsNullOrWhiteSpace(vehicleDto.Name) || 
                string.IsNullOrWhiteSpace(vehicleDto.LicensePlate) ||
                string.IsNullOrWhiteSpace(vehicleDto.CustomerId))
                return BadRequest("Name, LicensePlate, and CustomerId are required.");

            // Check if license plate already exists
            var existingVehicle = await db.Vehicles
                .FirstOrDefaultAsync(v => v.LicensePlate == vehicleDto.LicensePlate);
            if (existingVehicle != null)
                return BadRequest($"Vehicle with license plate '{vehicleDto.LicensePlate}' already exists.");

            // Find VehicleType by name
            var vehicleType = await db.VehicleTypes
                .FirstOrDefaultAsync(vt => vt.Name == vehicleDto.VehicleType);
            if (vehicleType == null)
                return BadRequest($"VehicleType '{vehicleDto.VehicleType}' not found.");

            // Parse status
            if (!Enum.TryParse<VehicleStatus>(vehicleDto.Status, true, out var status))
                status = VehicleStatus.Active;

            // Create Vehicle entity
            var vehicle = new Vehicle
            {
                CustomerId = vehicleDto.CustomerId,
                Name = vehicleDto.Name,
                LicensePlate = vehicleDto.LicensePlate,
                BatteryCapacity = vehicleDto.BatteryCapacity,
                VehicleTypeId = vehicleType.Id,
                Status = status,
                VehiclePorts = new List<VehiclePort>()
            };

            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();

            // Handle connector assignments if provided
            if (vehicleDto.ConnectorNames != null && vehicleDto.ConnectorNames.Any())
            {
                var connectors = await db.Connectors
                    .Where(c => vehicleDto.ConnectorNames.Contains(c.Name))
                    .ToListAsync();

                foreach (var connector in connectors)
                {
                    var vehiclePort = new VehiclePort
                    {
                        VehicleId = vehicle.VehicleId,
                        ConnectorId = connector.Id
                    };
                    db.VehiclePorts.Add(vehiclePort);
                }

                await db.SaveChangesAsync();
            }

            // Load the created vehicle with all related data for the response
            var createdVehicle = await db.Vehicles
                .Include(v => v.VehicleType)
                .Include(v => v.VehiclePorts)
                .ThenInclude(vp => vp.Connector)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicle.VehicleId);

            // Return the created vehicle as DTO
            var createdVehicleDto = new VehicleDto
            {
                VehicleId = createdVehicle!.VehicleId,
                CustomerId = createdVehicle.CustomerId,
                Name = createdVehicle.Name,
                LicensePlate = createdVehicle.LicensePlate,
                BatteryCapacity = createdVehicle.BatteryCapacity,
                VehicleType = createdVehicle.VehicleType!.Name,
                Status = createdVehicle.Status.ToString(),
                ConnectorNames = createdVehicle.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            };

            return CreatedAtAction(nameof(GetById), new { id = vehicle.VehicleId }, createdVehicleDto);
        }

        // PUT api/vehicle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleDto vehicleDto)
        {
            if (vehicleDto == null) 
                return BadRequest("Vehicle data is required.");

            if (string.IsNullOrWhiteSpace(vehicleDto.Name) || 
                string.IsNullOrWhiteSpace(vehicleDto.LicensePlate) ||
                string.IsNullOrWhiteSpace(vehicleDto.CustomerId))
                return BadRequest("Name, LicensePlate, and CustomerId are required.");

            var existingVehicle = await db.Vehicles
                .Include(v => v.VehiclePorts)
                .FirstOrDefaultAsync(v => v.VehicleId == id);
            
            if (existingVehicle == null) 
                return NotFound($"Vehicle with ID {id} not found.");

            // Check if license plate is being changed and if it conflicts with another vehicle
            if (existingVehicle.LicensePlate != vehicleDto.LicensePlate)
            {
                var conflictingVehicle = await db.Vehicles
                    .FirstOrDefaultAsync(v => v.LicensePlate == vehicleDto.LicensePlate && v.VehicleId != id);
                if (conflictingVehicle != null)
                    return BadRequest($"Vehicle with license plate '{vehicleDto.LicensePlate}' already exists.");
            }

            // Find VehicleType by name
            var vehicleType = await db.VehicleTypes
                .FirstOrDefaultAsync(vt => vt.Name == vehicleDto.VehicleType);
            if (vehicleType == null)
                return BadRequest($"VehicleType '{vehicleDto.VehicleType}' not found.");

            // Parse status
            if (!Enum.TryParse<VehicleStatus>(vehicleDto.Status, true, out var status))
                return BadRequest($"Invalid status '{vehicleDto.Status}'.");

            // Update vehicle properties
            existingVehicle.CustomerId = vehicleDto.CustomerId;
            existingVehicle.Name = vehicleDto.Name;
            existingVehicle.LicensePlate = vehicleDto.LicensePlate;
            existingVehicle.BatteryCapacity = vehicleDto.BatteryCapacity;
            existingVehicle.VehicleTypeId = vehicleType.Id;
            existingVehicle.Status = status;

            // Update connector assignments if provided
            if (vehicleDto.ConnectorNames != null)
            {
                // Remove existing vehicle ports
                var existingPorts = existingVehicle.VehiclePorts.ToList();
                db.VehiclePorts.RemoveRange(existingPorts);

                // Add new vehicle ports if any connectors specified
                if (vehicleDto.ConnectorNames.Any())
                {
                    var connectors = await db.Connectors
                        .Where(c => vehicleDto.ConnectorNames.Contains(c.Name))
                        .ToListAsync();

                    foreach (var connector in connectors)
                    {
                        var vehiclePort = new VehiclePort
                        {
                            VehicleId = existingVehicle.VehicleId,
                            ConnectorId = connector.Id
                        };
                        db.VehiclePorts.Add(vehiclePort);
                    }
                }
            }

            await db.SaveChangesAsync();

            // Load updated vehicle with all related data for the response
            var updatedVehicle = await db.Vehicles
                .Include(v => v.VehicleType)
                .Include(v => v.VehiclePorts)
                .ThenInclude(vp => vp.Connector)
                .FirstOrDefaultAsync(v => v.VehicleId == id);

            // Return the updated vehicle as DTO
            var updatedVehicleDto = new VehicleDto
            {
                VehicleId = updatedVehicle!.VehicleId,
                CustomerId = updatedVehicle.CustomerId,
                Name = updatedVehicle.Name,
                LicensePlate = updatedVehicle.LicensePlate,
                BatteryCapacity = updatedVehicle.BatteryCapacity,
                VehicleType = updatedVehicle.VehicleType!.Name,
                Status = updatedVehicle.Status.ToString(),
                ConnectorNames = updatedVehicle.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
            };

            return Ok(updatedVehicleDto);
        }

        // DELETE api/vehicle/
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid vehicle ID.");

            try
            {
                var vehicle = await db.Vehicles
                    .Include(v => v.VehiclePorts)
                        .ThenInclude(vp => vp.Connector)
                    .Include(v => v.VehicleType)
                    .FirstOrDefaultAsync(v => v.VehicleId == id);

                if (vehicle == null) 
                    return NotFound($"Vehicle with ID {id} not found.");

                // Check if vehicle has active charging sessions
                var activeSession = await db.ChargingSessions
                    .FirstOrDefaultAsync(cs => cs.VehicleId == id && cs.Status == SessionStatus.charging);
                
                if (activeSession != null)
                    return BadRequest("Cannot delete vehicle with active charging session. Please stop the charging session first.");

                // Create a DTO of the vehicle being deleted for response (before deletion)
                var deletedVehicleDto = new VehicleDto
                {
                    VehicleId = vehicle.VehicleId,
                    CustomerId = vehicle.CustomerId ?? string.Empty,
                    Name = vehicle.Name ?? string.Empty,
                    LicensePlate = vehicle.LicensePlate ?? string.Empty,
                    BatteryCapacity = vehicle.BatteryCapacity,
                    VehicleType = vehicle.VehicleType?.Name ?? "Unknown",
                    Status = vehicle.Status.ToString(),
                    ConnectorNames = vehicle.VehiclePorts?.Where(vp => vp.Connector != null)
                        .Select(vp => vp.Connector.Name).ToList() ?? new List<string>()
                };

                // Remove related VehiclePorts first (if not handled by cascade delete)
                if (vehicle.VehiclePorts?.Any() == true)
                {
                    db.VehiclePorts.RemoveRange(vehicle.VehiclePorts);
                }

                // Remove VehiclePerMonth records
                var vehiclePerMonths = await db.VehiclePerMonths
                    .Where(vpm => vpm.VehicleId == id)
                    .ToListAsync();
                
                if (vehiclePerMonths.Any())
                {
                    db.VehiclePerMonths.RemoveRange(vehiclePerMonths);
                }

                // Remove the vehicle
                db.Vehicles.Remove(vehicle);
                await db.SaveChangesAsync();

                // Return deleted vehicle info
                return Ok(new { 
                    message = "Vehicle deleted successfully", 
                    deletedVehicle = deletedVehicleDto 
                });
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use proper logging)
                return StatusCode(500, $"Error deleting vehicle: {ex.Message}");
            }
        }
    }
}
