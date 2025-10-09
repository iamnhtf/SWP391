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
app.MapControllers();
app.MapRazorPages();

// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();