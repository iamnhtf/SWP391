// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore; 
using TestServer.Data; 
using TestServer.Models;

var builder = WebApplication.CreateBuilder(args);

// 2. Thêm dịch vụ DbContext và đọc chuỗi kết nối
// Tạm thời hardcode chuỗi kết nối để dotnet ef có thể đọc
var connectionString = "Host=mysql.railway.internal;Port=3306;Database=railway;Username=root;Password=XckWMULXLDkFoSyQkhjunmOjqpOlzpyt";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// WeatherForecast endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
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

// Simple test endpoint
app.MapGet("/", () => "Server is running! 🚀");

// 3. Các endpoint driver mới (truy vấn database)
app.MapGet("/drivers", async (AppDbContext db) =>
{
    return await db.Drivers.ToListAsync();
});

app.MapGet("/drivers/{id}", async (int id, AppDbContext db) =>
{
    var driver = await db.Drivers.FindAsync(id);
    return driver != null ? Results.Ok(driver) : Results.NotFound();
});

app.Run();

// 4. Định nghĩa record - Đặt ở cuối file
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
