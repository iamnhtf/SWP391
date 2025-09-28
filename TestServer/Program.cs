// File: Program.cs

// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Package;

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

// Endpoint cho DRIVERS
app.MapGet("/drivers", async (AppDbContext db) =>
{
    return await db.Drivers.ToListAsync();
});

app.MapGet("/drivers/{id}", async (int id, AppDbContext db) =>
{
    //ràng buộc id phải là số dương
    if (id <= 0)
    {
        return Results.BadRequest("Driver ID must be a positive integer.");
    }
    var driver = await db.Drivers.FindAsync(id);
    return driver != null ? Results.Ok(driver) : Results.NotFound($"Driver with ID {id} not found.");
});

// Endpoint cho CHARGING STATIONS
app.MapGet("/chargingstations", async (AppDbContext db) =>
{
    return await db.ChargingStations.ToListAsync();
});

app.MapGet("/chargingstations/{id}", async (int id, AppDbContext db) =>
{
    var station = await db.ChargingStations.FindAsync(id);
    return station != null ? Results.Ok(station) : Results.NotFound($"Charging station with ID {id} not found.");
});

// Endpoints cho PriceList
app.MapGet("/pricelist", async (AppDbContext db) =>
{
    return await db.PriceLists
    .Include(p => p.VehicleType)
    .Include(p => p.Connector)
    .Include(p => p.PowerRange)
    .Include(p => p.TimeRange)
    .ToListAsync();
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

app.MapGet("/allchargingstations", async (AppDbContext db) =>
{
    var stations = await db.ChargingStations
        .Include(station => station.ChargingPoints)
            .ThenInclude(point => point.ChargingPorts)
                .ThenInclude(port => port.Connector)
        .ToListAsync();

    var stationDtos = stations.Select(station => new ChargingStationDto {
        Id = station.Id,
        Name = station.Name,
        Location = station.Location,
        Points = station.ChargingPoints.Select(point => new ChargingPointDto {
            Id = point.Id,
            Ports = point.ChargingPorts.Select(port => new ChargingPortDto {
                Id = port.Id,
                ConnectorName = port.Connector.Name,
                Power = port.Power,
                Status = port.Status.ToString()
            }).ToList()
        }).ToList()
    }).ToList();

    return Results.Ok(stationDtos);
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