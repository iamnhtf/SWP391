using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;
using TestServer.Crud;
using TestServer.Models.DTOs;
using TestServer.Dto;

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
        options.JsonSerializerOptions.ReferenceHandler = null;
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

app.MapControllers();

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
        Status = v.Status.ToString(),
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
        Status = vehicle.Status.ToString(),
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
        Status = v.Status.ToString(),
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
        Status = v.Status.ToString(),
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
        Status = SessionStatus.charging
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
    if (session.Status == SessionStatus.Completed) return Results.BadRequest("Session already completed.");

    session.EndTime = req.EndTime;
    session.EnergyConsumed = req.EnergyConsumed;
    session.TotalCost = req.TotalCost;
    session.Status = SessionStatus.Completed;
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

// Lấy tất cả PriceTable
app.MapGet("/pricetables", async (AppDbContext db) =>
{
    var priceTables = await db.PriceTables
        .Select(p => new
        {
            p.Id,
            p.PricePerKWh,
            p.PenaltyFeePerMinute,
            ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd"),
            ValidTo = p.ValidTo.ToString("yyyy-MM-dd")
        })
        .ToListAsync();

    return Results.Ok(priceTables);
});

//Lay price table active
app.MapGet("/pricetable/active", async (AppDbContext db) =>
{
    var activePriceTables = await db.PriceTables
        .Where(p => p.ValidFrom <= DateTime.Now && p.ValidTo >= DateTime.Now)
        .Where(p => p.Status == PriceTableStatus.Active)
        .Select(p => new
        {
            p.Id,
            p.PricePerKWh,
            p.PenaltyFeePerMinute,
            ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd"),
            ValidTo = p.ValidTo.ToString("yyyy-MM-dd")
        })
        .FirstOrDefaultAsync();

    return Results.Ok(activePriceTables);
});

// Lấy PriceTable theo ID
app.MapGet("/pricetables/{id:int}", async (int id, AppDbContext db) =>
{
    var priceTable = await db.PriceTables
        .Where(p => p.Id == id)
        .Select(p => new {
            p.Id,
            p.PricePerKWh,
            p.PenaltyFeePerMinute,
            ValidFrom = p.ValidFrom.ToString("yyyy-MM-dd HH:mm:ss"),
            ValidTo = p.ValidTo.ToString("yyyy-MM-dd HH:mm:ss")
        })
        .FirstOrDefaultAsync();

    if (priceTable == null)
        return Results.NotFound(new { message = $"PriceTable with ID {id} not found." });

    return Results.Ok(priceTable);
});

// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();