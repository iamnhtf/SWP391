// File: Program.cs

// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Package;
using TestServer.Crud;

var builder = WebApplication.CreateBuilder(args);

// 2. Thêm dịch vụ DbContext và đọc chuỗi kết nối
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Please ensure it's configured in appsettings.json or via environment variables.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

// Đăng ký DriverCrud service
builder.Services.AddScoped<DriverCrud>();

// Thêm dịch vụ để phục vụ các file tĩnh
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64; // tăng nếu cần
    });


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Middleware này cần đứng TRƯỚC các mapping khác
app.UseDefaultFiles(); // Tìm các file mặc định như index.html
app.UseStaticFiles();  // Cho phép phục vụ các file tĩnh

// Mapping các endpoint API
// **LƯU Ý**: Không cần app.MapGet("/") ở đây vì index.html đã được phục vụ bởi UseDefaultFiles/UseStaticFiles.

app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// DRIVER CRUD ENDPOINTS
// Get All Drivers
app.MapGet("/drivers", async (DriverCrud driverCrud) =>
{
    var drivers = await driverCrud.GetAllDrivers();
    return Results.Ok(drivers);
});

// Get Driver by ID
app.MapGet("/drivers/{id}", async (int id, DriverCrud driverCrud) =>
{
    if (id <= 0)
    {
        return Results.BadRequest("Driver ID must be a positive integer.");
    }
    
    var driver = await driverCrud.GetDriver(id);
    return driver != null ? Results.Ok(driver) : Results.NotFound($"Driver with ID {id} not found.");
});

// Create Driver
app.MapPost("/drivers", async (Driver driver, DriverCrud driverCrud) =>
{
    try
    {
        var createdDriver = await driverCrud.CreateDriver(driver);
        return Results.Created($"/drivers/{createdDriver.Id}", createdDriver);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error creating driver: {ex.Message}");
    }
});

// Update Driver
app.MapPut("/drivers/{id}", async (int id, Driver driver, DriverCrud driverCrud) =>
{
    if (id <= 0)
    {
        return Results.BadRequest("Driver ID must be a positive integer.");
    }
    
    var updatedDriver = await driverCrud.UpdateDriver(id, driver);
    return updatedDriver != null ? Results.Ok(updatedDriver) : Results.NotFound($"Driver with ID {id} not found.");
});

// Delete Driver
app.MapDelete("/drivers/{id}", async (int id, DriverCrud driverCrud) =>
{
    if (id <= 0)
    {
        return Results.BadRequest("Driver ID must be a positive integer.");
    }
    
    var deleted = await driverCrud.DeleteDriver(id);
    return deleted ? Results.NoContent() : Results.NotFound($"Driver with ID {id} not found.");
});

// Endpoint cho CHARGING STATIONS
// Get all stations (basic info)
app.MapGet("/chargingstations", async (AppDbContext db) =>
{
    var stations = await db.ChargingStations
        .Select(station => new
        {
            station.Id,
            station.Name,
            station.Location,
            station.Latitude,
            station.Longitude
        })
        .ToListAsync();

    return Results.Ok(stations);
});

// Get a specific station by ID
app.MapGet("/chargingstations/{id}", async (int id, AppDbContext db) =>
{
    var station = await db.ChargingStations
        .Where(s => s.Id == id)
        .Select(s => new
        {
            s.Id,
            s.Name,
            s.Location,
            s.Latitude,
            s.Longitude
        })
        .FirstOrDefaultAsync();

    return station != null
        ? Results.Ok(station)
        : Results.NotFound($"Charging station with ID {id} not found.");
});

// Get all stations with full nested structure (points, ports, connectors)
app.MapGet("/allchargingstations", async (AppDbContext db) =>
{
    var stations = await db.ChargingStations
        .Include(station => station.ChargingPoints)
            .ThenInclude(point => point.ChargingPorts)
                .ThenInclude(port => port.Connector)
        .ToListAsync();

    var stationDtos = stations.Select(station => new ChargingStationDto
    {
        Id = station.Id,
        Name = station.Name,
        Location = station.Location,
        Latitude = station.Latitude,
        Longitude = station.Longitude,
        Points = station.ChargingPoints.Select(point => new ChargingPointDto
        {
            Id = point.Id,
            Ports = point.ChargingPorts.Select(port => new ChargingPortDto
            {
                Id = port.Id,
                ConnectorName = port.Connector.Name,
                Power = port.Power,
                Status = port.Status.ToString()
            }).ToList()
        }).ToList()
    }).ToList();

    return Results.Ok(stationDtos);
});

// Endpoint cho VehicleType
app.MapGet("/vehicletypes", async (AppDbContext db) =>
{
    return await db.VehicleTypes.ToListAsync();
});

// Endpoint cho Connector
app.MapGet("/connectors", async (AppDbContext db) =>
{
    return await db.Connectors.ToListAsync();
});

// Endpoint cho PowerRange
app.MapGet("/powerrange", async (AppDbContext db) =>
{
    return await db.PowerRanges.ToListAsync();
});

// Endpoint cho TimeRange
app.MapGet("/timeranges", async (AppDbContext db) =>
{
    return await db.TimeRanges.ToListAsync();
});

