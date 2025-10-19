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
            new Customer { Id = "C010", Name = "Lê Thị Hòa", Email = "hoa.le@example.com", PhoneNumber = "0905566778", Address = "Quận Phú Nhuận, TP.HCM" },
            new Customer { Id = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Nguyen Xuan Thinh", Email = "nguyenxuanthinh@gmail.com", PhoneNumber = "0901234567", Address = "Quận 1, TP.HCM" }
        );

        modelBuilder.Entity<ChargingStation>().HasData(
            new ChargingStation
            {
                Id = 1,
                Name = "Parking lot S778 Nguyen Van Qua",
                Location = "778 Nguyen Van Qua, Dong Hung Thuan Ward, District 12, Ho Chi Minh City",
                Latitude = 10.846289725256499,
                Longitude = 106.63358659588795,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 2,
                Name = "Léman Luxury Apartments",
                Location = "Basement B3, Léman Luxury Apartments, 117 Nguyễn Đình Chiểu, Ward 6, District 3, Ho Chi Minh City",
                Latitude = 10.778019786911162,
                Longitude = 106.68989161819898,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 3,
                Name = "Summer Square Apartment Complex",
                Location = "243 Tan Hoa Dong, Ward 14, District 6, Ho Chi Minh City",
                Latitude = 10.759974990301892,
                Longitude = 106.62537124357758,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 4,
                Name = "Golden King Apartment Complex",
                Location = "Basement B2, 15 Nguyen Luong Bang, Tan Phu Ward, District 7, Ho Chi Minh City",
                Latitude = 10.726400325147486,
                Longitude = 106.72395755358133,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 5,
                Name = "TTTM VinCom+ Nam Long",
                Location = "71 Tran Trong Cung, Tan Thuan Dong Ward, District 7, Ho Chi Minh City",
                Latitude = 10.744180504637178,
                Longitude = 106.73212781504205,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 6,
                Name = "VinFast - Chevrolet Phu My Hung Car Dealership",
                Location = "54 Nguyen Thi Thap, Binh Thuan Ward, District 7, Ho Chi Minh City",
                Latitude = 10.73838097555118,
                Longitude = 106.72723544339814,
                Status = ChargingStationStatus.Active
            },
            new ChargingStation
            {
                Id = 7,
                Name = "Green View Apartment Complex",
                Location = "Green View, Tân Phú Ward, District 7, Ho Chi Minh City",
                Latitude = 10.721662104756106,
                Longitude = 106.72691002973274,
                Status = ChargingStationStatus.Active
            }
        );

    modelBuilder.Entity<Vehicle>()
    .Property(v => v.Status)
    .HasConversion<string>();

        // VehicleType
        modelBuilder.Entity<VehicleType>().HasData(
            new VehicleType { Id = 1, Name = "Motorbike" },
            new VehicleType { Id = 2, Name = "Car" }
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
        new ChargingPoint { Id = "1.1", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.2", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.3", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.4", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.5", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.6", StationId = 1, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "1.7", StationId = 1, Status = ChargingPointStatus.Active },

        // Station 2
        new ChargingPoint { Id = "2.1", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.2", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.3", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.4", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.5", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.6", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.7", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.8", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.9", StationId = 2, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "2.10", StationId = 2, Status = ChargingPointStatus.Active },

        // Station 3
        new ChargingPoint { Id = "3.1", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.2", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.3", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.4", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.5", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.6", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.7", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.8", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.9", StationId = 3, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "3.10", StationId = 3, Status = ChargingPointStatus.Active },

        // Station 4
        new ChargingPoint { Id = "4.1", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.2", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.3", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.4", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.5", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.6", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.7", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.8", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.9", StationId = 4, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "4.10", StationId = 4, Status = ChargingPointStatus.Active },

        // Station 5
        new ChargingPoint { Id = "5.1", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.2", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.3", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.4", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.5", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.6", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.7", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.8", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.9", StationId = 5, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "5.10", StationId = 5, Status = ChargingPointStatus.Active },

        // Station 6
        new ChargingPoint { Id = "6.1", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.2", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.3", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.4", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.5", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.6", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.7", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.8", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.9", StationId = 6, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "6.10", StationId = 6, Status = ChargingPointStatus.Active },

        // Station 7
        new ChargingPoint { Id = "7.1", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.2", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.3", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.4", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.5", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.6", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.7", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.8", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.9", StationId = 7, Status = ChargingPointStatus.Active },
        new ChargingPoint { Id = "7.10", StationId = 7, Status = ChargingPointStatus.Active }
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
            new Vehicle { VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Tesla Model 3", VehicleTypeId = 2, LicensePlate = "51B-67890", BatteryCapacity = 75, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "VinFast VF 8", VehicleTypeId = 2, LicensePlate = "30A-12345", BatteryCapacity = 82, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 3, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Nissan Leaf", VehicleTypeId = 2, LicensePlate = "29C-56789", BatteryCapacity = 40, Status = VehicleStatus.Blocked },
            new Vehicle { VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Hyundai Ioniq 5", VehicleTypeId = 2, LicensePlate = "88D-45678", BatteryCapacity = 77, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 5, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Kia EV6", VehicleTypeId = 2, LicensePlate = "77E-99999", BatteryCapacity = 74, Status = VehicleStatus.Blocked }
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

        modelBuilder.Entity<PriceTable>().HasData(
            new PriceTable { Id = 1, PricePerKWh = 3500, PenaltyFeePerMinute = 800, ValidFrom = new DateTime(2023, 1, 1), ValidTo = new DateTime(2024, 3, 18), Status = PriceTableStatus.Inactive },
            new PriceTable { Id = 2, PricePerKWh = 3858, PenaltyFeePerMinute = 1000, ValidFrom = new DateTime(2024, 3, 19), ValidTo = new DateTime(2025, 12, 31), Status = PriceTableStatus.Active },
            new PriceTable { Id = 3, PricePerKWh = 4000, PenaltyFeePerMinute = 1200, ValidFrom = new DateTime(2026, 1, 1), ValidTo = new DateTime(2027, 12, 31), Status = PriceTableStatus.Inactive }
        );

        // ChargingSession seed data - July to October 2025
        modelBuilder.Entity<ChargingSession>().HasData(
            // July 2025 sessions
            new ChargingSession { Id = 1, VehicleId = 1, PortId = "1.1.1", StartTime = new DateTime(2025, 7, 3, 8, 15, 0), EndTime = new DateTime(2025, 7, 3, 10, 30, 0), EnergyConsumed = 41.2f, TotalCost = 159000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 2, VehicleId = 1, PortId = "2.2.1", StartTime = new DateTime(2025, 7, 8, 14, 45, 0), EndTime = new DateTime(2025, 7, 8, 16, 20, 0), EnergyConsumed = 36.8f, TotalCost = 142000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 3, VehicleId = 1, PortId = "3.3.1", StartTime = new DateTime(2025, 7, 15, 9, 30, 0), EndTime = new DateTime(2025, 7, 15, 11, 15, 0), EnergyConsumed = 39.5f, TotalCost = 152000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 4, VehicleId = 1, PortId = "4.4.1", StartTime = new DateTime(2025, 7, 22, 16, 20, 0), EndTime = new DateTime(2025, 7, 22, 18, 35, 0), EnergyConsumed = 43.1f, TotalCost = 166000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 5, VehicleId = 1, PortId = "5.5.1", StartTime = new DateTime(2025, 7, 28, 12, 10, 0), EndTime = new DateTime(2025, 7, 28, 14, 25, 0), EnergyConsumed = 41.7f, TotalCost = 161000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 6, VehicleId = 2, PortId = "1.2.2", StartTime = new DateTime(2025, 7, 5, 11, 20, 0), EndTime = new DateTime(2025, 7, 5, 13, 45, 0), EnergyConsumed = 47.3f, TotalCost = 182000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 7, VehicleId = 2, PortId = "2.4.1", StartTime = new DateTime(2025, 7, 12, 16, 10, 0), EndTime = new DateTime(2025, 7, 12, 18, 25, 0), EnergyConsumed = 43.7f, TotalCost = 168000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 8, VehicleId = 2, PortId = "3.5.1", StartTime = new DateTime(2025, 7, 18, 7, 45, 0), EndTime = new DateTime(2025, 7, 18, 9, 30, 0), EnergyConsumed = 38.1f, TotalCost = 147000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 9, VehicleId = 2, PortId = "4.6.1", StartTime = new DateTime(2025, 7, 25, 15, 30, 0), EndTime = new DateTime(2025, 7, 25, 17, 45, 0), EnergyConsumed = 45.2f, TotalCost = 174000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 10, VehicleId = 3, PortId = "1.3.1", StartTime = new DateTime(2025, 7, 4, 13, 30, 0), EndTime = new DateTime(2025, 7, 4, 15, 45, 0), EnergyConsumed = 31.2f, TotalCost = 120000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 11, VehicleId = 3, PortId = "2.6.1", StartTime = new DateTime(2025, 7, 11, 10, 15, 0), EndTime = new DateTime(2025, 7, 11, 11, 50, 0), EnergyConsumed = 28.9f, TotalCost = 111000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 12, VehicleId = 3, PortId = "3.7.1", StartTime = new DateTime(2025, 7, 19, 17, 20, 0), EndTime = new DateTime(2025, 7, 19, 19, 35, 0), EnergyConsumed = 33.1f, TotalCost = 127000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 13, VehicleId = 4, PortId = "1.4.2", StartTime = new DateTime(2025, 7, 6, 12, 45, 0), EndTime = new DateTime(2025, 7, 6, 14, 30, 0), EnergyConsumed = 40.6f, TotalCost = 156000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 14, VehicleId = 4, PortId = "2.7.1", StartTime = new DateTime(2025, 7, 14, 17, 20, 0), EndTime = new DateTime(2025, 7, 14, 19, 10, 0), EnergyConsumed = 42.3f, TotalCost = 163000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 15, VehicleId = 4, PortId = "3.8.1", StartTime = new DateTime(2025, 7, 20, 8, 30, 0), EndTime = new DateTime(2025, 7, 20, 10, 45, 0), EnergyConsumed = 37.8f, TotalCost = 146000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 16, VehicleId = 4, PortId = "4.9.1", StartTime = new DateTime(2025, 7, 26, 14, 15, 0), EndTime = new DateTime(2025, 7, 26, 16, 30, 0), EnergyConsumed = 44.7f, TotalCost = 172000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 17, VehicleId = 5, PortId = "1.5.1", StartTime = new DateTime(2025, 7, 7, 15, 40, 0), EndTime = new DateTime(2025, 7, 7, 17, 55, 0), EnergyConsumed = 45.1f, TotalCost = 174000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 18, VehicleId = 5, PortId = "2.8.1", StartTime = new DateTime(2025, 7, 16, 9, 15, 0), EndTime = new DateTime(2025, 7, 16, 11, 30, 0), EnergyConsumed = 41.7f, TotalCost = 161000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 19, VehicleId = 5, PortId = "3.9.1", StartTime = new DateTime(2025, 7, 23, 18, 45, 0), EndTime = new DateTime(2025, 7, 23, 21, 0, 0), EnergyConsumed = 47.8f, TotalCost = 184000, Status = SessionStatus.Completed },

            // August 2025 sessions
            new ChargingSession { Id = 20, VehicleId = 1, PortId = "1.1.2", StartTime = new DateTime(2025, 8, 2, 9, 15, 0), EndTime = new DateTime(2025, 8, 2, 11, 30, 0), EnergyConsumed = 40.2f, TotalCost = 155000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 21, VehicleId = 1, PortId = "2.2.2", StartTime = new DateTime(2025, 8, 9, 14, 45, 0), EndTime = new DateTime(2025, 8, 9, 16, 20, 0), EnergyConsumed = 37.6f, TotalCost = 145000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 22, VehicleId = 1, PortId = "3.3.2", StartTime = new DateTime(2025, 8, 16, 8, 30, 0), EndTime = new DateTime(2025, 8, 16, 10, 45, 0), EnergyConsumed = 38.9f, TotalCost = 150000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 23, VehicleId = 1, PortId = "4.4.2", StartTime = new DateTime(2025, 8, 23, 17, 20, 0), EndTime = new DateTime(2025, 8, 23, 19, 35, 0), EnergyConsumed = 43.1f, TotalCost = 166000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 24, VehicleId = 1, PortId = "5.5.2", StartTime = new DateTime(2025, 8, 30, 12, 10, 0), EndTime = new DateTime(2025, 8, 30, 14, 25, 0), EnergyConsumed = 41.7f, TotalCost = 161000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 25, VehicleId = 2, PortId = "1.2.3", StartTime = new DateTime(2025, 8, 4, 11, 30, 0), EndTime = new DateTime(2025, 8, 4, 14, 15, 0), EnergyConsumed = 48.9f, TotalCost = 188000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 26, VehicleId = 2, PortId = "2.3.3", StartTime = new DateTime(2025, 8, 11, 16, 45, 0), EndTime = new DateTime(2025, 8, 11, 18, 30, 0), EnergyConsumed = 44.2f, TotalCost = 170000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 27, VehicleId = 2, PortId = "3.4.3", StartTime = new DateTime(2025, 8, 18, 9, 20, 0), EndTime = new DateTime(2025, 8, 18, 11, 45, 0), EnergyConsumed = 46.5f, TotalCost = 179000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 28, VehicleId = 2, PortId = "4.5.3", StartTime = new DateTime(2025, 8, 25, 15, 15, 0), EndTime = new DateTime(2025, 8, 25, 17, 40, 0), EnergyConsumed = 42.8f, TotalCost = 165000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 29, VehicleId = 3, PortId = "1.3.2", StartTime = new DateTime(2025, 8, 6, 13, 45, 0), EndTime = new DateTime(2025, 8, 6, 15, 30, 0), EnergyConsumed = 31.8f, TotalCost = 122000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 30, VehicleId = 3, PortId = "2.4.2", StartTime = new DateTime(2025, 8, 13, 10, 30, 0), EndTime = new DateTime(2025, 8, 13, 12, 15, 0), EnergyConsumed = 29.4f, TotalCost = 113000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 31, VehicleId = 3, PortId = "3.5.2", StartTime = new DateTime(2025, 8, 20, 17, 20, 0), EndTime = new DateTime(2025, 8, 20, 19, 35, 0), EnergyConsumed = 33.1f, TotalCost = 127000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 32, VehicleId = 4, PortId = "1.4.1", StartTime = new DateTime(2025, 8, 3, 8, 45, 0), EndTime = new DateTime(2025, 8, 3, 11, 10, 0), EnergyConsumed = 44.6f, TotalCost = 172000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 33, VehicleId = 4, PortId = "2.5.1", StartTime = new DateTime(2025, 8, 10, 14, 20, 0), EndTime = new DateTime(2025, 8, 10, 16, 45, 0), EnergyConsumed = 41.3f, TotalCost = 159000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 34, VehicleId = 4, PortId = "3.6.1", StartTime = new DateTime(2025, 8, 17, 11, 15, 0), EndTime = new DateTime(2025, 8, 17, 13, 30, 0), EnergyConsumed = 38.7f, TotalCost = 149000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 35, VehicleId = 4, PortId = "4.7.1", StartTime = new DateTime(2025, 8, 24, 16, 30, 0), EndTime = new DateTime(2025, 8, 24, 18, 45, 0), EnergyConsumed = 42.9f, TotalCost = 165000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 36, VehicleId = 5, PortId = "1.5.2", StartTime = new DateTime(2025, 8, 5, 12, 30, 0), EndTime = new DateTime(2025, 8, 5, 15, 15, 0), EnergyConsumed = 49.2f, TotalCost = 200000, Status = SessionStatus.Completed },

            // September 2025 sessions
            new ChargingSession { Id = 37, VehicleId = 1, PortId = "1.1.3", StartTime = new DateTime(2025, 9, 2, 9, 15, 0), EndTime = new DateTime(2025, 9, 2, 11, 30, 0), EnergyConsumed = 40.2f, TotalCost = 155000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 38, VehicleId = 1, PortId = "2.2.1", StartTime = new DateTime(2025, 9, 8, 14, 45, 0), EndTime = new DateTime(2025, 9, 8, 16, 20, 0), EnergyConsumed = 37.6f, TotalCost = 145000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 39, VehicleId = 1, PortId = "3.3.3", StartTime = new DateTime(2025, 9, 15, 8, 30, 0), EndTime = new DateTime(2025, 9, 15, 10, 45, 0), EnergyConsumed = 38.9f, TotalCost = 150000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 40, VehicleId = 1, PortId = "4.4.3", StartTime = new DateTime(2025, 9, 22, 17, 20, 0), EndTime = new DateTime(2025, 9, 22, 19, 35, 0), EnergyConsumed = 43.1f, TotalCost = 166000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 41, VehicleId = 1, PortId = "5.5.3", StartTime = new DateTime(2025, 9, 29, 12, 10, 0), EndTime = new DateTime(2025, 9, 29, 14, 25, 0), EnergyConsumed = 41.7f, TotalCost = 161000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 42, VehicleId = 2, PortId = "1.2.1", StartTime = new DateTime(2025, 9, 4, 11, 30, 0), EndTime = new DateTime(2025, 9, 4, 14, 15, 0), EnergyConsumed = 48.9f, TotalCost = 188000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 43, VehicleId = 2, PortId = "2.3.1", StartTime = new DateTime(2025, 9, 11, 16, 45, 0), EndTime = new DateTime(2025, 9, 11, 18, 30, 0), EnergyConsumed = 44.2f, TotalCost = 170000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 44, VehicleId = 2, PortId = "3.4.1", StartTime = new DateTime(2025, 9, 18, 9, 20, 0), EndTime = new DateTime(2025, 9, 18, 11, 45, 0), EnergyConsumed = 46.5f, TotalCost = 179000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 45, VehicleId = 2, PortId = "4.5.1", StartTime = new DateTime(2025, 9, 25, 15, 15, 0), EndTime = new DateTime(2025, 9, 25, 17, 40, 0), EnergyConsumed = 42.8f, TotalCost = 165000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 46, VehicleId = 3, PortId = "1.3.3", StartTime = new DateTime(2025, 9, 6, 13, 45, 0), EndTime = new DateTime(2025, 9, 6, 15, 30, 0), EnergyConsumed = 31.8f, TotalCost = 122000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 47, VehicleId = 3, PortId = "2.4.3", StartTime = new DateTime(2025, 9, 13, 10, 30, 0), EndTime = new DateTime(2025, 9, 13, 12, 15, 0), EnergyConsumed = 29.4f, TotalCost = 113000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 48, VehicleId = 3, PortId = "3.5.3", StartTime = new DateTime(2025, 9, 20, 17, 20, 0), EndTime = new DateTime(2025, 9, 20, 19, 35, 0), EnergyConsumed = 33.1f, TotalCost = 127000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 49, VehicleId = 4, PortId = "1.4.3", StartTime = new DateTime(2025, 9, 3, 8, 45, 0), EndTime = new DateTime(2025, 9, 3, 11, 10, 0), EnergyConsumed = 44.6f, TotalCost = 172000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 50, VehicleId = 4, PortId = "2.5.2", StartTime = new DateTime(2025, 9, 10, 14, 20, 0), EndTime = new DateTime(2025, 9, 10, 16, 45, 0), EnergyConsumed = 41.3f, TotalCost = 159000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 51, VehicleId = 4, PortId = "3.6.2", StartTime = new DateTime(2025, 9, 17, 11, 15, 0), EndTime = new DateTime(2025, 9, 17, 13, 30, 0), EnergyConsumed = 38.7f, TotalCost = 149000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 52, VehicleId = 4, PortId = "4.7.2", StartTime = new DateTime(2025, 9, 24, 16, 30, 0), EndTime = new DateTime(2025, 9, 24, 18, 45, 0), EnergyConsumed = 42.9f, TotalCost = 165000, Status = SessionStatus.Completed },
            

            // October 2025 sessions (up to 12th)
            new ChargingSession { Id = 53, VehicleId = 1, PortId = "1.1.1", StartTime = new DateTime(2025, 10, 2, 9, 15, 0), EndTime = new DateTime(2025, 10, 2, 11, 30, 0), EnergyConsumed = 40.2f, TotalCost = 155000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 54, VehicleId = 1, PortId = "2.2.2", StartTime = new DateTime(2025, 10, 8, 14, 45, 0), EndTime = new DateTime(2025, 10, 8, 16, 20, 0), EnergyConsumed = 37.6f, TotalCost = 145000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 55, VehicleId = 1, PortId = "3.3.1", StartTime = new DateTime(2025, 10, 11, 8, 30, 0), EndTime = new DateTime(2025, 10, 11, 10, 45, 0), EnergyConsumed = 38.9f, TotalCost = 150000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 56, VehicleId = 2, PortId = "1.2.2", StartTime = new DateTime(2025, 10, 3, 11, 30, 0), EndTime = new DateTime(2025, 10, 3, 14, 15, 0), EnergyConsumed = 48.9f, TotalCost = 188000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 57, VehicleId = 2, PortId = "2.3.3", StartTime = new DateTime(2025, 10, 9, 16, 45, 0), EndTime = new DateTime(2025, 10, 9, 18, 30, 0), EnergyConsumed = 44.2f, TotalCost = 170000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 58, VehicleId = 3, PortId = "1.3.1", StartTime = new DateTime(2025, 10, 5, 13, 45, 0), EndTime = new DateTime(2025, 10, 5, 15, 30, 0), EnergyConsumed = 31.8f, TotalCost = 122000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 59, VehicleId = 3, PortId = "2.4.1", StartTime = new DateTime(2025, 10, 10, 10, 30, 0), EndTime = new DateTime(2025, 10, 10, 12, 15, 0), EnergyConsumed = 29.4f, TotalCost = 113000, Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 60, VehicleId = 4, PortId = "1.4.1", StartTime = new DateTime(2025, 10, 4, 8, 45, 0), EndTime = new DateTime(2025, 10, 4, 11, 10, 0), EnergyConsumed = 44.6f, TotalCost = 172000, Status = SessionStatus.Completed },
            new ChargingSession { Id = 61, VehicleId = 4, PortId = "2.5.1", StartTime = new DateTime(2025, 10, 7, 14, 20, 0), EndTime = new DateTime(2025, 10, 7, 16, 45, 0), EnergyConsumed = 41.3f, TotalCost = 159000, Status = SessionStatus.Completed }
            
        );

        // VehiclePerMonth seed data - July to October 2025
        modelBuilder.Entity<VehiclePerMonth>().HasData(
            // July 2025 data (PeriodId = 19)
            new VehiclePerMonth { VehicleMonthId = 1, VehicleId = 1, PeriodId = 19, TotalSessions = 5, TotalEnergy = 202.3f, TotalCost = 780000, AmountPaid = 780000 }, 
            new VehiclePerMonth { VehicleMonthId = 2, VehicleId = 2, PeriodId = 19, TotalSessions = 4, TotalEnergy = 174.3f, TotalCost = 671000, AmountPaid = 671000 }, 
            new VehiclePerMonth { VehicleMonthId = 3, VehicleId = 3, PeriodId = 19, TotalSessions = 3, TotalEnergy = 93.2f, TotalCost = 358000, AmountPaid = 358000 }, 
            new VehiclePerMonth { VehicleMonthId = 4, VehicleId = 4, PeriodId = 19, TotalSessions = 4, TotalEnergy = 165.4f, TotalCost = 637000, AmountPaid = 637000 }, 
            new VehiclePerMonth { VehicleMonthId = 5, VehicleId = 5, PeriodId = 19, TotalSessions = 3, TotalEnergy = 134.6f, TotalCost = 519000, AmountPaid = 519000 }, 
            
            // August 2025 data (PeriodId = 20)
            new VehiclePerMonth { VehicleMonthId = 6, VehicleId = 1, PeriodId = 20, TotalSessions = 5, TotalEnergy = 201.5f, TotalCost = 777000, AmountPaid = 777000 }, 
            new VehiclePerMonth { VehicleMonthId = 7, VehicleId = 2, PeriodId = 20, TotalSessions = 4, TotalEnergy = 182.4f, TotalCost = 702000, AmountPaid = 702000 }, 
            new VehiclePerMonth { VehicleMonthId = 8, VehicleId = 3, PeriodId = 20, TotalSessions = 3, TotalEnergy = 94.3f, TotalCost = 362000, AmountPaid = 362000 }, 
            new VehiclePerMonth { VehicleMonthId = 9, VehicleId = 4, PeriodId = 20, TotalSessions = 4, TotalEnergy = 167.5f, TotalCost = 645000, AmountPaid = 645000 }, 
            new VehiclePerMonth { VehicleMonthId = 10, VehicleId = 5, PeriodId = 20, TotalSessions = 3, TotalEnergy = 138.4f, TotalCost = 534000, AmountPaid = 200000 }, 
            
            // September 2025 data (PeriodId = 21)
            new VehiclePerMonth { VehicleMonthId = 11, VehicleId = 1, PeriodId = 21, TotalSessions = 5, TotalEnergy = 201.5f, TotalCost = 777000, AmountPaid = 777000 }, 
            new VehiclePerMonth { VehicleMonthId = 12, VehicleId = 2, PeriodId = 21, TotalSessions = 4, TotalEnergy = 182.4f, TotalCost = 702000, AmountPaid = 702000 }, 
            new VehiclePerMonth { VehicleMonthId = 13, VehicleId = 3, PeriodId = 21, TotalSessions = 3, TotalEnergy = 94.3f, TotalCost = 362000, AmountPaid = 0 }, 
            new VehiclePerMonth { VehicleMonthId = 14, VehicleId = 4, PeriodId = 21, TotalSessions = 4, TotalEnergy = 167.5f, TotalCost = 645000, AmountPaid = 645000 }, 
            
            // October 2025 data (PeriodId = 22) 
            new VehiclePerMonth { VehicleMonthId = 16, VehicleId = 1, PeriodId = 22, TotalSessions = 3, TotalEnergy = 116.7f, TotalCost = 450000, AmountPaid = 0 }, 
            new VehiclePerMonth { VehicleMonthId = 17, VehicleId = 2, PeriodId = 22, TotalSessions = 2, TotalEnergy = 93.1f, TotalCost = 358000, AmountPaid = 0 }, 
            new VehiclePerMonth { VehicleMonthId = 18, VehicleId = 4, PeriodId = 22, TotalSessions = 2, TotalEnergy = 85.9f, TotalCost = 331000, AmountPaid = 0 }
        );

        // MonthlyPeriod seed data
        modelBuilder.Entity<MonthlyPeriod>().HasData(
            new MonthlyPeriod { PeriodId = 1, Month = 1, Year = 2024 },
            new MonthlyPeriod { PeriodId = 2, Month = 2, Year = 2024 },
            new MonthlyPeriod { PeriodId = 3, Month = 3, Year = 2024 },
            new MonthlyPeriod { PeriodId = 4, Month = 4, Year = 2024 },
            new MonthlyPeriod { PeriodId = 5, Month = 5, Year = 2024 },
            new MonthlyPeriod { PeriodId = 6, Month = 6, Year = 2024 },
            new MonthlyPeriod { PeriodId = 7, Month = 7, Year = 2024 },
            new MonthlyPeriod { PeriodId = 8, Month = 8, Year = 2024 },
            new MonthlyPeriod { PeriodId = 9, Month = 9, Year = 2024 },
            new MonthlyPeriod { PeriodId = 10, Month = 10, Year = 2024 },
            new MonthlyPeriod { PeriodId = 11, Month = 11, Year = 2024 },
            new MonthlyPeriod { PeriodId = 12, Month = 12, Year = 2024 },
            new MonthlyPeriod { PeriodId = 13, Month = 1, Year = 2025 },
            new MonthlyPeriod { PeriodId = 14, Month = 2, Year = 2025 },
            new MonthlyPeriod { PeriodId = 15, Month = 3, Year = 2025 },
            new MonthlyPeriod { PeriodId = 16, Month = 4, Year = 2025 },
            new MonthlyPeriod { PeriodId = 17, Month = 5, Year = 2025 },
            new MonthlyPeriod { PeriodId = 18, Month = 6, Year = 2025 },
            new MonthlyPeriod { PeriodId = 19, Month = 7, Year = 2025 },
            new MonthlyPeriod { PeriodId = 20, Month = 8, Year = 2025 },
            new MonthlyPeriod { PeriodId = 21, Month = 9, Year = 2025 },
            new MonthlyPeriod { PeriodId = 22, Month = 10, Year = 2025 },
            new MonthlyPeriod { PeriodId = 23, Month = 11, Year = 2025 },
            new MonthlyPeriod { PeriodId = 24, Month = 12, Year = 2025 }
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

    public DbSet<MonthlyPeriod> MonthlyPeriods { get; set; } = null!;

    public DbSet<VehiclePerMonth> VehiclePerMonths { get; set; } = null!;

    public DbSet<PriceTable> PriceTables { get; set; } = null!;
}