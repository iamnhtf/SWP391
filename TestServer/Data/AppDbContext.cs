using Microsoft.EntityFrameworkCore;
using TestServer.Models;
using TestServer.Package;

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

        // VehicleType
    modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType { Id = 1, Name = "Xe máy" },
        new VehicleType { Id = 2, Name = "Ô tô" }
    );

    // Connector
    modelBuilder.Entity<Connector>().HasData(
        new Connector { Id = 1, Name = "AC" },
        new Connector { Id = 2, Name = "CCS (DC)" },
        new Connector { Id = 3, Name = "CHAdeMO (DC)" }
    );

    // PowerRange
    modelBuilder.Entity<PowerRange>().HasData(
        new PowerRange { Id = 1, Range = "0-7" },
        new PowerRange { Id = 2, Range = "7-50" },
        new PowerRange { Id = 3, Range = ">50" }
    );

    // TimeRange
    modelBuilder.Entity<TimeRange>().HasData(
        new TimeRange { Id = 1, Range = "06:01–17:00" },
        new TimeRange { Id = 2, Range = "17:01–21:00" },
        new TimeRange { Id = 3, Range = "21:01–06:00" }
    );

    // PriceList (54 records, giá theo VND)
    modelBuilder.Entity<PriceList>().HasData(
        // Xe máy - AC
        new PriceList { Id = 1, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 1, Price = 3500 },
        new PriceList { Id = 2, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 2, Price = 4500 },
        new PriceList { Id = 3, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 3, Price = 3000 },
        new PriceList { Id = 4, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 1, Price = 4000 },
        new PriceList { Id = 5, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 2, Price = 5500 },
        new PriceList { Id = 6, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 3, Price = 3500 },
        new PriceList { Id = 7, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 1, Price = 5500 },
        new PriceList { Id = 8, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 2, Price = 7000 },
        new PriceList { Id = 9, VehicleTypeId = 1, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 3, Price = 4500 },

        // Xe máy - CCS (DC)
        new PriceList { Id = 10, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 1, Price = 4500 },
        new PriceList { Id = 11, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 2, Price = 6000 },
        new PriceList { Id = 12, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 3, Price = 4000 },
        new PriceList { Id = 13, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 1, Price = 6000 },
        new PriceList { Id = 14, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 2, Price = 7500 },
        new PriceList { Id = 15, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 3, Price = 5000 },
        new PriceList { Id = 16, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 1, Price = 7000 },
        new PriceList { Id = 17, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 2, Price = 9000 },
        new PriceList { Id = 18, VehicleTypeId = 1, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 3, Price = 6000 },

        // Xe máy - CHAdeMO (DC)
        new PriceList { Id = 19, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 1, Price = 4500 },
        new PriceList { Id = 20, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 2, Price = 6000 },
        new PriceList { Id = 21, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 3, Price = 4000 },
        new PriceList { Id = 22, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 1, Price = 6000 },
        new PriceList { Id = 23, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 2, Price = 7500 },
        new PriceList { Id = 24, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 3, Price = 5000 },
        new PriceList { Id = 25, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 1, Price = 7000 },
        new PriceList { Id = 26, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 2, Price = 9000 },
        new PriceList { Id = 27, VehicleTypeId = 1, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 3, Price = 6000 },

        // Ô tô - AC
        new PriceList { Id = 28, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 1, Price = 4500 },
        new PriceList { Id = 29, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 2, Price = 6000 },
        new PriceList { Id = 30, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 1, TimeRangeId = 3, Price = 4000 },
        new PriceList { Id = 31, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 1, Price = 5500 },
        new PriceList { Id = 32, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 2, Price = 7000 },
        new PriceList { Id = 33, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 2, TimeRangeId = 3, Price = 4500 },
        new PriceList { Id = 34, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 1, Price = 6500 },
        new PriceList { Id = 35, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 2, Price = 8000 },
        new PriceList { Id = 36, VehicleTypeId = 2, ConnectorId = 1, PowerRangeId = 3, TimeRangeId = 3, Price = 5500 },

        // Ô tô - CCS (DC)
        new PriceList { Id = 37, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 1, Price = 5500 },
        new PriceList { Id = 38, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 2, Price = 7000 },
        new PriceList { Id = 39, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 1, TimeRangeId = 3, Price = 5000 },
        new PriceList { Id = 40, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 1, Price = 7000 },
        new PriceList { Id = 41, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 2, Price = 9000 },
        new PriceList { Id = 42, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 2, TimeRangeId = 3, Price = 6500 },
        new PriceList { Id = 43, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 1, Price = 8500 },
        new PriceList { Id = 44, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 2, Price = 10500 },
        new PriceList { Id = 45, VehicleTypeId = 2, ConnectorId = 2, PowerRangeId = 3, TimeRangeId = 3, Price = 7500 },

        // Ô tô - CHAdeMO (DC)
        new PriceList { Id = 46, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 1, Price = 5500 },
        new PriceList { Id = 47, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 2, Price = 7000 },
        new PriceList { Id = 48, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 1, TimeRangeId = 3, Price = 5000 },
        new PriceList { Id = 49, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 1, Price = 7000 },
        new PriceList { Id = 50, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 2, Price = 9000 },
        new PriceList { Id = 51, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 2, TimeRangeId = 3, Price = 6500 },
        new PriceList { Id = 52, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 1, Price = 8500 },
        new PriceList { Id = 53, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 2, Price = 10500 },
        new PriceList { Id = 54, VehicleTypeId = 2, ConnectorId = 3, PowerRangeId = 3, TimeRangeId = 3, Price = 7500 }
    );
        
    }

    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    public DbSet<PriceList> PriceLists { get; set; } = null!;
    public DbSet<Connector> Connectors { get; set; } = null!;
    public DbSet<PowerRange> PowerRanges { get; set; } = null!;
    public DbSet<TimeRange> TimeRanges { get; set; } = null!;

}