// File: Program.cs

// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Package;
using TestServer.Crud;
using TestServer.Models.DTOs;

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

// Đăng ký CustomerCrud service
builder.Services.AddScoped<CustomerCrud>();

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

// CUSTOMER CRUD ENDPOINTS

// Get All Customers
app.MapGet("/customers", async (CustomerCrud customerCrud) =>
{
    var customers = await customerCrud.GetAllCustomers();
    return Results.Ok(customers);
});

// Get Customer by ID
app.MapGet("/customer/{id}", async (string id, CustomerCrud customerCrud) =>
{
    if (string.IsNullOrWhiteSpace(id))
    {
        return Results.BadRequest("Customer ID must not be empty.");
    }

    var customer = await customerCrud.GetCustomerById(id);
    return customer != null
        ? Results.Ok(customer)
        : Results.NotFound($"Customer with ID '{id}' not found.");
});

// Create Customer
app.MapPost("/customers", async (Customer customer, CustomerCrud customerCrud) =>
{
    try
    {
        var createdCustomer = await customerCrud.CreateCustomer(customer);
        return Results.Created($"/customers/{createdCustomer.Id}", createdCustomer);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error creating customer: {ex.Message}");
    }
});

// Update Customer
app.MapPut("/customers/{id}", async (string id, Customer customer, CustomerCrud customerCrud) =>
{
    if (string.IsNullOrWhiteSpace(id))
    {
        return Results.BadRequest("Customer ID must not be empty.");
    }

    var updatedCustomer = await customerCrud.UpdateCustomer(id, customer);
    return updatedCustomer != null
        ? Results.Ok(updatedCustomer)
        : Results.NotFound($"Customer with ID '{id}' not found.");
});

// Delete Customer
app.MapDelete("/customers/{id}", async (string id, CustomerCrud customerCrud) =>
{
    if (string.IsNullOrWhiteSpace(id))
    {
        return Results.BadRequest("Customer ID must not be empty.");
    }

    var deleted = await customerCrud.DeleteCustomer(id);
    return deleted
        ? Results.NoContent()
        : Results.NotFound($"Customer with ID '{id}' not found.");
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

app.MapGet("/vehiclesforcustomer/{uid}", async (string uid, AppDbContext db) =>
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
        ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
    }).ToList();

    return Results.Ok(vehicleDtos);

});

app.MapGet("/vehiclesforcustomer/{uid}/{connectorName}", async (string uid, string connectorName, AppDbContext db) =>
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
        ConnectorNames = v.VehiclePorts.Select(vp => vp.Connector.Name).ToList()
    }).ToList();

    return Results.Ok(vehicleDtos);
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

// Endpoint cho VehicleConnectorTypes
app.MapGet("/vehicleconnectortypes", async (AppDbContext db) =>
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

    return Results.Ok(vehicleConnectorTypeDtos);
});