// Endpoint cho ChargingPoints (tất cả)
app.MapGet("/chargingpoints", async (AppDbContext db) =>
{
    var points = await db.ChargingPoints
        .Include(p => p.ChargingStation)
        .Include(p => p.ChargingPorts)
            .ThenInclude(port => port.Connector)
        .ToListAsync();

    var pointDtos = points.Select(p => new ChargingPointDto
    {
        Id = p.Id,
        Ports = p.ChargingPorts.Select(port => new ChargingPortDto
        {
            Id = port.Id,
            ConnectorName = port.Connector.Name,
            Power = port.Power,
            Status = port.Status.ToString()
        }).ToList()
    }).ToList();

    return Results.Ok(pointDtos);
});

// Endpoint cho ChargingPoint theo Id
app.MapGet("/chargingpoints/{id}", async (string id, AppDbContext db) =>
{
    var point = await db.ChargingPoints
        .Include(p => p.ChargingStation)
        .Include(p => p.ChargingPorts)
            .ThenInclude(port => port.Connector)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (point == null)
        return Results.NotFound($"Charging point with ID {id} not found.");

    var pointDto = new ChargingPointDto
    {
        Id = point.Id,
        Ports = point.ChargingPorts.Select(port => new ChargingPortDto
        {
            Id = port.Id,
            ConnectorName = port.Connector.Name,
            Power = port.Power,
            Status = port.Status.ToString()
        }).ToList()
    };

    return Results.Ok(pointDto);
});

// Endpoint cho ChargingPorts (tất cả)
app.MapGet("/chargingports", async (AppDbContext db) =>
{
    var ports = await db.ChargingPorts
        .Include(p => p.Connector)
        .ToListAsync();

    var portDtos = ports.Select(p => new ChargingPortDto
    {
        Id = p.Id,
        ConnectorName = p.Connector.Name,
        Power = p.Power,
        Status = p.Status.ToString()
    }).ToList();

    return Results.Ok(portDtos);
});

// Endpoint cho ChargingPort theo Id
app.MapGet("/chargingports/{id}", async (string id, AppDbContext db) =>
{
    var port = await db.ChargingPorts
        .Include(p => p.Connector)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (port == null)
        return Results.NotFound($"Charging port with ID {id} not found.");

    var portDto = new ChargingPortDto
    {
        Id = port.Id,
        ConnectorName = port.Connector.Name,
        Power = port.Power,
        Status = port.Status.ToString()
    };

    return Results.Ok(portDto);
});

app.MapGet("/portinfo/{id}", async (string id, AppDbContext db) =>
{
    var port = await db.ChargingPorts
        .Include(p => p.Connector)
        .Include(p => p.ChargingPoint)
            .ThenInclude(cp => cp.ChargingStation)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (port == null)
        return Results.NotFound($"Charging port with ID {id} not found.");

    var portInfoDto = new ChargingPortInfoDto
    {
        Id = port.Id,
        ConnectorName = port.Connector.Name,
        Power = port.Power,
        Status = port.Status.ToString(),
        ChargingPointId = port.ChargingPoint.Id,
        ChargingStationName = port.ChargingPoint.ChargingStation.Name,
    };

    return Results.Ok(portInfoDto);
});

// Endpoint cho Vehicles
app.MapGet("/vehicles", async (AppDbContext db) =>
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
        ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
    }).ToList();

    return Results.Ok(vehicleDtos);
});

app.MapGet("/vehicles/{id}", async (int id, AppDbContext db) =>
{
    var vehicle = await db.Vehicles
        .Include(v => v.VehiclePorts)
            .ThenInclude(vp => vp.Connector)
        .Include(v => v.VehicleType)
        .FirstOrDefaultAsync(v => v.VehicleId == id);

    if (vehicle == null)
        return Results.NotFound($"Vehicle with ID {id} not found.");

    var vehicleDto = new VehicleDto
    {
        VehicleId = vehicle.VehicleId,
        Name = vehicle.Name,
        LicensePlate = vehicle.LicensePlate,
        BatteryCapacity = vehicle.BatteryCapacity,
        VehicleType = vehicle.VehicleType.Name, 
        ConnectorNames = vehicle.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
    };

    return Results.Ok(vehicleDto);
});



// Endpoint cho VehiclePorts (lấy tất cả)
app.MapGet("/vehicleports", async (AppDbContext db) =>
{
    var vehiclePorts = await db.VehiclePorts
        .Include(vp => vp.Vehicle)
        .Include(vp => vp.Connector)
        .ToListAsync();

    return Results.Ok(vehiclePorts);
});

// Endpoint lấy theo vehicleId (vehicleId phải là int)
app.MapGet("/vehicleports/{vehicleId:int}", async (int vehicleId, AppDbContext db) =>
{
    var vehiclePorts = await db.VehiclePorts
        .Include(vp => vp.Vehicle)
        .Include(vp => vp.Connector)
        .Where(vp => vp.VehicleId == vehicleId)
        .ToListAsync();

    if (vehiclePorts.Count == 0)
        return Results.NotFound($"No vehicle ports found for Vehicle ID {vehicleId}.");

    return Results.Ok(vehiclePorts);
});

// Tự động apply migrations khi app start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();

// Định nghĩa record (PHẢI NẰM SAU app.Run() HOẶC TÁCH RA FILE RIÊNG)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}