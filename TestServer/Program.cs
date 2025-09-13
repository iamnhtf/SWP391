// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models; // Đảm bảo bạn có using này cho Models

var builder = WebApplication.CreateBuilder(args);

// 2. Thêm dịch vụ DbContext và đọc chuỗi kết nối
// Chuỗi kết nối sẽ được đọc từ appsettings.json hoặc launchSettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Kiểm tra nếu chuỗi kết nối không tồn tại
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Please ensure it's configured in appsettings.json or launchSettings.json.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

// Thêm dịch vụ để phục vụ các file tĩnh (như index.html) nếu bạn muốn
builder.Services.AddControllersWithViews(); // Nếu bạn có kế hoạch dùng MVC
builder.Services.AddRazorPages(); // Nếu bạn có kế hoạch dùng Razor Pages

var app = builder.Build();

// Configure the HTTP request pipeline.

// ----- Phần cấu hình pipeline của ứng dụng -----

// Thêm các middleware sau để phục vụ file tĩnh và HTTPS redirection
// Đảm bảo chúng được đặt trước các endpoint khác
if (!app.Environment.IsDevelopment()) // Chỉ dùng HTTPS redirection ở môi trường production
{
    app.UseHttpsRedirection();
}

// *** ĐÂY LÀ PHẦN QUAN TRỌNG NHẤT ***
// Middleware này PHẢI ĐƯỢC ĐẶT TRƯỚC các MapGet hoặc MapControllerRoute
// nếu bạn muốn nó phục vụ index.html làm trang chủ mặc định.
app.UseDefaultFiles(); // Tìm file index.html hoặc index.htm làm trang mặc định trong wwwroot
app.UseStaticFiles();  // Cho phép phục vụ các file tĩnh (CSS, JS, HTML, v.v.) từ wwwroot

// Mapping các endpoint API
// Endpoint "/" của bạn sẽ KHÔNG được dùng nữa nếu index.html đã được phục vụ
// Bạn có thể xóa dòng này nếu không cần thiết
// app.MapGet("/", () => "Server is running! 🚀"); // << XÓA HOẶC BỎ COMMENT DÒNG NÀY

app.MapGet("/weatherforecast", () =>
{
    // ... (code WeatherForecast của bạn) ...
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

// Endpoint để lấy tất cả drivers
app.MapGet("/drivers", async (AppDbContext db) =>
{
    return await db.Drivers.ToListAsync();
});

// Endpoint để lấy driver theo ID
app.MapGet("/drivers/{id}", async (int id, AppDbContext db) =>
{
    var driver = await db.Drivers.FindAsync(id);
    // Trả về đối tượng Driver nếu tìm thấy, nếu không trả về NotFound
    return driver != null ? Results.Ok(driver) : Results.NotFound($"Driver with ID {id} not found.");
});

app.Run(); // Khởi động ứng dụng web

// 4. Định nghĩa record - Đặt ở cuối file hoặc trong một file Model riêng
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}