// Tự động apply migrations khi app start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapPost("/createchargingsession", async (CreateChargingSessionRequest req, AppDbContext db) =>
{
    if (req == null) return Results.BadRequest("Request body required.");
    if (req.VehicleId <= 0 || string.IsNullOrWhiteSpace(req.PortId))
        return Results.BadRequest("vehicleId and portid required.");

    // validate vehicle + port
    var vehicle = await db.Vehicles.FindAsync(req.VehicleId);
    if (vehicle == null) return Results.NotFound($"Vehicle {req.VehicleId} not found.");

    var port = await db.ChargingPorts.FindAsync(req.PortId);
    if (port == null) return Results.NotFound($"Port {req.PortId} not found.");

    // create session
    var session = new ChargingSession
    {
        VehicleId = req.VehicleId,
        PortId = req.PortId,
        StartTime = req.StartTime,
        Status = ChargingSession.SessionStatus.charging
    };
    db.ChargingSessions.Add(session);

    // set port status: handle string or enum Status property
    var statusProp = port.GetType().GetProperty("Status");
    if (statusProp != null)
    {
        if (statusProp.PropertyType == typeof(string))
        {
            statusProp.SetValue(port, "InUse");
        }
        else if (statusProp.PropertyType.IsEnum)
        {
            try
            {
                var enumVal = Enum.Parse(statusProp.PropertyType, "InUse", ignoreCase: true);
                statusProp.SetValue(port, enumVal);
            }
            catch { /* ignore if enum value not present */ }
        }
        db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    // --- update MonthlyPeriod / VehiclePerMonth ---
    var month = req.StartTime.Month;
    var year = req.StartTime.Year;

    // find period (use EF.Property for Month/Year to avoid compile-time dependency on exact MonthlyPeriod shape)
    var period = await db.MonthlyPeriods
        .FirstOrDefaultAsync(p => EF.Property<int>(p, "Month") == month && EF.Property<int>(p, "Year") == year);

    if (period == null)
    {
        // create new MonthlyPeriod with Month/Year — adjust property names if different
        period = Activator.CreateInstance(typeof(MonthlyPeriod)) as MonthlyPeriod;
        if (period != null)
        {
            var mpMonth = period.GetType().GetProperty("Month");
            var mpYear = period.GetType().GetProperty("Year");
            if (mpMonth != null) mpMonth.SetValue(period, month);
            if (mpYear != null) mpYear.SetValue(period, year);
            db.MonthlyPeriods.Add(period);
            await db.SaveChangesAsync(); // ensure PK is generated
        }
    }

    // determine periodId (try common PK names)
    int periodId = 0;
    if (period != null)
    {
        var idProp = period.GetType().GetProperty("MonthlyPeriodId")
                     ?? period.GetType().GetProperty("Id")
                     ?? period.GetType().GetProperty("PeriodId");
        if (idProp != null)
        {
            periodId = (int)(idProp.GetValue(period) ?? 0);
        }
        else
        {
            try
            {
                periodId = (int)db.Entry(period).Property("Id").CurrentValue;
            }
            catch { /* ignore */ }
        }
    }

    // update VehiclePerMonth using strongly-typed model
    if (periodId != 0)
    {
        var vehicleMonth = await db.VehiclePerMonths
            .FirstOrDefaultAsync(vm => vm.VehicleId == vehicle.VehicleId && vm.PeriodId == periodId);

        if (vehicleMonth == null)
        {
            vehicleMonth = new VehiclePerMonth
            {
                VehicleId = vehicle.VehicleId,
                PeriodId = periodId,
                TotalSessions = 0,
                TotalEnergy = 0,
                AmountPaid = 0
            };
            db.VehiclePerMonths.Add(vehicleMonth);
        }

        vehicleMonth.TotalSessions += 1;
        db.Entry(vehicleMonth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    await db.SaveChangesAsync();

    // return sessionId only
    return Results.Ok(new { sessionId = session.Id });
});

app.MapPost("/stopchargingsession", async (StopChargingSessionRequest req, AppDbContext db) =>
{
    if (req == null) return Results.BadRequest("Request body required.");

    var session = await db.ChargingSessions.FindAsync(req.SessionId);
    if (session == null) return Results.NotFound($"Session {req.SessionId} not found.");
    if (session.Status == ChargingSession.SessionStatus.Completed) return Results.BadRequest("Session already completed.");

    session.EndTime = req.EndTime;
    session.EnergyConsumed = req.EnergyConsumed;
    session.TotalCost = req.TotalCost;
    session.Status = ChargingSession.SessionStatus.Completed;
    db.Entry(session).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

    // determine periodId from session.StartTime
    var start = session.StartTime;
    var month = start.Month;
    var year = start.Year;

    var period = await db.MonthlyPeriods
        .FirstOrDefaultAsync(p => EF.Property<int>(p, "Month") == month && EF.Property<int>(p, "Year") == year);

    int periodId = 0;
    if (period != null)
    {
        var idProp = period.GetType().GetProperty("MonthlyPeriodId")
                     ?? period.GetType().GetProperty("Id")
                     ?? period.GetType().GetProperty("PeriodId");
        if (idProp != null)
        {
            periodId = (int)(idProp.GetValue(period) ?? 0);
        }
        else
        {
            try
            {
                periodId = (int)db.Entry(period).Property("Id").CurrentValue;
            }
            catch { /* ignore */ }
        }
    }

    // update VehiclePerMonth using strongly-typed model (VehicleId)
    if (periodId != 0)
    {
        var vehicleMonth = await db.VehiclePerMonths
            .FirstOrDefaultAsync(vm => vm.VehicleId == session.VehicleId && vm.PeriodId == periodId);

        if (vehicleMonth != null)
        {
            vehicleMonth.TotalEnergy += req.EnergyConsumed;
            vehicleMonth.AmountPaid += req.TotalCost;
            db.Entry(vehicleMonth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }

    // free port if exists (set Status = "Available" if string)
    var port = await db.ChargingPorts.FindAsync(session.PortId);
    if (port != null)
    {
        var statusProp = port.GetType().GetProperty("Status");
        if (statusProp != null && statusProp.PropertyType == typeof(string))
        {
            statusProp.SetValue(port, "Available");
            db.Entry(port).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }

    await db.SaveChangesAsync();

    return Results.Ok(new { sessionId = session.Id });
});


// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();

// Định nghĩa record (PHẢI NẰM SAU app.Run() HOẶC TÁCH RA FILE RIÊNG)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}