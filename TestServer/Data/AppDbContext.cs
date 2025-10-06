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

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = "C001", Name = "Nguyễn Xuân Thịnh", Email = "thinh.nguyen@example.com", PhoneNumber = "0901234567", Address = "Quận 1, TP.HCM" },
            new Customer { Id = "C002", Name = "Nguyễn Hưng Thái", Email = "thai.nguyen@example.com", PhoneNumber = "0912345678", Address = "Quận 3, TP.HCM" },
            new Customer { Id = "C003", Name = "Nguyễn Bùi Đăng Khôi", Email = "khoi.nguyen@example.com", PhoneNumber = "0923456789", Address = "Quận 7, TP.HCM" },
            new Customer { Id = "C004", Name = "Lê Minh Đức", Email = "duc.le@example.com", PhoneNumber = "0934567890", Address = "Quận Bình Thạnh, TP.HCM" },
            new Customer { Id = "C005", Name = "Vũ Thế Anh", Email = "theanh.vu@example.com", PhoneNumber = "0945678901", Address = "Quận 10, TP.HCM" },
            new Customer { Id = "C006", Name = "Trần Văn Hùng", Email = "vhung.tran@example.com", PhoneNumber = "0951122334", Address = "Quận Tân Bình, TP.HCM" },
            new Customer { Id = "C007", Name = "Phạm Thị Lan", Email = "lan.pham@example.com", PhoneNumber = "0962233445", Address = "Quận 5, TP.HCM" },
            new Customer { Id = "C008", Name = "Hoàng Anh Tuấn", Email = "tuan.hoang@example.com", PhoneNumber = "0973344556", Address = "Quận 2, TP.HCM" },
            new Customer { Id = "C009", Name = "Đỗ Minh Quân", Email = "mqun.do@example.com", PhoneNumber = "0984455667", Address = "Quận 4, TP.HCM" },
            new Customer { Id = "C010", Name = "Lê Thị Hòa", Email = "hoa.le@example.com", PhoneNumber = "0905566778", Address = "Quận Phú Nhuận, TP.HCM" }
        );

        // Thêm 4 trạm sạc ở TP.HCM
        modelBuilder.Entity<ChargingStation>().HasData(
    new ChargingStation
    {
        Id = 1,
        Name = "Landmark 81 Charging Station",
        Location = "Vincom Landmark 81, Binh Thanh District, Ho Chi Minh City",
        Latitude = 10.7944,
        Longitude = 106.7215
    },
    new ChargingStation
    {
        Id = 2,
        Name = "Cong Hoa Charging Station",
        Location = "Vincom Cong Hoa, Tan Binh District, Ho Chi Minh City",
        Latitude = 10.8013,
        Longitude = 106.6500
    },
    new ChargingStation
    {
        Id = 3,
        Name = "Ba Thang Hai Charging Station",
        Location = "Vincom Ba Thang Hai, District 10, Ho Chi Minh City",
        Latitude = 10.7721,
        Longitude = 106.6678
    },
    new ChargingStation
    {
        Id = 4,
        Name = "Leman Luxury Apartments Station",
        Location = "Leman Luxury Building, District 3, Ho Chi Minh City",
        Latitude = 10.7795,
        Longitude = 106.6888
    },
    new ChargingStation
    {
        Id = 5,
        Name = "Huynh Hieu Thien Station",
        Location = "Nguyen Van Luong Street, District 6, Ho Chi Minh City",
        Latitude = 10.7482,
        Longitude = 106.6361
    },
    new ChargingStation
    {
        Id = 6,
        Name = "Sky89 Station",
        Location = "Hoang Quoc Viet Street, District 7, Ho Chi Minh City",
        Latitude = 10.7358,
        Longitude = 106.7251
    },
    new ChargingStation
    {
        Id = 7,
        Name = "Center Dong Khoi Station",
        Location = "Le Thanh Ton Street, District 1, Ho Chi Minh City",
        Latitude = 10.7765,
        Longitude = 106.7032
    }
);


        // VehicleType
        modelBuilder.Entity<VehicleType>().HasData(
            new VehicleType { Id = 1, Name = "Motorbike" },
            new VehicleType { Id = 2, Name = "car" }
        );

        // Connector
        modelBuilder.Entity<Connector>().HasData(
            new Connector { Id = 1, Name = "AC" },
            new Connector { Id = 2, Name = "CCS" },
            new Connector { Id = 3, Name = "CHAdeMO" }
        );

        // PowerRange
        modelBuilder.Entity<PowerRange>().HasData(
            new PowerRange { Id = 1, Range = "0-7" },
            new PowerRange { Id = 2, Range = "7-50" },
            new PowerRange { Id = 3, Range = "50-150" }
        );

        // TimeRange
        modelBuilder.Entity<TimeRange>().HasData(
            new TimeRange { Id = 1, Range = "06:01–17:00" },
            new TimeRange { Id = 2, Range = "17:01–21:00" },
            new TimeRange { Id = 3, Range = "21:01–06:00" }
        );
        modelBuilder.Entity<ChargingPort>()
                .Property(c => c.Status)
                .HasConversion<string>();

        modelBuilder.Entity<ChargingPoint>()
                .HasMany(p => p.ChargingPorts)
                .WithOne(c => c.ChargingPoint)
                .HasForeignKey(c => c.PointId);

        modelBuilder.Entity<ChargingPoint>().HasData(
        // Station 1
        new ChargingPoint { Id = "1.1", StationId = 1 },
        new ChargingPoint { Id = "1.2", StationId = 1 },
        new ChargingPoint { Id = "1.3", StationId = 1 },
        new ChargingPoint { Id = "1.4", StationId = 1 },
        new ChargingPoint { Id = "1.5", StationId = 1 },
        new ChargingPoint { Id = "1.6", StationId = 1 },
        new ChargingPoint { Id = "1.7", StationId = 1 },

        // Station 2
        new ChargingPoint { Id = "2.1", StationId = 2 },
        new ChargingPoint { Id = "2.2", StationId = 2 },
        new ChargingPoint { Id = "2.3", StationId = 2 },
        new ChargingPoint { Id = "2.4", StationId = 2 },
        new ChargingPoint { Id = "2.5", StationId = 2 },
        new ChargingPoint { Id = "2.6", StationId = 2 },
        new ChargingPoint { Id = "2.7", StationId = 2 },
        new ChargingPoint { Id = "2.8", StationId = 2 },
        new ChargingPoint { Id = "2.9", StationId = 2 },
        new ChargingPoint { Id = "2.10", StationId = 2 },

        // Station 3
        new ChargingPoint { Id = "3.1", StationId = 3 },
        new ChargingPoint { Id = "3.2", StationId = 3 },
        new ChargingPoint { Id = "3.3", StationId = 3 },
        new ChargingPoint { Id = "3.4", StationId = 3 },
        new ChargingPoint { Id = "3.5", StationId = 3 },
        new ChargingPoint { Id = "3.6", StationId = 3 },
        new ChargingPoint { Id = "3.7", StationId = 3 },
        new ChargingPoint { Id = "3.8", StationId = 3 },
        new ChargingPoint { Id = "3.9", StationId = 3 },
        new ChargingPoint { Id = "3.10", StationId = 3 },

        // Station 4
        new ChargingPoint { Id = "4.1", StationId = 4 },
        new ChargingPoint { Id = "4.2", StationId = 4 },
        new ChargingPoint { Id = "4.3", StationId = 4 },
        new ChargingPoint { Id = "4.4", StationId = 4 },
        new ChargingPoint { Id = "4.5", StationId = 4 },
        new ChargingPoint { Id = "4.6", StationId = 4 },
        new ChargingPoint { Id = "4.7", StationId = 4 },
        new ChargingPoint { Id = "4.8", StationId = 4 },
        new ChargingPoint { Id = "4.9", StationId = 4 },
        new ChargingPoint { Id = "4.10", StationId = 4 },

        // Station 5
        new ChargingPoint { Id = "5.1", StationId = 5 },
        new ChargingPoint { Id = "5.2", StationId = 5 },
        new ChargingPoint { Id = "5.3", StationId = 5 },
        new ChargingPoint { Id = "5.4", StationId = 5 },
        new ChargingPoint { Id = "5.5", StationId = 5 },
        new ChargingPoint { Id = "5.6", StationId = 5 },
        new ChargingPoint { Id = "5.7", StationId = 5 },
        new ChargingPoint { Id = "5.8", StationId = 5 },
        new ChargingPoint { Id = "5.9", StationId = 5 },
        new ChargingPoint { Id = "5.10", StationId = 5 },

        // Station 6
        new ChargingPoint { Id = "6.1", StationId = 6 },
        new ChargingPoint { Id = "6.2", StationId = 6 },
        new ChargingPoint { Id = "6.3", StationId = 6 },
        new ChargingPoint { Id = "6.4", StationId = 6 },
        new ChargingPoint { Id = "6.5", StationId = 6 },
        new ChargingPoint { Id = "6.6", StationId = 6 },
        new ChargingPoint { Id = "6.7", StationId = 6 },
        new ChargingPoint { Id = "6.8", StationId = 6 },
        new ChargingPoint { Id = "6.9", StationId = 6 },
        new ChargingPoint { Id = "6.10", StationId = 6 },

        // Station 7
        new ChargingPoint { Id = "7.1", StationId = 7 },
        new ChargingPoint { Id = "7.2", StationId = 7 },
        new ChargingPoint { Id = "7.3", StationId = 7 },
        new ChargingPoint { Id = "7.4", StationId = 7 },
        new ChargingPoint { Id = "7.5", StationId = 7 },
        new ChargingPoint { Id = "7.6", StationId = 7 },
        new ChargingPoint { Id = "7.7", StationId = 7 },
        new ChargingPoint { Id = "7.8", StationId = 7 },
        new ChargingPoint { Id = "7.9", StationId = 7 },
        new ChargingPoint { Id = "7.10", StationId = 7 }
    );


        // ChargingPort
        // ===== Station 1 =====
        modelBuilder.Entity<ChargingPort>().HasData(
            // Point 1.1
            new ChargingPort { Id = "1.1.1", PointId = "1.1", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.1.2", PointId = "1.1", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "1.1.3", PointId = "1.1", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Available },

            // Point 1.2
            new ChargingPort { Id = "1.2.1", PointId = "1.2", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.2.2", PointId = "1.2", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.Faulty },
            new ChargingPort { Id = "1.2.3", PointId = "1.2", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.InUse },

            // Point 1.3
            new ChargingPort { Id = "1.3.1", PointId = "1.3", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "1.3.2", PointId = "1.3", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.3.3", PointId = "1.3", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Available },

            // Point 1.4
            new ChargingPort { Id = "1.4.1", PointId = "1.4", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.4.2", PointId = "1.4", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.4.3", PointId = "1.4", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            // Point 1.5
            new ChargingPort { Id = "1.5.1", PointId = "1.5", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.5.2", PointId = "1.5", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "1.5.3", PointId = "1.5", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Available },

            // Point 1.6
            new ChargingPort { Id = "1.6.1", PointId = "1.6", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "1.6.2", PointId = "1.6", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.6.3", PointId = "1.6", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Available },

            // Point 1.7
            new ChargingPort { Id = "1.7.1", PointId = "1.7", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.7.2", PointId = "1.7", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.Faulty },
            new ChargingPort { Id = "1.7.3", PointId = "1.7", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.InUse },


            // ================= Station 2 =================
            new ChargingPort { Id = "2.1.1", PointId = "2.1", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.1.2", PointId = "2.1", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.1.3", PointId = "2.1", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.2.1", PointId = "2.2", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.2.2", PointId = "2.2", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.2.3", PointId = "2.2", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.3.1", PointId = "2.3", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.3.2", PointId = "2.3", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.3.3", PointId = "2.3", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.4.1", PointId = "2.4", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.4.2", PointId = "2.4", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.4.3", PointId = "2.4", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.5.1", PointId = "2.5", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.5.2", PointId = "2.5", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.5.3", PointId = "2.5", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.6.1", PointId = "2.6", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.6.2", PointId = "2.6", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.6.3", PointId = "2.6", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.7.1", PointId = "2.7", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.7.2", PointId = "2.7", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.7.3", PointId = "2.7", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.8.1", PointId = "2.8", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.8.2", PointId = "2.8", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.8.3", PointId = "2.8", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.9.1", PointId = "2.9", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.9.2", PointId = "2.9", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.9.3", PointId = "2.9", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "2.10.1", PointId = "2.10", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.10.2", PointId = "2.10", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "2.10.3", PointId = "2.10", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            // ================= Station 3 =================
            new ChargingPort { Id = "3.1.1", PointId = "3.1", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.1.2", PointId = "3.1", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.1.3", PointId = "3.1", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.2.1", PointId = "3.2", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.2.2", PointId = "3.2", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.2.3", PointId = "3.2", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.3.1", PointId = "3.3", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.3.2", PointId = "3.3", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.3.3", PointId = "3.3", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.4.1", PointId = "3.4", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.4.2", PointId = "3.4", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.4.3", PointId = "3.4", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.5.1", PointId = "3.5", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.5.2", PointId = "3.5", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.5.3", PointId = "3.5", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.6.1", PointId = "3.6", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.6.2", PointId = "3.6", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.6.3", PointId = "3.6", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.7.1", PointId = "3.7", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.7.2", PointId = "3.7", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.7.3", PointId = "3.7", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.8.1", PointId = "3.8", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.8.2", PointId = "3.8", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.8.3", PointId = "3.8", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.9.1", PointId = "3.9", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.9.2", PointId = "3.9", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.9.3", PointId = "3.9", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "3.10.1", PointId = "3.10", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.10.2", PointId = "3.10", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "3.10.3", PointId = "3.10", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },


            // ================= Station 4 =================
            new ChargingPort { Id = "4.1.1", PointId = "4.1", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.1.2", PointId = "4.1", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.1.3", PointId = "4.1", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.2.1", PointId = "4.2", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.2.2", PointId = "4.2", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.2.3", PointId = "4.2", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.3.1", PointId = "4.3", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.3.2", PointId = "4.3", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.3.3", PointId = "4.3", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.4.1", PointId = "4.4", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.4.2", PointId = "4.4", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.4.3", PointId = "4.4", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.5.1", PointId = "4.5", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.5.2", PointId = "4.5", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.5.3", PointId = "4.5", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.6.1", PointId = "4.6", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.6.2", PointId = "4.6", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.6.3", PointId = "4.6", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.7.1", PointId = "4.7", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.7.2", PointId = "4.7", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.7.3", PointId = "4.7", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.8.1", PointId = "4.8", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.8.2", PointId = "4.8", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.8.3", PointId = "4.8", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.9.1", PointId = "4.9", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.9.2", PointId = "4.9", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.9.3", PointId = "4.9", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "4.10.1", PointId = "4.10", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.10.2", PointId = "4.10", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "4.10.3", PointId = "4.10", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },


            // ================= Station 5 =================
            new ChargingPort { Id = "5.1.1", PointId = "5.1", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.1.2", PointId = "5.1", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.1.3", PointId = "5.1", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.2.1", PointId = "5.2", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.2.2", PointId = "5.2", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.2.3", PointId = "5.2", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.3.1", PointId = "5.3", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.3.2", PointId = "5.3", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.3.3", PointId = "5.3", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.4.1", PointId = "5.4", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.4.2", PointId = "5.4", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.4.3", PointId = "5.4", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.5.1", PointId = "5.5", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.5.2", PointId = "5.5", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.5.3", PointId = "5.5", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.6.1", PointId = "5.6", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.6.2", PointId = "5.6", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.6.3", PointId = "5.6", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.7.1", PointId = "5.7", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.7.2", PointId = "5.7", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.7.3", PointId = "5.7", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.8.1", PointId = "5.8", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.8.2", PointId = "5.8", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.8.3", PointId = "5.8", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.9.1", PointId = "5.9", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.9.2", PointId = "5.9", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.9.3", PointId = "5.9", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "5.10.1", PointId = "5.10", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.10.2", PointId = "5.10", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "5.10.3", PointId = "5.10", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },


            // ================= Station 6 =================
            new ChargingPort { Id = "6.1.1", PointId = "6.1", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.1.2", PointId = "6.1", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.1.3", PointId = "6.1", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.2.1", PointId = "6.2", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.2.2", PointId = "6.2", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.2.3", PointId = "6.2", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.3.1", PointId = "6.3", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.3.2", PointId = "6.3", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.3.3", PointId = "6.3", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.4.1", PointId = "6.4", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.4.2", PointId = "6.4", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.4.3", PointId = "6.4", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.5.1", PointId = "6.5", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.5.2", PointId = "6.5", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.5.3", PointId = "6.5", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.6.1", PointId = "6.6", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.6.2", PointId = "6.6", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.6.3", PointId = "6.6", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.7.1", PointId = "6.7", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.7.2", PointId = "6.7", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.7.3", PointId = "6.7", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.8.1", PointId = "6.8", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.8.2", PointId = "6.8", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.8.3", PointId = "6.8", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.9.1", PointId = "6.9", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.9.2", PointId = "6.9", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.9.3", PointId = "6.9", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "6.10.1", PointId = "6.10", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.10.2", PointId = "6.10", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "6.10.3", PointId = "6.10", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },


            // ================= Station 7 =================
            new ChargingPort { Id = "7.1.1", PointId = "7.1", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.1.2", PointId = "7.1", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.1.3", PointId = "7.1", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.2.1", PointId = "7.2", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.2.2", PointId = "7.2", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.2.3", PointId = "7.2", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.3.1", PointId = "7.3", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.3.2", PointId = "7.3", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.3.3", PointId = "7.3", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.4.1", PointId = "7.4", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.4.2", PointId = "7.4", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.4.3", PointId = "7.4", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.5.1", PointId = "7.5", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.5.2", PointId = "7.5", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.5.3", PointId = "7.5", ConnectorId = 3, Power = 50, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.6.1", PointId = "7.6", ConnectorId = 1, Power = 7, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.6.2", PointId = "7.6", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.6.3", PointId = "7.6", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.7.1", PointId = "7.7", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.7.2", PointId = "7.7", ConnectorId = 2, Power = 7, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.7.3", PointId = "7.7", ConnectorId = 3, Power = 150, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.8.1", PointId = "7.8", ConnectorId = 1, Power = 22, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.8.2", PointId = "7.8", ConnectorId = 2, Power = 50, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.8.3", PointId = "7.8", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.9.1", PointId = "7.9", ConnectorId = 1, Power = 150, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.9.2", PointId = "7.9", ConnectorId = 2, Power = 22, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.9.3", PointId = "7.9", ConnectorId = 3, Power = 7, Status = ChargingPortStatus.Faulty },

            new ChargingPort { Id = "7.10.1", PointId = "7.10", ConnectorId = 1, Power = 50, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.10.2", PointId = "7.10", ConnectorId = 2, Power = 150, Status = ChargingPortStatus.InUse },
            new ChargingPort { Id = "7.10.3", PointId = "7.10", ConnectorId = 3, Power = 22, Status = ChargingPortStatus.Faulty }
            );

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { VehicleId = 1, Name = "Tesla Model 3", VehicleTypeId = 2, LicensePlate = "51B-67890", BatteryCapacity = 75 },
            new Vehicle { VehicleId = 2, Name = "VinFast VF 8", VehicleTypeId = 2, LicensePlate = "30A-12345", BatteryCapacity = 82 },
            new Vehicle { VehicleId = 3, Name = "Nissan Leaf", VehicleTypeId = 2, LicensePlate = "29C-56789", BatteryCapacity = 40 },
            new Vehicle { VehicleId = 4, Name = "Hyundai Ioniq 5", VehicleTypeId = 2, LicensePlate = "88D-45678", BatteryCapacity = 77 },
            new Vehicle { VehicleId = 5, Name = "Kia EV6", VehicleTypeId = 2, LicensePlate = "77E-99999", BatteryCapacity = 74 }
        );


        modelBuilder.Entity<VehiclePort>().HasKey(vp => new { vp.VehicleId, vp.ConnectorId });

        modelBuilder.Entity<VehiclePort>().HasData(
            new VehiclePort { VehicleId = 1, ConnectorId = 1 },
            new VehiclePort { VehicleId = 1, ConnectorId = 2 },

            new VehiclePort { VehicleId = 2, ConnectorId = 2 },
            new VehiclePort { VehicleId = 2, ConnectorId = 3 },

            new VehiclePort { VehicleId = 3, ConnectorId = 3 },
            new VehiclePort { VehicleId = 3, ConnectorId = 2 },

            new VehiclePort { VehicleId = 4, ConnectorId = 1 },

            new VehiclePort { VehicleId = 5, ConnectorId = 2 },
            new VehiclePort { VehicleId = 5, ConnectorId = 1 }
        );

        modelBuilder.Entity<VehicleConnectorType>().HasKey(vtc => new { vtc.VehicleId, vtc.ConnectorId });

        modelBuilder.Entity<VehicleConnectorType>().HasData(
            new VehicleConnectorType { VehicleId = 1, ConnectorId = 1 },
            new VehicleConnectorType { VehicleId = 1, ConnectorId = 2 },

            new VehicleConnectorType { VehicleId = 2, ConnectorId = 2 },
            new VehicleConnectorType { VehicleId = 2, ConnectorId = 1 },

            new VehicleConnectorType { VehicleId = 3, ConnectorId = 1 },
            new VehicleConnectorType { VehicleId = 3, ConnectorId = 2 }
        );
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    public DbSet<Connector> Connectors { get; set; } = null!;
    public DbSet<PowerRange> PowerRanges { get; set; } = null!;
    public DbSet<TimeRange> TimeRanges { get; set; } = null!;
    public DbSet<ChargingPoint> ChargingPoints { get; set; } = null!;
    public DbSet<ChargingPort> ChargingPorts { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<VehiclePort> VehiclePorts { get; set; } = null!;
    public DbSet<VehicleConnectorType> VehicleConnectorTypes { get; set; } = null!;
    
    public DbSet<ChargingSession> ChargingSessions { get; set; } = null!;
}
