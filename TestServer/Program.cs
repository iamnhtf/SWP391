using Microsoft.EntityFrameworkCore;
using TestServer.Data;
using TestServer.Services.VNPAY;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using TestServer.Hubs;
using TestServer.Services;
using Firebase.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVnPayService, VnPayService>();

//Thêm dịch vụ DbContext và đọc chuỗi kết nối
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found. Please ensure it's configured in appsettings.json or via environment variables."
    );
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

// 2️⃣ Thêm dịch vụ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm dịch vụ để phục vụ các file tĩnh
builder
    .Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = null;
        options.JsonSerializerOptions.MaxDepth = 64; // tăng nếu cần
    });

builder.Services.AddRazorPages();

// Add permissive CORS policy (open access)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSignalR();

builder.Services.AddHostedService<ReservationExpiryService>();

// Khởi tạo Firebase Admin SDK
if (FirebaseApp.DefaultInstance == null)
{
    FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromFile("Data/ev-charging-station-swp-firebase-adminsdk-fbsvc-215a4dc678.json")
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

//Bật Swagger
app.UseSwagger();
app.UseSwaggerUI();


// Middleware này cần đứng TRƯỚC các mapping khác
app.UseDefaultFiles();
app.UseStaticFiles();

// Enable CORS globally using the AllowAll policy
app.UseCors("AllowAll");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<UnityHub>("/unityhub");

// Tự động apply migrations khi app start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Khởi động ứng dụng web (PHẢI LÀ DÒNG CUỐI CÙNG)
app.Run();