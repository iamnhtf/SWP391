using Microsoft.AspNetCore.Mvc;
using TestServer.Data;
using TestServer.Dto;
using TestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleConnectorTypeController : ControllerBase
    {
        private readonly AppDbContext db;

        public VehicleConnectorTypeController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicleConnectorTypes = await db.VehicleConnectorTypes
            .Include(vct => vct.Vehicle)
            .Include(vct => vct.Connector)
            .ToListAsync();

            var vehicleConnectorTypeDtos = vehicleConnectorTypes.Select(vct => new VehicleConnectorTypeDto
        {
            VehicleId = vct.VehicleId,
            VehicleName = vct.Vehicle.Name,
            ConnectorId = vct.ConnectorId,
            ConnectorName = vct.Connector.Name
        }).ToList();

        return Ok(vehicleConnectorTypeDtos);
        }
    }
}