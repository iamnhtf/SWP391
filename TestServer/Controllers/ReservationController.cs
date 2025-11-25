using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestServer.Data;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly AppDbContext db;

        public ReservationController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await db.Reservations.ToListAsync();
            return Ok(reservations);
        }

        //Find by customer uid
        [HttpGet("{uid}")]
        public async Task<IActionResult> GetReservationsByCustomer(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return BadRequest("customer uid required.");

            // find reservations where the vehicle belongs to this customer
            var reservations = await db.Reservations
                .AsNoTracking()
                .Where(r => db.Vehicles.Any(v => v.VehicleId == r.VehicleId && v.CustomerId == uid))
                .ToListAsync();

            var result = await Task.WhenAll(reservations.Select(async r =>
            {
                var vehicle = await db.Vehicles.AsNoTracking().FirstOrDefaultAsync(v => v.VehicleId == r.VehicleId);
                var port = await db.ChargingPorts
                    .AsNoTracking()
                    .Include(p => p.Connector)
                    .Include(p => p.ChargingPoint)
                        .ThenInclude(cp => cp.ChargingStation)
                    .FirstOrDefaultAsync(p => p.Id == r.ChargingPortId);

                return new
                {
                    ReservationId = r.ReservationId,
                    VehicleId = r.VehicleId,
                    VehicleName = vehicle?.Name ?? string.Empty,
                    VehicleLicensePlate = vehicle?.LicensePlate ?? string.Empty,
                    PortId = r.ChargingPortId,
                    ConnectorName = port?.Connector?.Name ?? string.Empty,
                    Power = port?.Power ?? 0,
                    ChargingPointId = port?.ChargingPoint?.Id ?? string.Empty,
                    ChargingStationName = port?.ChargingPoint?.ChargingStation?.Name ?? string.Empty,
                    ReservedAt = r.ReservedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    ExpireAt = r.ExpireAt.ToString("yyyy-MM-dd HH:mm:ss")
                };
            }));

            return Ok(result);
        }

        //Get vehicle reservation by uid and portId
        [HttpGet("{uid}/{portId}")]
        public async Task<IActionResult> GetVehicleReservedByCustomerAndPort(string uid, string portId)
        {
            if (string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(portId))
                return BadRequest("customer uid and portId required.");

            var reservation = await db.Reservations
                .AsNoTracking()
                .Where(r => r.ChargingPortId == portId &&
                            db.Vehicles.Any(v => v.VehicleId == r.VehicleId && v.CustomerId == uid))
                .FirstOrDefaultAsync();

            if (reservation == null)
                return NotFound("No reservation found for the given customer and port.");

            var vehicle = await db.Vehicles.AsNoTracking().FirstOrDefaultAsync(v => v.VehicleId == reservation.VehicleId);
            
            return Ok(new { vehicle = vehicle.VehicleId });
        }

        public class CreateReservationRequest
        {
            public int VehicleId { get; set; }
            public string PortId { get; set; } = string.Empty;
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request)
        {
            var port = await db.ChargingPorts.FindAsync(request.PortId);
            if (port == null || port.Status != Models.ChargingPortStatus.Available)
            {
                return BadRequest("Charging port is not available for reservation.");
            }

            var vehicle = await db.Vehicles.FindAsync(request.VehicleId);
            if (vehicle == null || vehicle.Status != Models.VehicleStatus.Active)
            {
                return BadRequest("Vehicle is not eligible for reservation.");
            }

            var reservation = new Models.Reservation
            {
                VehicleId = request.VehicleId,
                ChargingPortId = request.PortId,
                ReservedAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddMinutes(60)
            };

            db.Reservations.Add(reservation);
            port.Status = Models.ChargingPortStatus.Reserved;
            vehicle.Status = Models.VehicleStatus.Reserved;

            await db.SaveChangesAsync();
            return Ok(reservation);
        }
    
        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var reservation = await db.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

            var port = await db.ChargingPorts.FindAsync(reservation.ChargingPortId);
            var vehicle = await db.Vehicles.FindAsync(reservation.VehicleId);

            db.Reservations.Remove(reservation);

            if (port != null && port.Status == Models.ChargingPortStatus.Reserved)
            {
                port.Status = Models.ChargingPortStatus.Available;
            }

            if (vehicle != null && vehicle.Status == Models.VehicleStatus.Reserved)
            {
                vehicle.Status = Models.VehicleStatus.Active;
            }

            await db.SaveChangesAsync();
            return Ok("Reservation deleted successfully.");
        }
    }
}