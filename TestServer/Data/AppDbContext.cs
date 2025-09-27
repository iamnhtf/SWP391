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
            new ChargingStation { Id = 1, Name = "Landmark 81 Charging Station", Location = "L1 Floor, Vincom Centre Landmark 81, 208 Nguyen Huu Canh Street, Ward 22, Binh Thanh District, Ho Chi Minh City" },
            new ChargingStation { Id = 2, Name = "Cong Hoa Charging Station", Location = "1st Floor, Vincom Cong Hoa Trade Center, 15-17 Cong Hoa Street, Ward 4, Tan Binh District, Ho Chi Minh City" },
            new ChargingStation { Id = 3, Name = "Ba Thang Hai Charging Station", Location = "1st Floor, Vincom Ba Thang Hai Trade Center, 3C 3 Thang 2 Street, Ward 11, District 10, Ho Chi Minh City" },
            new ChargingStation { Id = 4, Name = "Leman Luxury Apartments Station", Location = "B3 Basement, Leman Luxury Building, 117 Nguyen Dinh Chieu Street, Ward 6, District 3, Ho Chi Minh City" },
            new ChargingStation { Id = 5, Name = "Huynh Hieu Thien Station", Location = "130/30G Nguyen Van Luong Street, Ward 10, District 6, Ho Chi Minh City" },
            new ChargingStation { Id = 6, Name = "Sky89 Station", Location = "89 Hoang Quoc Viet Street, Phu Thuan Ward, District 7, Ho Chi Minh City" },
            new ChargingStation { Id = 7, Name = "Center Dong Khoi Station", Location = "B5 Basement, 72 Le Thanh Ton Street, District 1, Ho Chi Minh City" }
        );

        // VehicleType
    modelBuilder.Entity<VehicleType>().HasData(
        new VehicleType { Id = 1, Name = "Motorbike" },
        new VehicleType { Id = 2, Name = "Car" }
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

    modelBuilder.Entity<ChargingPort>()
            .Property(c => c.Status)
            .HasConversion<string>();

    modelBuilder.Entity<ChargingPoint>()
            .HasMany(p => p.ChargingPorts)
            .WithOne(c => c.ChargingPoint)
            .HasForeignKey(c => c.PointId);

    modelBuilder.Entity<ChargingPoint>().HasData(
    new ChargingPoint { Id = "1.1", StationId = 1 },
    new ChargingPoint { Id = "2.1", StationId = 2 },
    new ChargingPoint { Id = "3.1", StationId = 3 },
    new ChargingPoint { Id = "4.1", StationId = 4 },
    new ChargingPoint { Id = "5.1", StationId = 5 },
    new ChargingPoint { Id = "6.1", StationId = 6 },
    new ChargingPoint { Id = "7.1", StationId = 7 }
    );

    // ChargingPort
    modelBuilder.Entity<ChargingPort>().HasData(
    // Station 1
    new ChargingPort { Id = "1.1.1", PointId = "1.1", ConnectorId = 1, Power = "7 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "1.1.2", PointId = "1.1", ConnectorId = 2, Power = "50 kW", Status = ChargingPortStatus.InUse },

    // Station 2
    new ChargingPort { Id = "2.1.1", PointId = "2.1", ConnectorId = 1, Power = "22 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "2.1.2", PointId = "2.1", ConnectorId = 2, Power = ">50 kW", Status = ChargingPortStatus.Faulty },

    // Station 3
    new ChargingPort { Id = "3.1.1", PointId = "3.1", ConnectorId = 1, Power = "7 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "3.1.2", PointId = "3.1", ConnectorId = 2, Power = "50 kW", Status = ChargingPortStatus.InUse },

    // Station 4
    new ChargingPort { Id = "4.1.1", PointId = "4.1", ConnectorId = 1, Power = "22 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "4.1.2", PointId = "4.1", ConnectorId = 2, Power = "7 kW", Status = ChargingPortStatus.Faulty },

    // Station 5
    new ChargingPort { Id = "5.1.1", PointId = "5.1", ConnectorId = 1, Power = "7 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "5.1.2", PointId = "5.1", ConnectorId = 2, Power = "22 kW", Status = ChargingPortStatus.InUse },

    // Station 6
    new ChargingPort { Id = "6.1.1", PointId = "6.1", ConnectorId = 1, Power = "50 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "6.1.2", PointId = "6.1", ConnectorId = 2, Power = "22 kW", Status = ChargingPortStatus.InUse },

    // Station 7
    new ChargingPort { Id = "7.1.1", PointId = "7.1", ConnectorId = 1, Power = "7 kW", Status = ChargingPortStatus.Available },
    new ChargingPort { Id = "7.1.2", PointId = "7.1", ConnectorId = 2, Power = "50 kW", Status = ChargingPortStatus.Faulty }
    );
    }

    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    public DbSet<PriceList> PriceLists { get; set; } = null!;
    public DbSet<Connector> Connectors { get; set; } = null!;
    public DbSet<PowerRange> PowerRanges { get; set; } = null!;
    public DbSet<TimeRange> TimeRanges { get; set; } = null!;
    public DbSet<ChargingPoint> ChargingPoints {get; set; } = null!;
    public DbSet<ChargingPort> ChargingPorts { get; set; } = null!;
}