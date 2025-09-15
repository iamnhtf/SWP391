// 1. Các câu lệnh using - Đặt ở đầu file
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Models;

var builder = WebApplication.CreateBuilder(args);

// 2. Thêm dịch vụ DbContext và đọc chuỗi kết nối
// Chuỗi kết nối sẽ được đọc từ appsettings.json (hoặc biến môi trường khi deploy)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Kiểm tra nếu chuỗi kết nối không tồn tại
if (string.IsNullOrEmpty(connectionString))
{
    // Khi deploy, chuỗi kết nối thường được đặt qua biến môi trường,
    // nên việc throw lỗi này là tốt để đảm bảo nó được cấu hình đúng.
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Please ensure it's configured in appsettings.json or via environment variables.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

// Thêm dịch vụ để phục vụ các file tĩnh (như index.html)
// AddControllersWithViews() và AddRazorPages() không bắt buộc nếu bạn chỉ làm API + static files
// nhưng chúng không gây hại nếu bạn có kế hoạch mở rộng sau này.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.

// ----- Phần cấu hình pipeline của ứng dụng -----

// **QUAN TRỌNG NHẤT**: Thứ tự các middleware này là then chốt để phục vụ index.html
if (!app.Environment.IsDevelopment())
{
    // Chỉ dùng HTTPS redirection ở môi trường production
    app.UseHttpsRedirection();
}

// Middleware này cần đứng TRƯỚC các mapping khác để có thể phục vụ index.html
// làm trang chủ khi người dùng truy cập vào đường dẫn gốc (ví dụ: http://localhost:5076)
app.UseDefaultFiles(); // Tìm các file mặc định như index.html, default.html trong wwwroot
app.UseStaticFiles();  // Cho phép phục vụ các file tĩnh (CSS, JS, HTML, v.v.) từ thư mục wwwroot

// Mapping các endpoint API
// VÌ CHÚNG TA CÓ app.UseDefaultFiles() VÀ app.UseStaticFiles() ĐÃ PHỤC VỤ index.html CHO ĐƯỜNG DẪN GỐC,
// NÊN CÂU LỆNH app.MapGet("/") NÀY SẼ BỊ GHI ĐÈ. NẾU BẠN MUỐN index.html LÀM TRANG CHỦ THÌ NÊN XÓA DÒNG NÀY.
// Nếu bạn muốn nó hiển thị "Server is running! 🚀" thay vì index.html, hãy đặt nó SAU app.UseStaticFiles()
// và đổi lại thành app.MapGet("/info", ...) chẳng hạn.
// Cho mục đích hiện tại, chúng ta muốn index.html hiển thị đầu tiên nên sẽ bỏ qua MapGet("/") ở gốc.

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