using Microsoft.EntityFrameworkCore;
using TestServer.Models; 

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

        // Thêm 4 trạm sạc ở TP.HCM
        modelBuilder.Entity<ChargingStation>().HasData(
            new ChargingStation { Id = 1, Name = "Trạm Sạc Quận 1", Location = "Quận 1, TP.HCM" },
            new ChargingStation { Id = 2, Name = "Trạm Sạc Quận 3", Location = "Quận 3, TP.HCM" },
            new ChargingStation { Id = 3, Name = "Trạm Sạc Quận 7", Location = "Quận 7, TP.HCM" },
            new ChargingStation { Id = 4, Name = "Trạm Sạc Thủ Đức", Location = "TP. Thủ Đức, TP.HCM" }
        );
    }

    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
    public DbSet<Staff> Staff { get; set; } = null!;
}