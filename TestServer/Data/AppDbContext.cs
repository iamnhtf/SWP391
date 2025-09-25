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
            new Driver { Id = 4, Name = "Lê Minh Đức" },
            new Driver { Id = 5, Name = "Vũ Thế Anh" }
        );

        // Thêm 4 trạm sạc ở TP.HCM
        modelBuilder.Entity<ChargingStation>().HasData(
            new ChargingStation { Id = 1, Name = "Trạm Sạc Landmark 81", Location = "Tầng L1, Vincom Centre Landmark 81, 208 Nguyễn Hữu Cảnh, P.22, Q. Bình Thạnh, TP.HCM" },
            new ChargingStation { Id = 2, Name = "Trạm Sạc Cộng Hòa", Location = "Tầng 1, Trung tâm thương mại Vincom Cộng Hòa, 15-17 Cộng Hòa, P.4, Q. Tân Bình, TP.HCM" },
            new ChargingStation { Id = 3, Name = "Trạm Sạc Ba Tháng Hai", Location = "Tầng 1, TTTM Vincom Ba Tháng Hai, 3C Đường 3 Tháng 2, P.11, Q.10, TP.HCM" },
            new ChargingStation { Id = 4, Name = "Trạm Sạc Léman Luxury Apartments", Location = "Tầng hầm B3, tòa Léman Luxury, 117 Nguyễn Đình Chiểu, P.6, Quận 3" },
            new ChargingStation { Id = 5, Name = "Trạm Sạc Huỳnh Hiếu Thiện", Location = "Số 130/30G, Nguyễn Văn Lượng, P.10, Quận 6" },
            new ChargingStation { Id = 6, Name = "Trạm Sạc Sky89", Location = "Số 89, Hoàng Quốc Việt, P. Phú Thuận, Quận 7" },
            new ChargingStation { Id = 7, Name = "Trạm Sạc Center Đồng Khởi", Location = "Hầm B5, số 72 Lê Thánh Tôn, Quận 1" }
        );

        modelBuilder.Entity<ChargingPriceTable>().HasData(
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 3500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 4500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 3000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 4000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 5500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 3500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 5500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 4500 },

            // Motorbike - CCS (DC)
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 4500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 6000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 4000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 6000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 5000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 9000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 6000 },

            // Motorbike - CHAdeMO (DC)
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 4500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 6000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 4000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 6000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7500 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 5000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 9000 },
            new ChargingPriceTable { Vehicle = "Motorbike", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 6000 },

            // Car - AC
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 4500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 6000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 4000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 5500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 4500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 6500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 8000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "AC", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 5500 },

            // Car - CCS (DC)
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 5500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 5000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 9000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 6500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 8500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 10500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CCS (DC)", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 7500 },

            // Car - CHAdeMO (DC)
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 5500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 7, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 5000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 7000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 9000 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 50, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 6500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(6, 1, 0), EndTime = new TimeSpan(17, 0, 0), Price = 8500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(17, 1, 0), EndTime = new TimeSpan(21, 0, 0), Price = 10500 },
            new ChargingPriceTable { Vehicle = "Car", Connector = "CHAdeMO (DC)", MaxPower = 100, StartTime = new TimeSpan(21, 1, 0), EndTime = new TimeSpan(6, 0, 0), Price = 7500 }
        );
    }

    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
    public DbSet<ChargingPriceTable> ChargingPriceTables { get; set; } = null!;
}