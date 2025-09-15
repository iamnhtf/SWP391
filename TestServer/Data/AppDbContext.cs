using Microsoft.EntityFrameworkCore;
using TestServer.Models; // Đảm bảo có using này

namespace TestServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Thêm đoạn code này để seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Driver>().HasData(
            new Driver { Id = 1, Name = "Nguyễn Xuân Thịnh" },
            new Driver { Id = 2, Name = "Nguyễn Hưng Thái" },
            new Driver { Id = 3, Name = "Nguyễn Bùi Đăng Khôi" },
            new Driver { Id = 4, Name = "Lê Minh Đức" } ,
            new Driver { Id = 5, Name = "Vũ Thế Anh" }
        );
    }

    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
}