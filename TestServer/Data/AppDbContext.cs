using Microsoft.EntityFrameworkCore;
using TestServer.Models;
using System.Linq;

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
            new Customer { Id = "l1sufzGdTdYyIZJ8c0VypXyhmR02", Name = "Nguyen Hung Thai", Email = "nguyenthai0418@gmail.com", Status = Customer.CustomerStatus.Available },
            new Customer { Id = "JEBFEGirUGhlgQadF4xRrofZo9X2", Name = "Nguyen Bui Dang Khoi", Email = "nguyenbuidangkhoixt@gmail.com", Status = Customer.CustomerStatus.Available },
            new Customer { Id = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Nguyen Xuan Thinh", Email = "xuanthinhkl2@gmail.com", Status = Customer.CustomerStatus.Available }
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
            new Connector { Id = 1, Name = "AC", Status = ConnectorTypeStatus.Available },
            new Connector { Id = 2, Name = "CCS", Status = ConnectorTypeStatus.Available },
            new Connector { Id = 3, Name = "CHAdeMO", Status = ConnectorTypeStatus.Available }
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


        // ChargingPort explicit seeds (Status = Available, Power by connector type)
        modelBuilder.Entity<ChargingPort>().HasData(
            // Station 1 (points 1..7)
            new ChargingPort { Id = "1.1.1", PointId = "1.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.1.2", PointId = "1.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.1.3", PointId = "1.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.2.1", PointId = "1.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.2.2", PointId = "1.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.2.3", PointId = "1.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.3.1", PointId = "1.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.3.2", PointId = "1.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.3.3", PointId = "1.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.4.1", PointId = "1.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.4.2", PointId = "1.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.4.3", PointId = "1.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.5.1", PointId = "1.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.5.2", PointId = "1.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.5.3", PointId = "1.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.6.1", PointId = "1.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.6.2", PointId = "1.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.6.3", PointId = "1.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "1.7.1", PointId = "1.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.7.2", PointId = "1.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "1.7.3", PointId = "1.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 2 (points 1..10)
            new ChargingPort { Id = "2.1.1", PointId = "2.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.1.2", PointId = "2.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.1.3", PointId = "2.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.2.1", PointId = "2.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.2.2", PointId = "2.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.2.3", PointId = "2.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.3.1", PointId = "2.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.3.2", PointId = "2.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.3.3", PointId = "2.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.4.1", PointId = "2.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.4.2", PointId = "2.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.4.3", PointId = "2.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.5.1", PointId = "2.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.5.2", PointId = "2.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.5.3", PointId = "2.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.6.1", PointId = "2.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.6.2", PointId = "2.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.6.3", PointId = "2.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.7.1", PointId = "2.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.7.2", PointId = "2.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.7.3", PointId = "2.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.8.1", PointId = "2.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.8.2", PointId = "2.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.8.3", PointId = "2.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.9.1", PointId = "2.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.9.2", PointId = "2.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.9.3", PointId = "2.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "2.10.1", PointId = "2.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.10.2", PointId = "2.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "2.10.3", PointId = "2.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 3 (points 1..10)
            new ChargingPort { Id = "3.1.1", PointId = "3.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.1.2", PointId = "3.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.1.3", PointId = "3.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.2.1", PointId = "3.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.2.2", PointId = "3.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.2.3", PointId = "3.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.3.1", PointId = "3.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.3.2", PointId = "3.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.3.3", PointId = "3.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.4.1", PointId = "3.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.4.2", PointId = "3.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.4.3", PointId = "3.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.5.1", PointId = "3.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.5.2", PointId = "3.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.5.3", PointId = "3.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.6.1", PointId = "3.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.6.2", PointId = "3.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.6.3", PointId = "3.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.7.1", PointId = "3.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.7.2", PointId = "3.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.7.3", PointId = "3.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.8.1", PointId = "3.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.8.2", PointId = "3.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.8.3", PointId = "3.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.9.1", PointId = "3.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.9.2", PointId = "3.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.9.3", PointId = "3.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "3.10.1", PointId = "3.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.10.2", PointId = "3.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "3.10.3", PointId = "3.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 4 (points 1..10)
            new ChargingPort { Id = "4.1.1", PointId = "4.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.1.2", PointId = "4.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.1.3", PointId = "4.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.2.1", PointId = "4.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.2.2", PointId = "4.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.2.3", PointId = "4.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.3.1", PointId = "4.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.3.2", PointId = "4.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.3.3", PointId = "4.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.4.1", PointId = "4.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.4.2", PointId = "4.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.4.3", PointId = "4.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.5.1", PointId = "4.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.5.2", PointId = "4.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.5.3", PointId = "4.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.6.1", PointId = "4.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.6.2", PointId = "4.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.6.3", PointId = "4.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.7.1", PointId = "4.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.7.2", PointId = "4.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.7.3", PointId = "4.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.8.1", PointId = "4.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.8.2", PointId = "4.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.8.3", PointId = "4.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.9.1", PointId = "4.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.9.2", PointId = "4.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.9.3", PointId = "4.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "4.10.1", PointId = "4.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.10.2", PointId = "4.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "4.10.3", PointId = "4.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 5 (points 1..10)
            new ChargingPort { Id = "5.1.1", PointId = "5.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.1.2", PointId = "5.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.1.3", PointId = "5.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.2.1", PointId = "5.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.2.2", PointId = "5.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.2.3", PointId = "5.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.3.1", PointId = "5.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.3.2", PointId = "5.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.3.3", PointId = "5.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.4.1", PointId = "5.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.4.2", PointId = "5.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.4.3", PointId = "5.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.5.1", PointId = "5.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.5.2", PointId = "5.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.5.3", PointId = "5.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.6.1", PointId = "5.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.6.2", PointId = "5.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.6.3", PointId = "5.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.7.1", PointId = "5.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.7.2", PointId = "5.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.7.3", PointId = "5.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.8.1", PointId = "5.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.8.2", PointId = "5.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.8.3", PointId = "5.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.9.1", PointId = "5.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.9.2", PointId = "5.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.9.3", PointId = "5.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "5.10.1", PointId = "5.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.10.2", PointId = "5.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "5.10.3", PointId = "5.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 6 (points 1..10)
            new ChargingPort { Id = "6.1.1", PointId = "6.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.1.2", PointId = "6.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.1.3", PointId = "6.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.2.1", PointId = "6.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.2.2", PointId = "6.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.2.3", PointId = "6.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.3.1", PointId = "6.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.3.2", PointId = "6.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.3.3", PointId = "6.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.4.1", PointId = "6.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.4.2", PointId = "6.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.4.3", PointId = "6.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.5.1", PointId = "6.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.5.2", PointId = "6.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.5.3", PointId = "6.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.6.1", PointId = "6.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.6.2", PointId = "6.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.6.3", PointId = "6.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.7.1", PointId = "6.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.7.2", PointId = "6.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.7.3", PointId = "6.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.8.1", PointId = "6.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.8.2", PointId = "6.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.8.3", PointId = "6.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.9.1", PointId = "6.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.9.2", PointId = "6.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.9.3", PointId = "6.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "6.10.1", PointId = "6.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.10.2", PointId = "6.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "6.10.3", PointId = "6.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            // Station 7 (points 1..10)
            new ChargingPort { Id = "7.1.1", PointId = "7.1", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.1.2", PointId = "7.1", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.1.3", PointId = "7.1", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.2.1", PointId = "7.2", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.2.2", PointId = "7.2", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.2.3", PointId = "7.2", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.3.1", PointId = "7.3", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.3.2", PointId = "7.3", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.3.3", PointId = "7.3", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.4.1", PointId = "7.4", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.4.2", PointId = "7.4", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.4.3", PointId = "7.4", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.5.1", PointId = "7.5", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.5.2", PointId = "7.5", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.5.3", PointId = "7.5", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.6.1", PointId = "7.6", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.6.2", PointId = "7.6", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.6.3", PointId = "7.6", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.7.1", PointId = "7.7", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.7.2", PointId = "7.7", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.7.3", PointId = "7.7", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.8.1", PointId = "7.8", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.8.2", PointId = "7.8", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.8.3", PointId = "7.8", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.9.1", PointId = "7.9", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.9.2", PointId = "7.9", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.9.3", PointId = "7.9", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available },

            new ChargingPort { Id = "7.10.1", PointId = "7.10", ConnectorId = 1, Power = 250, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.10.2", PointId = "7.10", ConnectorId = 2, Power = 350, Status = ChargingPortStatus.Available },
            new ChargingPort { Id = "7.10.3", PointId = "7.10", ConnectorId = 3, Power = 450, Status = ChargingPortStatus.Available }
        );

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Tesla Model 3", VehicleTypeId = 2, LicensePlate = "51B-67890", BatteryCapacity = 70, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "VinFast VF 8", VehicleTypeId = 2, LicensePlate = "30A-12345", BatteryCapacity = 55, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 3, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Nissan Leaf", VehicleTypeId = 2, LicensePlate = "29C-56789", BatteryCapacity = 66, Status = VehicleStatus.Blocked },
            new Vehicle { VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Hyundai Ioniq 5", VehicleTypeId = 2, LicensePlate = "88D-45678", BatteryCapacity = 52, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 5, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3", Name = "Kia EV6", VehicleTypeId = 2, LicensePlate = "77E-99999", BatteryCapacity = 51, Status = VehicleStatus.Active },

            new Vehicle { VehicleId = 6, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02", Name = "Tesla Model Y", VehicleTypeId = 2, LicensePlate = "68A-12345", BatteryCapacity = 69, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 7, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02", Name = "Tesla Model 4", VehicleTypeId = 2, LicensePlate = "99B-67890", BatteryCapacity = 54, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 8, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02", Name = "BYD Seal", VehicleTypeId = 2, LicensePlate = "12C-34567", BatteryCapacity = 57, Status = VehicleStatus.Blocked },
            new Vehicle { VehicleId = 9, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02", Name = "Ford F-150 Lightning", VehicleTypeId = 2, LicensePlate = "34D-89012", BatteryCapacity = 68, Status = VehicleStatus.Active },

            new Vehicle { VehicleId = 10, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2", Name = "Chevrolet Bolt EV", VehicleTypeId = 2, LicensePlate = "56E-34567", BatteryCapacity = 66, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 11, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2", Name = "Volvo EX30", VehicleTypeId = 2, LicensePlate = "78F-90123", BatteryCapacity = 53, Status = VehicleStatus.Blocked },
            new Vehicle { VehicleId = 12, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2", Name = "Audi e-tron GT", VehicleTypeId = 2, LicensePlate = "90G-45678", BatteryCapacity = 64, Status = VehicleStatus.Active },
            new Vehicle { VehicleId = 13, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2", Name = "Porsche Taycan", VehicleTypeId = 2, LicensePlate = "21H-78901", BatteryCapacity = 62, Status = VehicleStatus.Active }
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
            new VehiclePort { VehicleId = 5, ConnectorId = 1 },

            new VehiclePort { VehicleId = 6, ConnectorId = 1 },
            new VehiclePort { VehicleId = 6, ConnectorId = 2 },

            new VehiclePort { VehicleId = 7, ConnectorId = 2 },
            new VehiclePort { VehicleId = 7, ConnectorId = 3 },

            new VehiclePort { VehicleId = 8, ConnectorId = 3 },
            new VehiclePort { VehicleId = 8, ConnectorId = 2 },

            new VehiclePort { VehicleId = 9, ConnectorId = 1 },
            new VehiclePort { VehicleId = 9, ConnectorId = 2 },

            new VehiclePort { VehicleId = 10, ConnectorId = 2 },
            new VehiclePort { VehicleId = 10, ConnectorId = 3 },

            new VehiclePort { VehicleId = 11, ConnectorId = 1},
            new VehiclePort { VehicleId = 11, ConnectorId = 3},
            
            new VehiclePort { VehicleId = 12, ConnectorId = 2},
            new VehiclePort { VehicleId = 12, ConnectorId = 3},

            new VehiclePort { VehicleId = 13, ConnectorId = 1},
            new VehiclePort { VehicleId = 13, ConnectorId = 2}
        );

        modelBuilder.Entity<PriceTable>().HasData(
            new PriceTable { Id = 1, Name = "PriceTable for 2024", PricePerKWh = 3500, PenaltyFeePerMinute = 800, ValidFrom = new DateTime(2024, 1, 1), ValidTo = new DateTime(2024, 12, 31), Status = PriceTableStatus.Inactive },
            new PriceTable { Id = 2, Name = "PriceTable for 2025", PricePerKWh = 3858, PenaltyFeePerMinute = 1000, ValidFrom = new DateTime(2025, 1, 1), ValidTo = new DateTime(2025, 12, 31), Status = PriceTableStatus.Active },
            new PriceTable { Id = 3, Name = "PriceTable for Nov-2025", PricePerKWh = 3900, PenaltyFeePerMinute = 1100, ValidFrom = new DateTime(2025, 11, 1), ValidTo = new DateTime(2025, 11, 30), Status = PriceTableStatus.Inactive },
            new PriceTable { Id = 4, Name = "PriceTable for 2026", PricePerKWh = 4000, PenaltyFeePerMinute = 1200, ValidFrom = new DateTime(2026, 1, 1), ValidTo = new DateTime(2026, 12, 31), Status = PriceTableStatus.Inactive }
        );

        // Helper function for cost calculation
        Func<float, int> CalculateCost = energy => (int)(energy * 3858);

        modelBuilder.Entity<ChargingSession>().HasData(
            // Sessions 1-38: July 2025
            new ChargingSession { Id = 1, VehicleId = 1, PortId = "1.1.1", StartTime = new DateTime(2025, 7, 3, 8, 15, 0), EndTime = new DateTime(2025, 7, 3, 10, 30, 0), EnergyConsumed = 41.2f, TotalCost = CalculateCost(41.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 2, VehicleId = 1, PortId = "2.2.1", StartTime = new DateTime(2025, 7, 8, 14, 45, 0), EndTime = new DateTime(2025, 7, 8, 16, 20, 0), EnergyConsumed = 36.8f, TotalCost = CalculateCost(36.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 3, VehicleId = 1, PortId = "3.3.1", StartTime = new DateTime(2025, 7, 15, 9, 30, 0), EndTime = new DateTime(2025, 7, 15, 11, 15, 0), EnergyConsumed = 39.5f, TotalCost = CalculateCost(39.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 4, VehicleId = 1, PortId = "4.4.1", StartTime = new DateTime(2025, 7, 22, 16, 20, 0), EndTime = new DateTime(2025, 7, 22, 18, 35, 0), EnergyConsumed = 43.1f, TotalCost = CalculateCost(43.1f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 5, VehicleId = 2, PortId = "5.5.1", StartTime = new DateTime(2025, 7, 5, 11, 20, 0), EndTime = new DateTime(2025, 7, 5, 13, 45, 0), EnergyConsumed = 47.3f, TotalCost = CalculateCost(47.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 6, VehicleId = 2, PortId = "6.6.1", StartTime = new DateTime(2025, 7, 12, 16, 10, 0), EndTime = new DateTime(2025, 7, 12, 18, 25, 0), EnergyConsumed = 43.7f, TotalCost = CalculateCost(43.7f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 7, VehicleId = 2, PortId = "7.7.1", StartTime = new DateTime(2025, 7, 18, 7, 45, 0), EndTime = new DateTime(2025, 7, 18, 9, 30, 0), EnergyConsumed = 38.1f, TotalCost = CalculateCost(38.1f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 8, VehicleId = 3, PortId = "1.2.3", StartTime = new DateTime(2025, 7, 4, 13, 30, 0), EndTime = new DateTime(2025, 7, 4, 15, 45, 0), EnergyConsumed = 31.2f, TotalCost = CalculateCost(31.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 9, VehicleId = 3, PortId = "2.3.1", StartTime = new DateTime(2025, 7, 11, 10, 15, 0), EndTime = new DateTime(2025, 7, 11, 11, 50, 0), EnergyConsumed = 28.9f, TotalCost = CalculateCost(28.9f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 10, VehicleId = 4, PortId = "3.4.1", StartTime = new DateTime(2025, 7, 6, 12, 45, 0), EndTime = new DateTime(2025, 7, 6, 14, 30, 0), EnergyConsumed = 40.6f, TotalCost = CalculateCost(40.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 11, VehicleId = 4, PortId = "4.5.1", StartTime = new DateTime(2025, 7, 14, 17, 20, 0), EndTime = new DateTime(2025, 7, 14, 19, 10, 0), EnergyConsumed = 42.3f, TotalCost = CalculateCost(42.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 12, VehicleId = 4, PortId = "5.6.1", StartTime = new DateTime(2025, 7, 20, 8, 30, 0), EndTime = new DateTime(2025, 7, 20, 10, 45, 0), EnergyConsumed = 37.8f, TotalCost = CalculateCost(37.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 13, VehicleId = 4, PortId = "6.7.1", StartTime = new DateTime(2025, 7, 26, 14, 15, 0), EndTime = new DateTime(2025, 7, 26, 16, 30, 0), EnergyConsumed = 44.7f, TotalCost = CalculateCost(44.7f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 14, VehicleId = 5, PortId = "7.8.1", StartTime = new DateTime(2025, 7, 7, 15, 40, 0), EndTime = new DateTime(2025, 7, 7, 17, 55, 0), EnergyConsumed = 45.1f, TotalCost = CalculateCost(45.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 15, VehicleId = 5, PortId = "1.3.2", StartTime = new DateTime(2025, 7, 16, 9, 15, 0), EndTime = new DateTime(2025, 7, 16, 11, 30, 0), EnergyConsumed = 41.7f, TotalCost = CalculateCost(41.7f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 16, VehicleId = 5, PortId = "2.4.2", StartTime = new DateTime(2025, 7, 23, 18, 45, 0), EndTime = new DateTime(2025, 7, 23, 21, 0, 0), EnergyConsumed = 47.8f, TotalCost = CalculateCost(47.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 17, VehicleId = 6, PortId = "3.5.2", StartTime = new DateTime(2025, 7, 2, 10, 0, 0), EndTime = new DateTime(2025, 7, 2, 12, 15, 0), EnergyConsumed = 36.5f, TotalCost = CalculateCost(36.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 18, VehicleId = 6, PortId = "4.6.2", StartTime = new DateTime(2025, 7, 17, 13, 30, 0), EndTime = new DateTime(2025, 7, 17, 15, 45, 0), EnergyConsumed = 39.2f, TotalCost = CalculateCost(39.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 19, VehicleId = 6, PortId = "5.7.2", StartTime = new DateTime(2025, 7, 29, 14, 30, 0), EndTime = new DateTime(2025, 7, 29, 16, 45, 0), EnergyConsumed = 42.0f, TotalCost = CalculateCost(42.0f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 20, VehicleId = 7, PortId = "6.8.2", StartTime = new DateTime(2025, 7, 9, 9, 0, 0), EndTime = new DateTime(2025, 7, 9, 11, 15, 0), EnergyConsumed = 30.8f, TotalCost = CalculateCost(30.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 21, VehicleId = 7, PortId = "7.9.2", StartTime = new DateTime(2025, 7, 21, 12, 30, 0), EndTime = new DateTime(2025, 7, 21, 14, 45, 0), EnergyConsumed = 33.5f, TotalCost = CalculateCost(33.5f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 22, VehicleId = 8, PortId = "1.4.1", StartTime = new DateTime(2025, 7, 1, 15, 0, 0), EndTime = new DateTime(2025, 7, 1, 17, 15, 0), EnergyConsumed = 35.7f, TotalCost = CalculateCost(35.7f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 23, VehicleId = 8, PortId = "2.5.1", StartTime = new DateTime(2025, 7, 25, 10, 30, 0), EndTime = new DateTime(2025, 7, 25, 12, 45, 0), EnergyConsumed = 38.4f, TotalCost = CalculateCost(38.4f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 24, VehicleId = 9, PortId = "3.6.1", StartTime = new DateTime(2025, 7, 4, 11, 0, 0), EndTime = new DateTime(2025, 7, 4, 13, 15, 0), EnergyConsumed = 28.6f, TotalCost = CalculateCost(28.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 25, VehicleId = 9, PortId = "4.7.1", StartTime = new DateTime(2025, 7, 14, 14, 30, 0), EndTime = new DateTime(2025, 7, 14, 16, 45, 0), EnergyConsumed = 31.4f, TotalCost = CalculateCost(31.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 26, VehicleId = 9, PortId = "5.8.1", StartTime = new DateTime(2025, 7, 20, 10, 0, 0), EndTime = new DateTime(2025, 7, 20, 12, 15, 0), EnergyConsumed = 34.2f, TotalCost = CalculateCost(34.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 27, VehicleId = 9, PortId = "6.9.1", StartTime = new DateTime(2025, 7, 27, 15, 30, 0), EndTime = new DateTime(2025, 7, 27, 17, 45, 0), EnergyConsumed = 37.0f, TotalCost = CalculateCost(37.0f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 28, VehicleId = 10, PortId = "7.10.1", StartTime = new DateTime(2025, 7, 3, 12, 0, 0), EndTime = new DateTime(2025, 7, 3, 14, 15, 0), EnergyConsumed = 40.0f, TotalCost = CalculateCost(40.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 29, VehicleId = 10, PortId = "1.5.1", StartTime = new DateTime(2025, 7, 13, 8, 30, 0), EndTime = new DateTime(2025, 7, 13, 10, 45, 0), EnergyConsumed = 35.5f, TotalCost = CalculateCost(35.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 30, VehicleId = 10, PortId = "2.6.1", StartTime = new DateTime(2025, 7, 22, 16, 0, 0), EndTime = new DateTime(2025, 7, 22, 18, 15, 0), EnergyConsumed = 38.8f, TotalCost = CalculateCost(38.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 31, VehicleId = 11, PortId = "3.7.1", StartTime = new DateTime(2025, 7, 10, 11, 45, 0), EndTime = new DateTime(2025, 7, 10, 13, 30, 0), EnergyConsumed = 33.3f, TotalCost = CalculateCost(33.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 32, VehicleId = 11, PortId = "4.8.1", StartTime = new DateTime(2025, 7, 28, 14, 0, 0), EndTime = new DateTime(2025, 7, 28, 15, 45, 0), EnergyConsumed = 36.1f, TotalCost = CalculateCost(36.1f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 33, VehicleId = 12, PortId = "5.9.1", StartTime = new DateTime(2025, 7, 6, 9, 30, 0), EndTime = new DateTime(2025, 7, 6, 11, 45, 0), EnergyConsumed = 41.5f, TotalCost = CalculateCost(41.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 34, VehicleId = 12, PortId = "6.10.1", StartTime = new DateTime(2025, 7, 15, 14, 20, 0), EndTime = new DateTime(2025, 7, 15, 16, 35, 0), EnergyConsumed = 44.4f, TotalCost = CalculateCost(44.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 35, VehicleId = 12, PortId = "7.1.1", StartTime = new DateTime(2025, 7, 21, 10, 15, 0), EndTime = new DateTime(2025, 7, 21, 12, 30, 0), EnergyConsumed = 47.1f, TotalCost = CalculateCost(47.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 36, VehicleId = 12, PortId = "1.6.1", StartTime = new DateTime(2025, 7, 30, 17, 0, 0), EndTime = new DateTime(2025, 7, 30, 19, 15, 0), EnergyConsumed = 42.8f, TotalCost = CalculateCost(42.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 37, VehicleId = 13, PortId = "2.7.1", StartTime = new DateTime(2025, 7, 1, 8, 0, 0), EndTime = new DateTime(2025, 7, 1, 10, 15, 0), EnergyConsumed = 40.2f, TotalCost = CalculateCost(40.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 38, VehicleId = 13, PortId = "3.8.1", StartTime = new DateTime(2025, 7, 24, 13, 0, 0), EndTime = new DateTime(2025, 7, 24, 15, 15, 0), EnergyConsumed = 43.0f, TotalCost = CalculateCost(43.0f), Status = SessionStatus.Completed },

            // Sessions 39-77: August 2025 
            new ChargingSession { Id = 39, VehicleId = 1, PortId = "4.9.1", StartTime = new DateTime(2025, 8, 5, 10, 0, 0), EndTime = new DateTime(2025, 8, 5, 12, 15, 0), EnergyConsumed = 40.0f, TotalCost = CalculateCost(40.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 40, VehicleId = 1, PortId = "5.10.1", StartTime = new DateTime(2025, 8, 12, 15, 30, 0), EndTime = new DateTime(2025, 8, 12, 17, 45, 0), EnergyConsumed = 35.5f, TotalCost = CalculateCost(35.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 41, VehicleId = 1, PortId = "6.1.1", StartTime = new DateTime(2025, 8, 25, 11, 0, 0), EndTime = new DateTime(2025, 8, 25, 13, 15, 0), EnergyConsumed = 38.8f, TotalCost = CalculateCost(38.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 42, VehicleId = 2, PortId = "7.2.1", StartTime = new DateTime(2025, 8, 1, 9, 30, 0), EndTime = new DateTime(2025, 8, 1, 11, 45, 0), EnergyConsumed = 47.1f, TotalCost = CalculateCost(47.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 43, VehicleId = 2, PortId = "1.7.1", StartTime = new DateTime(2025, 8, 14, 16, 20, 0), EndTime = new DateTime(2025, 8, 14, 18, 35, 0), EnergyConsumed = 43.9f, TotalCost = CalculateCost(43.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 44, VehicleId = 2, PortId = "2.8.1", StartTime = new DateTime(2025, 8, 20, 7, 45, 0), EndTime = new DateTime(2025, 8, 20, 9, 30, 0), EnergyConsumed = 38.3f, TotalCost = CalculateCost(38.3f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 45, VehicleId = 3, PortId = "3.9.1", StartTime = new DateTime(2025, 8, 2, 13, 30, 0), EndTime = new DateTime(2025, 8, 2, 15, 45, 0), EnergyConsumed = 31.5f, TotalCost = CalculateCost(31.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 46, VehicleId = 3, PortId = "4.10.1", StartTime = new DateTime(2025, 8, 9, 10, 15, 0), EndTime = new DateTime(2025, 8, 9, 11, 50, 0), EnergyConsumed = 29.1f, TotalCost = CalculateCost(29.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 47, VehicleId = 3, PortId = "5.1.1", StartTime = new DateTime(2025, 8, 16, 17, 20, 0), EndTime = new DateTime(2025, 8, 16, 19, 35, 0), EnergyConsumed = 33.3f, TotalCost = CalculateCost(33.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 48, VehicleId = 3, PortId = "6.2.1", StartTime = new DateTime(2025, 8, 29, 14, 15, 0), EndTime = new DateTime(2025, 8, 29, 16, 30, 0), EnergyConsumed = 35.8f, TotalCost = CalculateCost(35.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 49, VehicleId = 4, PortId = "7.3.1", StartTime = new DateTime(2025, 8, 7, 12, 45, 0), EndTime = new DateTime(2025, 8, 7, 14, 30, 0), EnergyConsumed = 40.8f, TotalCost = CalculateCost(40.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 50, VehicleId = 4, PortId = "1.2.1", StartTime = new DateTime(2025, 8, 21, 17, 20, 0), EndTime = new DateTime(2025, 8, 21, 19, 10, 0), EnergyConsumed = 42.5f, TotalCost = CalculateCost(42.5f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 51, VehicleId = 5, PortId = "2.3.2", StartTime = new DateTime(2025, 8, 8, 15, 40, 0), EndTime = new DateTime(2025, 8, 8, 17, 55, 0), EnergyConsumed = 45.4f, TotalCost = CalculateCost(45.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 52, VehicleId = 5, PortId = "3.4.2", StartTime = new DateTime(2025, 8, 17, 9, 15, 0), EndTime = new DateTime(2025, 8, 17, 11, 30, 0), EnergyConsumed = 41.9f, TotalCost = CalculateCost(41.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 53, VehicleId = 5, PortId = "4.5.2", StartTime = new DateTime(2025, 8, 24, 18, 45, 0), EndTime = new DateTime(2025, 8, 24, 21, 0, 0), EnergyConsumed = 48.0f, TotalCost = CalculateCost(48.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 54, VehicleId = 5, PortId = "5.6.2", StartTime = new DateTime(2025, 8, 30, 10, 0, 0), EndTime = new DateTime(2025, 8, 30, 12, 15, 0), EnergyConsumed = 46.5f, TotalCost = CalculateCost(46.5f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 55, VehicleId = 6, PortId = "6.7.2", StartTime = new DateTime(2025, 8, 3, 11, 30, 0), EndTime = new DateTime(2025, 8, 3, 14, 15, 0), EnergyConsumed = 48.9f, TotalCost = CalculateCost(48.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 56, VehicleId = 6, PortId = "7.8.2", StartTime = new DateTime(2025, 8, 15, 16, 45, 0), EndTime = new DateTime(2025, 8, 15, 18, 30, 0), EnergyConsumed = 44.2f, TotalCost = CalculateCost(44.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 57, VehicleId = 6, PortId = "1.3.3", StartTime = new DateTime(2025, 8, 26, 9, 20, 0), EndTime = new DateTime(2025, 8, 26, 11, 45, 0), EnergyConsumed = 46.5f, TotalCost = CalculateCost(46.5f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 58, VehicleId = 7, PortId = "2.4.3", StartTime = new DateTime(2025, 8, 6, 13, 45, 0), EndTime = new DateTime(2025, 8, 6, 15, 30, 0), EnergyConsumed = 32.1f, TotalCost = CalculateCost(32.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 59, VehicleId = 7, PortId = "3.5.3", StartTime = new DateTime(2025, 8, 13, 10, 30, 0), EndTime = new DateTime(2025, 8, 13, 12, 15, 0), EnergyConsumed = 29.7f, TotalCost = CalculateCost(29.7f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 60, VehicleId = 7, PortId = "4.6.3", StartTime = new DateTime(2025, 8, 22, 17, 20, 0), EndTime = new DateTime(2025, 8, 22, 19, 35, 0), EnergyConsumed = 33.4f, TotalCost = CalculateCost(33.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 61, VehicleId = 7, PortId = "5.7.3", StartTime = new DateTime(2025, 8, 28, 8, 45, 0), EndTime = new DateTime(2025, 8, 28, 11, 10, 0), EnergyConsumed = 35.6f, TotalCost = CalculateCost(35.6f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 62, VehicleId = 8, PortId = "6.8.3", StartTime = new DateTime(2025, 8, 4, 12, 30, 0), EndTime = new DateTime(2025, 8, 4, 15, 15, 0), EnergyConsumed = 49.5f, TotalCost = CalculateCost(49.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 63, VehicleId = 8, PortId = "7.9.3", StartTime = new DateTime(2025, 8, 18, 9, 15, 0), EndTime = new DateTime(2025, 8, 18, 11, 30, 0), EnergyConsumed = 41.9f, TotalCost = CalculateCost(41.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 64, VehicleId = 8, PortId = "1.5.2", StartTime = new DateTime(2025, 8, 27, 15, 40, 0), EndTime = new DateTime(2025, 8, 27, 17, 55, 0), EnergyConsumed = 45.3f, TotalCost = CalculateCost(45.3f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 65, VehicleId = 9, PortId = "2.6.2", StartTime = new DateTime(2025, 8, 10, 14, 20, 0), EndTime = new DateTime(2025, 8, 10, 16, 45, 0), EnergyConsumed = 41.6f, TotalCost = CalculateCost(41.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 66, VehicleId = 9, PortId = "3.7.2", StartTime = new DateTime(2025, 8, 24, 11, 15, 0), EndTime = new DateTime(2025, 8, 24, 13, 30, 0), EnergyConsumed = 39.0f, TotalCost = CalculateCost(39.0f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 67, VehicleId = 10, PortId = "4.8.2", StartTime = new DateTime(2025, 8, 8, 12, 0, 0), EndTime = new DateTime(2025, 8, 8, 14, 15, 0), EnergyConsumed = 40.3f, TotalCost = CalculateCost(40.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 68, VehicleId = 10, PortId = "5.9.2", StartTime = new DateTime(2025, 8, 19, 8, 30, 0), EndTime = new DateTime(2025, 8, 19, 10, 45, 0), EnergyConsumed = 35.8f, TotalCost = CalculateCost(35.8f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 69, VehicleId = 11, PortId = "6.10.2", StartTime = new DateTime(2025, 8, 5, 11, 45, 0), EndTime = new DateTime(2025, 8, 5, 13, 30, 0), EnergyConsumed = 33.6f, TotalCost = CalculateCost(33.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 70, VehicleId = 11, PortId = "7.1.2", StartTime = new DateTime(2025, 8, 11, 14, 0, 0), EndTime = new DateTime(2025, 8, 11, 15, 45, 0), EnergyConsumed = 36.4f, TotalCost = CalculateCost(36.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 71, VehicleId = 11, PortId = "1.6.2", StartTime = new DateTime(2025, 8, 28, 18, 45, 0), EndTime = new DateTime(2025, 8, 28, 21, 0, 0), EnergyConsumed = 39.2f, TotalCost = CalculateCost(39.2f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 72, VehicleId = 12, PortId = "2.7.2", StartTime = new DateTime(2025, 8, 1, 9, 30, 0), EndTime = new DateTime(2025, 8, 1, 11, 45, 0), EnergyConsumed = 41.8f, TotalCost = CalculateCost(41.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 73, VehicleId = 12, PortId = "3.8.2", StartTime = new DateTime(2025, 8, 23, 14, 20, 0), EndTime = new DateTime(2025, 8, 23, 16, 35, 0), EnergyConsumed = 44.7f, TotalCost = CalculateCost(44.7f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 74, VehicleId = 13, PortId = "4.9.2", StartTime = new DateTime(2025, 8, 3, 8, 0, 0), EndTime = new DateTime(2025, 8, 3, 10, 15, 0), EnergyConsumed = 40.5f, TotalCost = CalculateCost(40.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 75, VehicleId = 13, PortId = "5.10.2", StartTime = new DateTime(2025, 8, 18, 13, 0, 0), EndTime = new DateTime(2025, 8, 18, 15, 15, 0), EnergyConsumed = 43.3f, TotalCost = CalculateCost(43.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 76, VehicleId = 13, PortId = "6.1.2", StartTime = new DateTime(2025, 8, 25, 9, 30, 0), EndTime = new DateTime(2025, 8, 25, 11, 45, 0), EnergyConsumed = 46.1f, TotalCost = CalculateCost(46.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 77, VehicleId = 13, PortId = "7.2.2", StartTime = new DateTime(2025, 8, 31, 16, 20, 0), EndTime = new DateTime(2025, 8, 31, 18, 35, 0), EnergyConsumed = 41.9f, TotalCost = CalculateCost(41.9f), Status = SessionStatus.Completed },

            // --- September 2025 Sessions ---
            new ChargingSession { Id = 78, VehicleId = 1, PortId = "1.1.1", StartTime = new DateTime(2025, 9, 2, 9, 15, 0), EndTime = new DateTime(2025, 9, 2, 11, 30, 0), EnergyConsumed = 41.0f, TotalCost = CalculateCost(41.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 79, VehicleId = 1, PortId = "2.2.1", StartTime = new DateTime(2025, 9, 17, 14, 45, 0), EndTime = new DateTime(2025, 9, 17, 16, 20, 0), EnergyConsumed = 36.5f, TotalCost = CalculateCost(36.5f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 80, VehicleId = 2, PortId = "3.3.1", StartTime = new DateTime(2025, 9, 4, 11, 20, 0), EndTime = new DateTime(2025, 9, 4, 13, 45, 0), EnergyConsumed = 47.0f, TotalCost = CalculateCost(47.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 81, VehicleId = 2, PortId = "4.4.1", StartTime = new DateTime(2025, 9, 11, 16, 10, 0), EndTime = new DateTime(2025, 9, 11, 18, 25, 0), EnergyConsumed = 43.5f, TotalCost = CalculateCost(43.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 82, VehicleId = 2, PortId = "5.5.1", StartTime = new DateTime(2025, 9, 19, 7, 45, 0), EndTime = new DateTime(2025, 9, 19, 9, 30, 0), EnergyConsumed = 38.0f, TotalCost = CalculateCost(38.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 83, VehicleId = 2, PortId = "6.6.1", StartTime = new DateTime(2025, 9, 26, 15, 30, 0), EndTime = new DateTime(2025, 9, 26, 17, 45, 0), EnergyConsumed = 45.0f, TotalCost = CalculateCost(45.0f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 84, VehicleId = 4, PortId = "7.7.1", StartTime = new DateTime(2025, 9, 6, 12, 45, 0), EndTime = new DateTime(2025, 9, 6, 14, 30, 0), EnergyConsumed = 40.5f, TotalCost = CalculateCost(40.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 85, VehicleId = 4, PortId = "1.2.1", StartTime = new DateTime(2025, 9, 24, 17, 20, 0), EndTime = new DateTime(2025, 9, 24, 19, 10, 0), EnergyConsumed = 42.2f, TotalCost = CalculateCost(42.2f), Status = SessionStatus.Completed },
           
            new ChargingSession { Id = 86, VehicleId = 5, PortId = "2.3.1", StartTime = new DateTime(2025, 9, 3, 15, 40, 0), EndTime = new DateTime(2025, 9, 3, 17, 55, 0), EnergyConsumed = 45.0f, TotalCost = CalculateCost(45.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 87, VehicleId = 5, PortId = "3.4.1", StartTime = new DateTime(2025, 9, 12, 9, 15, 0), EndTime = new DateTime(2025, 9, 12, 11, 30, 0), EnergyConsumed = 41.5f, TotalCost = CalculateCost(41.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 88, VehicleId = 5, PortId = "4.5.1", StartTime = new DateTime(2025, 9, 23, 18, 45, 0), EndTime = new DateTime(2025, 9, 23, 21, 0, 0), EnergyConsumed = 47.5f, TotalCost = CalculateCost(47.5f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 89, VehicleId = 6, PortId = "5.6.1", StartTime = new DateTime(2025, 9, 5, 10, 0, 0), EndTime = new DateTime(2025, 9, 5, 12, 15, 0), EnergyConsumed = 36.3f, TotalCost = CalculateCost(36.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 90, VehicleId = 6, PortId = "6.7.1", StartTime = new DateTime(2025, 9, 18, 13, 30, 0), EndTime = new DateTime(2025, 9, 18, 15, 45, 0), EnergyConsumed = 39.0f, TotalCost = CalculateCost(39.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 91, VehicleId = 6, PortId = "7.8.1", StartTime = new DateTime(2025, 9, 30, 14, 30, 0), EndTime = new DateTime(2025, 9, 30, 16, 45, 0), EnergyConsumed = 41.8f, TotalCost = CalculateCost(41.8f), Status = SessionStatus.Completed },
           
            new ChargingSession { Id = 92, VehicleId = 7, PortId = "1.3.1", StartTime = new DateTime(2025, 9, 9, 9, 0, 0), EndTime = new DateTime(2025, 9, 9, 11, 15, 0), EnergyConsumed = 30.6f, TotalCost = CalculateCost(30.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 93, VehicleId = 7, PortId = "2.4.1", StartTime = new DateTime(2025, 9, 15, 12, 30, 0), EndTime = new DateTime(2025, 9, 15, 14, 45, 0), EnergyConsumed = 33.3f, TotalCost = CalculateCost(33.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 94, VehicleId = 7, PortId = "3.5.1", StartTime = new DateTime(2025, 9, 22, 15, 0, 0), EndTime = new DateTime(2025, 9, 22, 17, 15, 0), EnergyConsumed = 35.5f, TotalCost = CalculateCost(35.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 95, VehicleId = 7, PortId = "4.6.1", StartTime = new DateTime(2025, 9, 28, 10, 30, 0), EndTime = new DateTime(2025, 9, 28, 12, 45, 0), EnergyConsumed = 38.2f, TotalCost = CalculateCost(38.2f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 96, VehicleId = 8, PortId = "5.7.1", StartTime = new DateTime(2025, 9, 4, 12, 30, 0), EndTime = new DateTime(2025, 9, 4, 15, 15, 0), EnergyConsumed = 49.5f, TotalCost = CalculateCost(49.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 97, VehicleId = 8, PortId = "6.8.1", StartTime = new DateTime(2025, 9, 18, 9, 15, 0), EndTime = new DateTime(2025, 9, 18, 11, 30, 0), EnergyConsumed = 41.9f, TotalCost = CalculateCost(41.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 98, VehicleId = 8, PortId = "7.9.1", StartTime = new DateTime(2025, 9, 27, 15, 40, 0), EndTime = new DateTime(2025, 9, 27, 17, 55, 0), EnergyConsumed = 45.3f, TotalCost = CalculateCost(45.3f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 99, VehicleId = 9, PortId = "1.4.2", StartTime = new DateTime(2025, 9, 5, 11, 0, 0), EndTime = new DateTime(2025, 9, 5, 13, 15, 0), EnergyConsumed = 28.4f, TotalCost = CalculateCost(28.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 100, VehicleId = 9, PortId = "2.5.2", StartTime = new DateTime(2025, 9, 14, 14, 30, 0), EndTime = new DateTime(2025, 9, 14, 16, 45, 0), EnergyConsumed = 31.2f, TotalCost = CalculateCost(31.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 101, VehicleId = 9, PortId = "3.6.2", StartTime = new DateTime(2025, 9, 27, 10, 0, 0), EndTime = new DateTime(2025, 9, 27, 12, 15, 0), EnergyConsumed = 34.0f, TotalCost = CalculateCost(34.0f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 102, VehicleId = 10, PortId = "4.7.2", StartTime = new DateTime(2025, 9, 7, 12, 0, 0), EndTime = new DateTime(2025, 9, 7, 14, 15, 0), EnergyConsumed = 39.8f, TotalCost = CalculateCost(39.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 103, VehicleId = 10, PortId = "5.8.2", StartTime = new DateTime(2025, 9, 20, 8, 30, 0), EndTime = new DateTime(2025, 9, 20, 10, 45, 0), EnergyConsumed = 35.3f, TotalCost = CalculateCost(35.3f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 104, VehicleId = 11, PortId = "6.9.2", StartTime = new DateTime(2025, 9, 1, 11, 45, 0), EndTime = new DateTime(2025, 9, 1, 13, 30, 0), EnergyConsumed = 33.5f, TotalCost = CalculateCost(33.5f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 105, VehicleId = 11, PortId = "7.10.2", StartTime = new DateTime(2025, 9, 26, 14, 0, 0), EndTime = new DateTime(2025, 9, 26, 15, 45, 0), EnergyConsumed = 36.3f, TotalCost = CalculateCost(36.3f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 106, VehicleId = 12, PortId = "1.5.2", StartTime = new DateTime(2025, 9, 8, 9, 30, 0), EndTime = new DateTime(2025, 9, 8, 11, 45, 0), EnergyConsumed = 41.3f, TotalCost = CalculateCost(41.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 107, VehicleId = 12, PortId = "2.6.2", StartTime = new DateTime(2025, 9, 16, 14, 20, 0), EndTime = new DateTime(2025, 9, 16, 16, 35, 0), EnergyConsumed = 44.2f, TotalCost = CalculateCost(44.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 108, VehicleId = 12, PortId = "3.7.2", StartTime = new DateTime(2025, 9, 23, 10, 15, 0), EndTime = new DateTime(2025, 9, 23, 12, 30, 0), EnergyConsumed = 46.9f, TotalCost = CalculateCost(46.9f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 109, VehicleId = 12, PortId = "4.8.2", StartTime = new DateTime(2025, 9, 29, 17, 0, 0), EndTime = new DateTime(2025, 9, 29, 19, 15, 0), EnergyConsumed = 42.6f, TotalCost = CalculateCost(42.6f), Status = SessionStatus.Completed },
           
            new ChargingSession { Id = 110, VehicleId = 13, PortId = "5.9.2", StartTime = new DateTime(2025, 9, 7, 8, 0, 0), EndTime = new DateTime(2025, 9, 7, 10, 15, 0), EnergyConsumed = 40.0f, TotalCost = CalculateCost(40.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 111, VehicleId = 13, PortId = "6.10.2", StartTime = new DateTime(2025, 9, 25, 13, 0, 0), EndTime = new DateTime(2025, 9, 25, 15, 15, 0), EnergyConsumed = 42.8f, TotalCost = CalculateCost(42.8f), Status = SessionStatus.Completed },


            // --- October 2025 Sessions ---
            new ChargingSession { Id = 112, VehicleId = 1, PortId = "7.1.1", StartTime = new DateTime(2025, 10, 1, 9, 15, 0), EndTime = new DateTime(2025, 10, 1, 11, 30, 0), EnergyConsumed = 40.8f, TotalCost = CalculateCost(40.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 113, VehicleId = 1, PortId = "1.2.1", StartTime = new DateTime(2025, 10, 16, 14, 45, 0), EndTime = new DateTime(2025, 10, 16, 16, 20, 0), EnergyConsumed = 36.3f, TotalCost = CalculateCost(36.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 114, VehicleId = 1, PortId = "2.3.1", StartTime = new DateTime(2025, 10, 28, 9, 30, 0), EndTime = new DateTime(2025, 10, 28, 11, 15, 0), EnergyConsumed = 39.3f, TotalCost = CalculateCost(39.3f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 115, VehicleId = 2, PortId = "3.4.1", StartTime = new DateTime(2025, 10, 3, 11, 20, 0), EndTime = new DateTime(2025, 10, 3, 13, 45, 0), EnergyConsumed = 46.8f, TotalCost = CalculateCost(46.8f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 116, VehicleId = 2, PortId = "4.5.1", StartTime = new DateTime(2025, 10, 20, 16, 10, 0), EndTime = new DateTime(2025, 10, 20, 18, 25, 0), EnergyConsumed = 43.2f, TotalCost = CalculateCost(43.2f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 117, VehicleId = 4, PortId = "5.6.1", StartTime = new DateTime(2025, 10, 5, 12, 45, 0), EndTime = new DateTime(2025, 10, 5, 14, 30, 0), EnergyConsumed = 40.4f, TotalCost = CalculateCost(40.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 118, VehicleId = 4, PortId = "6.7.1", StartTime = new DateTime(2025, 10, 14, 17, 20, 0), EndTime = new DateTime(2025, 10, 14, 19, 10, 0), EnergyConsumed = 42.0f, TotalCost = CalculateCost(42.0f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 119, VehicleId = 4, PortId = "7.8.1", StartTime = new DateTime(2025, 10, 22, 8, 30, 0), EndTime = new DateTime(2025, 10, 22, 10, 45, 0), EnergyConsumed = 37.4f, TotalCost = CalculateCost(37.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 120, VehicleId = 4, PortId = "1.3.1", StartTime = new DateTime(2025, 10, 29, 14, 15, 0), EndTime = new DateTime(2025, 10, 29, 16, 30, 0), EnergyConsumed = 44.3f, TotalCost = CalculateCost(44.3f), Status = SessionStatus.Completed },
            
            new ChargingSession { Id = 121, VehicleId = 5, PortId = "2.4.1", StartTime = new DateTime(2025, 10, 7, 15, 40, 0), EndTime = new DateTime(2025, 10, 7, 17, 55, 0), EnergyConsumed = 45.1f, TotalCost = CalculateCost(45.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 122, VehicleId = 5, PortId = "3.5.1", StartTime = new DateTime(2025, 10, 17, 9, 15, 0), EndTime = new DateTime(2025, 10, 17, 11, 30, 0), EnergyConsumed = 41.7f, TotalCost = CalculateCost(41.7f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 123, VehicleId = 5, PortId = "4.6.1", StartTime = new DateTime(2025, 10, 27, 18, 45, 0), EndTime = new DateTime(2025, 10, 27, 21, 0, 0), EnergyConsumed = 47.8f, TotalCost = CalculateCost(47.8f), Status = SessionStatus.Completed },
          
            new ChargingSession { Id = 124, VehicleId = 6, PortId = "5.7.1", StartTime = new DateTime(2025, 10, 4, 10, 0, 0), EndTime = new DateTime(2025, 10, 4, 12, 15, 0), EnergyConsumed = 36.1f, TotalCost = CalculateCost(36.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 125, VehicleId = 6, PortId = "6.8.1", StartTime = new DateTime(2025, 10, 18, 13, 30, 0), EndTime = new DateTime(2025, 10, 18, 15, 45, 0), EnergyConsumed = 38.8f, TotalCost = CalculateCost(38.8f), Status = SessionStatus.Completed },
         
            new ChargingSession { Id = 126, VehicleId = 7, PortId = "7.9.1", StartTime = new DateTime(2025, 10, 9, 9, 0, 0), EndTime = new DateTime(2025, 10, 9, 11, 15, 0), EnergyConsumed = 30.4f, TotalCost = CalculateCost(30.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 127, VehicleId = 7, PortId = "1.4.2", StartTime = new DateTime(2025, 10, 15, 12, 30, 0), EndTime = new DateTime(2025, 10, 15, 14, 45, 0), EnergyConsumed = 33.1f, TotalCost = CalculateCost(33.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 128, VehicleId = 7, PortId = "2.5.2", StartTime = new DateTime(2025, 10, 27, 15, 0, 0), EndTime = new DateTime(2025, 10, 27, 17, 15, 0), EnergyConsumed = 35.3f, TotalCost = CalculateCost(35.3f), Status = SessionStatus.Completed },
          
            new ChargingSession { Id = 129, VehicleId = 9, PortId = "3.6.2", StartTime = new DateTime(2025, 10, 5, 11, 0, 0), EndTime = new DateTime(2025, 10, 5, 13, 15, 0), EnergyConsumed = 28.4f, TotalCost = CalculateCost(28.4f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 130, VehicleId = 9, PortId = "4.7.2", StartTime = new DateTime(2025, 10, 14, 14, 30, 0), EndTime = new DateTime(2025, 10, 14, 16, 45, 0), EnergyConsumed = 31.2f, TotalCost = CalculateCost(31.2f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 131, VehicleId = 9, PortId = "5.8.2", StartTime = new DateTime(2025, 10, 27, 10, 0, 0), EndTime = new DateTime(2025, 10, 27, 12, 15, 0), EnergyConsumed = 34.0f, TotalCost = CalculateCost(34.0f), Status = SessionStatus.Completed },
       
            new ChargingSession { Id = 132, VehicleId = 10, PortId = "6.9.2", StartTime = new DateTime(2025, 10, 7, 12, 0, 0), EndTime = new DateTime(2025, 10, 7, 14, 15, 0), EnergyConsumed = 39.6f, TotalCost = CalculateCost(39.6f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 133, VehicleId = 10, PortId = "7.10.2", StartTime = new DateTime(2025, 10, 21, 8, 30, 0), EndTime = new DateTime(2025, 10, 21, 10, 45, 0), EnergyConsumed = 35.1f, TotalCost = CalculateCost(35.1f), Status = SessionStatus.Completed },
      
            new ChargingSession { Id = 134, VehicleId = 12, PortId = "1.5.2", StartTime = new DateTime(2025, 10, 6, 9, 30, 0), EndTime = new DateTime(2025, 10, 6, 11, 45, 0), EnergyConsumed = 41.1f, TotalCost = CalculateCost(41.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 135, VehicleId = 12, PortId = "2.6.2", StartTime = new DateTime(2025, 10, 23, 14, 20, 0), EndTime = new DateTime(2025, 10, 23, 16, 35, 0), EnergyConsumed = 44.0f, TotalCost = CalculateCost(44.0f), Status = SessionStatus.Completed },
       
            new ChargingSession { Id = 136, VehicleId = 13, PortId = "3.7.2", StartTime = new DateTime(2025, 10, 10, 8, 0, 0), EndTime = new DateTime(2025, 10, 10, 10, 15, 0), EnergyConsumed = 40.3f, TotalCost = CalculateCost(40.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 137, VehicleId = 13, PortId = "4.8.2", StartTime = new DateTime(2025, 10, 19, 13, 0, 0), EndTime = new DateTime(2025, 10, 19, 15, 15, 0), EnergyConsumed = 43.1f, TotalCost = CalculateCost(43.1f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 138, VehicleId = 13, PortId = "5.9.2", StartTime = new DateTime(2025, 10, 31, 16, 20, 0), EndTime = new DateTime(2025, 10, 31, 18, 35, 0), EnergyConsumed = 41.7f, TotalCost = CalculateCost(41.7f), Status = SessionStatus.Completed },


            // --- November 2025 Sessions (Up to 9/11/2025)---
            new ChargingSession { Id = 139, VehicleId = 1, PortId = "6.10.2", StartTime = new DateTime(2025, 11, 2, 9, 15, 0), EndTime = new DateTime(2025, 11, 2, 11, 30, 0), EnergyConsumed = 40.7f, TotalCost = CalculateCost(40.7f), Status = SessionStatus.Completed },
         
            new ChargingSession { Id = 140, VehicleId = 2, PortId = "7.1.2", StartTime = new DateTime(2025, 11, 3, 11, 20, 0), EndTime = new DateTime(2025, 11, 3, 13, 45, 0), EnergyConsumed = 46.7f, TotalCost = CalculateCost(46.7f), Status = SessionStatus.Completed },
          
            new ChargingSession { Id = 141, VehicleId = 4, PortId = "1.4.1", StartTime = new DateTime(2025, 11, 4, 12, 45, 0), EndTime = new DateTime(2025, 11, 4, 14, 30, 0), EnergyConsumed = 40.3f, TotalCost = CalculateCost(40.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 142, VehicleId = 4, PortId = "2.5.1", StartTime = new DateTime(2025, 11, 7, 17, 20, 0), EndTime = new DateTime(2025, 11, 7, 19, 10, 0), EnergyConsumed = 42.1f, TotalCost = CalculateCost(42.1f), Status = SessionStatus.Completed },
   
            new ChargingSession { Id = 143, VehicleId = 6, PortId = "4.7.1", StartTime = new DateTime(2025, 11, 5, 10, 0, 0), EndTime = new DateTime(2025, 11, 5, 12, 15, 0), EnergyConsumed = 36.0f, TotalCost = CalculateCost(36.0f), Status = SessionStatus.Completed },

            new ChargingSession { Id = 144, VehicleId = 7, PortId = "5.8.1", StartTime = new DateTime(2025, 11, 1, 9, 0, 0), EndTime = new DateTime(2025, 11, 1, 11, 15, 0), EnergyConsumed = 30.3f, TotalCost = CalculateCost(30.3f), Status = SessionStatus.Completed },
            new ChargingSession { Id = 145, VehicleId = 7, PortId = "6.9.1", StartTime = new DateTime(2025, 11, 9, 12, 30, 0), EndTime = new DateTime(2025, 11, 9, 14, 45, 0), EnergyConsumed = 32.9f, TotalCost = CalculateCost(32.9f), Status = SessionStatus.Completed },
  
            new ChargingSession { Id = 146, VehicleId = 9, PortId = "7.10.1", StartTime = new DateTime(2025, 11, 4, 11, 0, 0), EndTime = new DateTime(2025, 11, 4, 13, 15, 0), EnergyConsumed = 28.3f, TotalCost = CalculateCost(28.3f), Status = SessionStatus.Completed },
 
            new ChargingSession { Id = 147, VehicleId = 10, PortId = "1.5.1", StartTime = new DateTime(2025, 11, 5, 12, 0, 0), EndTime = new DateTime(2025, 11, 5, 14, 15, 0), EnergyConsumed = 39.5f, TotalCost = CalculateCost(39.5f), Status = SessionStatus.Completed },
 
            new ChargingSession { Id = 148, VehicleId = 12, PortId = "2.6.1", StartTime = new DateTime(2025, 11, 6, 9, 30, 0), EndTime = new DateTime(2025, 11, 6, 11, 45, 0), EnergyConsumed = 41.0f, TotalCost = CalculateCost(41.0f), Status = SessionStatus.Completed },
   
            new ChargingSession { Id = 149, VehicleId = 13, PortId = "3.7.1", StartTime = new DateTime(2025, 11, 9, 13, 0, 0), EndTime = new DateTime(2025, 11, 9, 15, 15, 0), EnergyConsumed = 42.9f, TotalCost = CalculateCost(42.9f), Status = SessionStatus.Completed }
        );

    modelBuilder.Entity<VehiclePerMonth>().HasData(
        // Tháng 7 (PeriodId = 19)
        new VehiclePerMonth { VehicleMonthId = 1, VehicleId = 1, PeriodId = 19, TotalSessions = 4, TotalEnergy = 160.6f, TotalCost = 619623, AmountPaid = 619623 }, 
        new VehiclePerMonth { VehicleMonthId = 2, VehicleId = 2, PeriodId = 19, TotalSessions = 3, TotalEnergy = 129.1f, TotalCost = 498068, AmountPaid = 498068 }, 
        new VehiclePerMonth { VehicleMonthId = 3, VehicleId = 3, PeriodId = 19, TotalSessions = 2, TotalEnergy = 60.1f, TotalCost = 231866, AmountPaid = 231866 }, 
        new VehiclePerMonth { VehicleMonthId = 4, VehicleId = 4, PeriodId = 19, TotalSessions = 4, TotalEnergy = 165.4f, TotalCost = 637921, AmountPaid = 637921 }, 
        new VehiclePerMonth { VehicleMonthId = 5, VehicleId = 5, PeriodId = 19, TotalSessions = 3, TotalEnergy = 134.6f, TotalCost = 519563, AmountPaid = 519563 }, 
        new VehiclePerMonth { VehicleMonthId = 6, VehicleId = 6, PeriodId = 19, TotalSessions = 3, TotalEnergy = 117.7f, TotalCost = 454045, AmountPaid = 454045 }, 
        new VehiclePerMonth { VehicleMonthId = 7, VehicleId = 7, PeriodId = 19, TotalSessions = 2, TotalEnergy = 64.3f, TotalCost = 248033, AmountPaid = 248033 }, 
        new VehiclePerMonth { VehicleMonthId = 8, VehicleId = 8, PeriodId = 19, TotalSessions = 2, TotalEnergy = 74.1f, TotalCost = 285918, AmountPaid = 285918 }, 
        new VehiclePerMonth { VehicleMonthId = 9, VehicleId = 9, PeriodId = 19, TotalSessions = 4, TotalEnergy = 131.2f, TotalCost = 506409, AmountPaid = 506409 }, 
        new VehiclePerMonth { VehicleMonthId = 10, VehicleId = 10, PeriodId = 19, TotalSessions = 3, TotalEnergy = 114.3f, TotalCost = 441017, AmountPaid = 441017 }, 
        new VehiclePerMonth { VehicleMonthId = 11, VehicleId = 11, PeriodId = 19, TotalSessions = 2, TotalEnergy = 69.4f, TotalCost = 267710, AmountPaid = 267710 }, 
        new VehiclePerMonth { VehicleMonthId = 12, VehicleId = 12, PeriodId = 19, TotalSessions = 4, TotalEnergy = 175.8f, TotalCost = 678314, AmountPaid = 678314 }, 
        new VehiclePerMonth { VehicleMonthId = 13, VehicleId = 13, PeriodId = 19, TotalSessions = 2, TotalEnergy = 83.2f, TotalCost = 321150, AmountPaid = 321150 }, 
        
        // Tháng 8 (PeriodId = 20): 
        new VehiclePerMonth { VehicleMonthId = 14, VehicleId = 1, PeriodId = 20, TotalSessions = 3, TotalEnergy = 114.3f, TotalCost = 441017, AmountPaid = 441017 }, 
        new VehiclePerMonth { VehicleMonthId = 15, VehicleId = 2, PeriodId = 20, TotalSessions = 3, TotalEnergy = 129.3f, TotalCost = 498839, AmountPaid = 498839 }, 
        new VehiclePerMonth { VehicleMonthId = 16, VehicleId = 3, PeriodId = 20, TotalSessions = 4, TotalEnergy = 129.7f, TotalCost = 500383, AmountPaid = 0 }, // **BLOCKS T9**
        new VehiclePerMonth { VehicleMonthId = 17, VehicleId = 4, PeriodId = 20, TotalSessions = 2, TotalEnergy = 83.3f, TotalCost = 321536, AmountPaid = 321536 }, 
        new VehiclePerMonth { VehicleMonthId = 18, VehicleId = 5, PeriodId = 20, TotalSessions = 4, TotalEnergy = 181.8f, TotalCost = 701468, AmountPaid = 701468 }, 
        new VehiclePerMonth { VehicleMonthId = 19, VehicleId = 6, PeriodId = 20, TotalSessions = 3, TotalEnergy = 139.6f, TotalCost = 538787, AmountPaid = 538787 }, 
        new VehiclePerMonth { VehicleMonthId = 20, VehicleId = 7, PeriodId = 20, TotalSessions = 4, TotalEnergy = 130.8f, TotalCost = 504626, AmountPaid = 504626 }, 
        new VehiclePerMonth { VehicleMonthId = 21, VehicleId = 8, PeriodId = 20, TotalSessions = 3, TotalEnergy = 136.7f, TotalCost = 527581, AmountPaid = 527581 }, 
        new VehiclePerMonth { VehicleMonthId = 22, VehicleId = 9, PeriodId = 20, TotalSessions = 2, TotalEnergy = 80.6f, TotalCost = 310931, AmountPaid = 310931 }, 
        new VehiclePerMonth { VehicleMonthId = 23, VehicleId = 10, PeriodId = 20, TotalSessions = 2, TotalEnergy = 76.1f, TotalCost = 293644, AmountPaid = 293644 }, 
        new VehiclePerMonth { VehicleMonthId = 24, VehicleId = 11, PeriodId = 20, TotalSessions = 3, TotalEnergy = 109.2f, TotalCost = 421449, AmountPaid = 421449 }, 
        new VehiclePerMonth { VehicleMonthId = 25, VehicleId = 12, PeriodId = 20, TotalSessions = 2, TotalEnergy = 86.5f, TotalCost = 333657, AmountPaid = 333657 }, 
        new VehiclePerMonth { VehicleMonthId = 26, VehicleId = 13, PeriodId = 20, TotalSessions = 4, TotalEnergy = 171.8f, TotalCost = 662990, AmountPaid = 662990 }, 

        // Tháng 9 (PeriodId = 21):
        new VehiclePerMonth { VehicleMonthId = 27, VehicleId = 1, PeriodId = 21, TotalSessions = 2, TotalEnergy = 77.5f, TotalCost = 299085, AmountPaid = 299085 }, 
        new VehiclePerMonth { VehicleMonthId = 28, VehicleId = 2, PeriodId = 21, TotalSessions = 4, TotalEnergy = 173.5f, TotalCost = 669483, AmountPaid = 669483 }, 
        new VehiclePerMonth { VehicleMonthId = 29, VehicleId = 3, PeriodId = 21, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        new VehiclePerMonth { VehicleMonthId = 30, VehicleId = 4, PeriodId = 21, TotalSessions = 2, TotalEnergy = 82.7f, TotalCost = 319128, AmountPaid = 319128 }, 
        new VehiclePerMonth { VehicleMonthId = 31, VehicleId = 5, PeriodId = 21, TotalSessions = 3, TotalEnergy = 134.0f, TotalCost = 517272, AmountPaid = 517272 }, 
        new VehiclePerMonth { VehicleMonthId = 32, VehicleId = 6, PeriodId = 21, TotalSessions = 3, TotalEnergy = 117.1f, TotalCost = 451730, AmountPaid = 451730 }, 
        new VehiclePerMonth { VehicleMonthId = 33, VehicleId = 7, PeriodId = 21, TotalSessions = 4, TotalEnergy = 137.6f, TotalCost = 530860, AmountPaid = 530860 }, 
        new VehiclePerMonth { VehicleMonthId = 34, VehicleId = 8, PeriodId = 21, TotalSessions = 3, TotalEnergy = 136.7f, TotalCost = 527581, AmountPaid = 0 }, // **BLOCKS T10**
        new VehiclePerMonth { VehicleMonthId = 35, VehicleId = 9, PeriodId = 21, TotalSessions = 3, TotalEnergy = 93.6f, TotalCost = 361097, AmountPaid = 361097 }, 
        new VehiclePerMonth { VehicleMonthId = 36, VehicleId = 10, PeriodId = 21, TotalSessions = 2, TotalEnergy = 75.1f, TotalCost = 289876, AmountPaid = 289876 }, 
        new VehiclePerMonth { VehicleMonthId = 37, VehicleId = 11, PeriodId = 21, TotalSessions = 2, TotalEnergy = 69.8f, TotalCost = 269228, AmountPaid = 0 }, // **BLOCKS T10**
        new VehiclePerMonth { VehicleMonthId = 38, VehicleId = 12, PeriodId = 21, TotalSessions = 4, TotalEnergy = 175.0f, TotalCost = 675276, AmountPaid = 675276 }, 
        new VehiclePerMonth { VehicleMonthId = 39, VehicleId = 13, PeriodId = 21, TotalSessions = 2, TotalEnergy = 82.8f, TotalCost = 319514, AmountPaid = 319514 },

        // Tháng 10 (PeriodId = 22): 
        new VehiclePerMonth { VehicleMonthId = 40, VehicleId = 1, PeriodId = 22, TotalSessions = 3, TotalEnergy = 116.4f, TotalCost = 449275, AmountPaid = 449275 }, 
        new VehiclePerMonth { VehicleMonthId = 41, VehicleId = 2, PeriodId = 22, TotalSessions = 2, TotalEnergy = 90.0f, TotalCost = 347220, AmountPaid = 347220 }, 
        new VehiclePerMonth { VehicleMonthId = 42, VehicleId = 3, PeriodId = 22, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        new VehiclePerMonth { VehicleMonthId = 43, VehicleId = 4, PeriodId = 22, TotalSessions = 4, TotalEnergy = 164.1f, TotalCost = 632832, AmountPaid = 632832 }, 
        new VehiclePerMonth { VehicleMonthId = 44, VehicleId = 5, PeriodId = 22, TotalSessions = 3, TotalEnergy = 134.6f, TotalCost = 519563, AmountPaid = 0 }, // **BLOCKS T11**
        new VehiclePerMonth { VehicleMonthId = 45, VehicleId = 6, PeriodId = 22, TotalSessions = 2, TotalEnergy = 74.9f, TotalCost = 288975, AmountPaid = 288975 }, 
        new VehiclePerMonth { VehicleMonthId = 46, VehicleId = 7, PeriodId = 22, TotalSessions = 3, TotalEnergy = 98.8f, TotalCost = 381398, AmountPaid = 381398 }, 
        new VehiclePerMonth { VehicleMonthId = 47, VehicleId = 8, PeriodId = 22, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        new VehiclePerMonth { VehicleMonthId = 48, VehicleId = 9, PeriodId = 22, TotalSessions = 3, TotalEnergy = 93.6f, TotalCost = 361097, AmountPaid = 361097 }, 
        new VehiclePerMonth { VehicleMonthId = 49, VehicleId = 10, PeriodId = 22, TotalSessions = 2, TotalEnergy = 74.7f, TotalCost = 288397, AmountPaid = 288397 }, 
        new VehiclePerMonth { VehicleMonthId = 50, VehicleId = 11, PeriodId = 22, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        new VehiclePerMonth { VehicleMonthId = 51, VehicleId = 12, PeriodId = 22, TotalSessions = 2, TotalEnergy = 85.1f, TotalCost = 328336, AmountPaid = 328336 }, 
        new VehiclePerMonth { VehicleMonthId = 52, VehicleId = 13, PeriodId = 22, TotalSessions = 3, TotalEnergy = 125.1f, TotalCost = 482708, AmountPaid = 482708 }

        // Tháng 11 (PeriodId = 23): Partial month. Xe 3, 5, 8, 11 BLOCKED.
        // new VehiclePerMonth { VehicleMonthId = 53, VehicleId = 1, PeriodId = 23, TotalSessions = 1, TotalEnergy = 40.7f, TotalCost = 157070, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 54, VehicleId = 2, PeriodId = 23, TotalSessions = 1, TotalEnergy = 46.7f, TotalCost = 180237, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 55, VehicleId = 3, PeriodId = 23, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        // new VehiclePerMonth { VehicleMonthId = 56, VehicleId = 4, PeriodId = 23, TotalSessions = 2, TotalEnergy = 82.4f, TotalCost = 317971, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 57, VehicleId = 5, PeriodId = 23, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        // new VehiclePerMonth { VehicleMonthId = 58, VehicleId = 6, PeriodId = 23, TotalSessions = 1, TotalEnergy = 36.0f, TotalCost = 138888, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 59, VehicleId = 7, PeriodId = 23, TotalSessions = 2, TotalEnergy = 63.2f, TotalCost = 243880, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 60, VehicleId = 8, PeriodId = 23, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        // new VehiclePerMonth { VehicleMonthId = 61, VehicleId = 9, PeriodId = 23, TotalSessions = 1, TotalEnergy = 28.3f, TotalCost = 109247, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 62, VehicleId = 10, PeriodId = 23, TotalSessions = 1, TotalEnergy = 39.5f, TotalCost = 152431, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 63, VehicleId = 11, PeriodId = 23, TotalSessions = 0, TotalEnergy = 0f, TotalCost = 0, AmountPaid = 0 }, // BLOCKED
        // new VehiclePerMonth { VehicleMonthId = 64, VehicleId = 12, PeriodId = 23, TotalSessions = 1, TotalEnergy = 41.0f, TotalCost = 158178, AmountPaid = 0 }, 
        // new VehiclePerMonth { VehicleMonthId = 65, VehicleId = 13, PeriodId = 23, TotalSessions = 1, TotalEnergy = 42.9f, TotalCost = 165445, AmountPaid = 0 } 
    );

        // MonthlyPeriod seed data
        modelBuilder.Entity<MonthlyPeriod>().HasData(
            // new MonthlyPeriod { PeriodId = 1, Month = 1, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 2, Month = 2, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 3, Month = 3, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 4, Month = 4, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 5, Month = 5, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 6, Month = 6, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 7, Month = 7, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 8, Month = 8, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 9, Month = 9, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 10, Month = 10, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 11, Month = 11, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 12, Month = 12, Year = 2024, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 13, Month = 1, Year = 2025, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 14, Month = 2, Year = 2025, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 15, Month = 3, Year = 2025, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 16, Month = 4, Year = 2025, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 17, Month = 5, Year = 2025, Status = PeriodStatus.Open },
            // new MonthlyPeriod { PeriodId = 18, Month = 6, Year = 2025, Status = PeriodStatus.Open },
            new MonthlyPeriod { PeriodId = 19, Month = 7, Year = 2025, Status = PeriodStatus.Closed },
            new MonthlyPeriod { PeriodId = 20, Month = 8, Year = 2025, Status = PeriodStatus.Closed },
            new MonthlyPeriod { PeriodId = 21, Month = 9, Year = 2025, Status = PeriodStatus.Closed },
            new MonthlyPeriod { PeriodId = 22, Month = 10, Year = 2025, Status = PeriodStatus.Closed },
            new MonthlyPeriod { PeriodId = 23, Month = 11, Year = 2025, Status = PeriodStatus.Open }
            // new MonthlyPeriod { PeriodId = 24, Month = 12, Year = 2025, Status = PeriodStatus.Open }
        );

        // XÓA BỎ KHỐI PaymentTransaction CŨ VÀ THAY BẰNG KHỐI NÀY:

modelBuilder.Entity<PaymentTransaction>().HasData(
    // --- Period 19 (July 2025)
    new PaymentTransaction
    {
        Id = 1, VehicleMonthId = 1, VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 619623, CreatedAt = new DateTime(2025, 8, 2, 9, 10, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 3 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 2, VehicleMonthId = 2, VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 498068, CreatedAt = new DateTime(2025, 8, 2, 9, 11, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for VinFast VF 8 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 3, VehicleMonthId = 3, VehicleId = 3, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 231866, CreatedAt = new DateTime(2025, 8, 2, 9, 12, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Nissan Leaf (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 4, VehicleMonthId = 4, VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 637921, CreatedAt = new DateTime(2025, 8, 2, 9, 13, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Hyundai Ioniq 5 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 5, VehicleMonthId = 5, VehicleId = 5, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 519563, CreatedAt = new DateTime(2025, 8, 2, 9, 14, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Kia EV6 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 6, VehicleMonthId = 6, VehicleId = 6, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 454045, CreatedAt = new DateTime(2025, 8, 3, 10, 5, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model Y (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 7, VehicleMonthId = 7, VehicleId = 7, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 248033, CreatedAt = new DateTime(2025, 8, 3, 10, 6, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 4 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 8, VehicleMonthId = 8, VehicleId = 8, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 285918, CreatedAt = new DateTime(2025, 8, 3, 10, 7, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for BYD Seal (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 9, VehicleMonthId = 9, VehicleId = 9, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 506409, CreatedAt = new DateTime(2025, 8, 3, 10, 8, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Ford F-150 Lightning (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 10, VehicleMonthId = 10, VehicleId = 10, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 441017, CreatedAt = new DateTime(2025, 8, 1, 11, 20, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Chevrolet Bolt EV (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 11, VehicleMonthId = 11, VehicleId = 11, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 267710, CreatedAt = new DateTime(2025, 8, 1, 11, 21, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Volvo EX30 (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 12, VehicleMonthId = 12, VehicleId = 12, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 678314, CreatedAt = new DateTime(2025, 8, 1, 11, 22, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Audi e-tron GT (Jul-2025)"
    },
    new PaymentTransaction
    {
        Id = 13, VehicleMonthId = 13, VehicleId = 13, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 321150, CreatedAt = new DateTime(2025, 8, 1, 11, 23, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Porsche Taycan (Jul-2025)"
    },

    // --- Period 20 (August 2025)
    new PaymentTransaction
    {
        Id = 14, VehicleMonthId = 14, VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 441017, CreatedAt = new DateTime(2025, 9, 2, 8, 30, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 3 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 15, VehicleMonthId = 15, VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 498839, CreatedAt = new DateTime(2025, 9, 2, 8, 31, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for VinFast VF 8 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 17, VehicleMonthId = 17, VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 321536, CreatedAt = new DateTime(2025, 9, 2, 8, 33, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Hyundai Ioniq 5 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 18, VehicleMonthId = 18, VehicleId = 5, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 701468, CreatedAt = new DateTime(2025, 9, 2, 8, 34, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Kia EV6 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 19, VehicleMonthId = 19, VehicleId = 6, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 538787, CreatedAt = new DateTime(2025, 9, 3, 11, 15, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model Y (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 20, VehicleMonthId = 20, VehicleId = 7, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 504626, CreatedAt = new DateTime(2025, 9, 3, 11, 16, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 4 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 21, VehicleMonthId = 21, VehicleId = 8, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 527581, CreatedAt = new DateTime(2025, 9, 3, 11, 17, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for BYD Seal (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 22, VehicleMonthId = 22, VehicleId = 9, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 310931, CreatedAt = new DateTime(2025, 9, 3, 11, 18, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Ford F-150 Lightning (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 23, VehicleMonthId = 23, VehicleId = 10, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 293644, CreatedAt = new DateTime(2025, 9, 1, 14, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Chevrolet Bolt EV (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 24, VehicleMonthId = 24, VehicleId = 11, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 421449, CreatedAt = new DateTime(2025, 9, 1, 14, 1, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Volvo EX30 (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 25, VehicleMonthId = 25, VehicleId = 12, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 333657, CreatedAt = new DateTime(2025, 9, 1, 14, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Audi e-tron GT (Aug-2025)"
    },
    new PaymentTransaction
    {
        Id = 26, VehicleMonthId = 26, VehicleId = 13, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 662990, CreatedAt = new DateTime(2025, 9, 1, 14, 3, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Porsche Taycan (Aug-2025)"
    },

    // --- Period 21 (September 2025)
    new PaymentTransaction
    {
        Id = 27, VehicleMonthId = 27, VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 299085, CreatedAt = new DateTime(2025, 10, 2, 9, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 3 (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 28, VehicleMonthId = 28, VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 669483, CreatedAt = new DateTime(2025, 10, 2, 9, 1, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for VinFast VF 8 (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 29, VehicleMonthId = 30, VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 319128, CreatedAt = new DateTime(2025, 10, 2, 9, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Hyundai Ioniq 5 (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 30, VehicleMonthId = 31, VehicleId = 5, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 517272, CreatedAt = new DateTime(2025, 10, 2, 9, 3, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Kia EV6 (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 31, VehicleMonthId = 32, VehicleId = 6, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 451730, CreatedAt = new DateTime(2025, 10, 3, 10, 10, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model Y (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 32, VehicleMonthId = 33, VehicleId = 7, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 530860, CreatedAt = new DateTime(2025, 10, 3, 10, 11, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 4 (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 34, VehicleMonthId = 35, VehicleId = 9, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 361097, CreatedAt = new DateTime(2025, 10, 3, 10, 13, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Ford F-150 Lightning (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 35, VehicleMonthId = 36, VehicleId = 10, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 289876, CreatedAt = new DateTime(2025, 10, 1, 12, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Chevrolet Bolt EV (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 37, VehicleMonthId = 38, VehicleId = 12, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 675276, CreatedAt = new DateTime(2025, 10, 1, 12, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Audi e-tron GT (Sep-2025)"
    },
    new PaymentTransaction
    {
        Id = 38, VehicleMonthId = 39, VehicleId = 13, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 319514, CreatedAt = new DateTime(2025, 10, 1, 12, 3, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Porsche Taycan (Sep-2025)"
    },

    // --- Period 22 (October 2025)
    new PaymentTransaction
    {
        Id = 39, VehicleMonthId = 40, VehicleId = 1, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 449275, CreatedAt = new DateTime(2025, 11, 2, 10, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 3 (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 40, VehicleMonthId = 41, VehicleId = 2, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 347220, CreatedAt = new DateTime(2025, 11, 2, 10, 1, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for VinFast VF 8 (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 41, VehicleMonthId = 43, VehicleId = 4, CustomerId = "k825tKKC1aex70inOKxd2lQpJUD3",
        Amount = 632832, CreatedAt = new DateTime(2025, 11, 2, 10, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Hyundai Ioniq 5 (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 43, VehicleMonthId = 45, VehicleId = 6, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 288975, CreatedAt = new DateTime(2025, 11, 3, 11, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model Y (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 44, VehicleMonthId = 46, VehicleId = 7, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 381398, CreatedAt = new DateTime(2025, 11, 3, 11, 1, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Tesla Model 4 (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 45, VehicleMonthId = 48, VehicleId = 9, CustomerId = "l1sufzGdTdYyIZJ8c0VypXyhmR02",
        Amount = 361097, CreatedAt = new DateTime(2025, 11, 3, 11, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Ford F-150 Lightning (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 46, VehicleMonthId = 49, VehicleId = 10, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 288397, CreatedAt = new DateTime(2025, 11, 1, 15, 0, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Chevrolet Bolt EV (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 47, VehicleMonthId = 51, VehicleId = 12, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 328336, CreatedAt = new DateTime(2025, 11, 1, 15, 1, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Audi e-tron GT (Oct-2025)"
    },
    new PaymentTransaction
    {
        Id = 48, VehicleMonthId = 52, VehicleId = 13, CustomerId = "JEBFEGirUGhlgQadF4xRrofZo9X2",
        Amount = 482708, CreatedAt = new DateTime(2025, 11, 1, 15, 2, 0, DateTimeKind.Utc),
        ResponseCode = "00", TransactionStatus = "00", OrderInfo = "Payment for Porsche Taycan (Oct-2025)"
    }
);

modelBuilder.Entity<Package>().HasData(
        new Package
        {
            Id = 1,
            Name = "Tiết Kiệm",
            Description = "Giảm 5% mỗi lần sạc, thêm 15 phút giữ chỗ",
            MonthlyPrice = 49000,
            DiscountPercent = 5,
            ReservationTime = 75,
            IsActive = true,
        },
        new Package
        {
            Id = 2,
            Name = "Năng Động",
            Description = "Giảm 10% mỗi lần sạc, thêm 20 phút giữ chỗ",
            MonthlyPrice = 99000,
            DiscountPercent = 10,
            ReservationTime = 80,
            IsActive = true,
        },
        new Package
        {
            Id = 3,
            Name = "Chuyên Nghiệp",
            Description = "Giảm 15% mỗi lần sạc, thêm 30 phút giữ chỗ",
            MonthlyPrice = 199000,
            DiscountPercent = 15,
            ReservationTime = 90,
            IsActive = true,
        }
    );
        

    }

    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<ChargingStation> ChargingStations { get; set; } = null!;

    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;

    public DbSet<Connector> Connectors { get; set; } = null!;

    public DbSet<ChargingPoint> ChargingPoints { get; set; } = null!;

    public DbSet<ChargingPort> ChargingPorts { get; set; } = null!;

    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    public DbSet<VehiclePort> VehiclePorts { get; set; } = null!;

    public DbSet<ChargingSession> ChargingSessions { get; set; } = null!;

    public DbSet<MonthlyPeriod> MonthlyPeriods { get; set; } = null!;

    public DbSet<VehiclePerMonth> VehiclePerMonths { get; set; } = null!;

    public DbSet<PriceTable> PriceTables { get; set; } = null!;

    public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = null!;

    public DbSet<Reservation> Reservations { get; set; } = null!;

    public DbSet<Package> Packages { get; set; } = null!;

    public DbSet<PackageSubscription> PackageSubscriptions { get; set; } = null!;
}