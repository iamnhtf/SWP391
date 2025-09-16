using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm log để debug
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Connection string: " + connectionString);

// Nếu connection string null, thử lấy từ environment variable trực tiếp
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    Console.WriteLine("Fallback env connection string: " + connectionString);

    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Ensure it's in appsettings.json or env variables.");
}

// Thêm DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
    app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

// API endpoints
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

app.MapGet("/drivers", async (AppDbContext db) => await db.Drivers.ToListAsync());
app.MapGet("/drivers/{id}", async (int id, AppDbContext db) =>
{
    var driver = await db.Drivers.FindAsync(id);
    return driver != null ? Results.Ok(driver) : Results.NotFound($"Driver with ID {id} not found.");
});

app.MapGet("/chargingstations", async (AppDbContext db) => await db.ChargingStations.ToListAsync());
app.MapGet("/chargingstations/{id}", async (int id, AppDbContext db) =>
{
    var station = await db.ChargingStations.FindAsync(id);
    return station != null ? Results.Ok(station) : Results.NotFound($"Charging station with ID {id} not found.");
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
