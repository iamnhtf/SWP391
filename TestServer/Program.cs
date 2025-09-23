// File: Program.cs

// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

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

// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();

// Định nghĩa record (PHẢI NẰM SAU app.Run() HOẶC TÁCH RA FILE RIÊNG)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}