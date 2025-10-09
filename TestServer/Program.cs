using Microsoft.EntityFrameworkCore;
using TestServer.Data;

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
app.UseDefaultFiles(); 
app.UseStaticFiles();  

app.MapControllers();

// Tự động apply migrations khi app start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();