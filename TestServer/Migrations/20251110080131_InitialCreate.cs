using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingStations", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Connectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connectors", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyPeriods",
                columns: table => new
                {
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPeriods", x => x.PeriodId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleMonthId = table.Column<int>(type: "int", nullable: false),
                    ResponseCode = table.Column<string>(type: "longtext", nullable: false),
                    TransactionStatus = table.Column<string>(type: "longtext", nullable: false),
                    OrderInfo = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PowerRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Range = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerRanges", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PriceTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PricePerKWh = table.Column<float>(type: "float", nullable: false),
                    PenaltyFeePerMinute = table.Column<float>(type: "float", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTables", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Range = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRanges", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingPoints",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargingPoints_ChargingStations_StationId",
                        column: x => x.StationId,
                        principalTable: "ChargingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    LicensePlate = table.Column<string>(type: "longtext", nullable: false),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingPorts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    PointId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ConnectorId = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargingPorts_ChargingPoints_PointId",
                        column: x => x.PointId,
                        principalTable: "ChargingPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargingPorts_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalTable: "Connectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleConnectorTypes",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ConnectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleConnectorTypes", x => new { x.VehicleId, x.ConnectorId });
                    table.ForeignKey(
                        name: "FK_VehicleConnectorTypes_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalTable: "Connectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleConnectorTypes_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehiclePerMonths",
                columns: table => new
                {
                    VehicleMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    TotalSessions = table.Column<int>(type: "int", nullable: false),
                    TotalEnergy = table.Column<float>(type: "float", nullable: false),
                    TotalCost = table.Column<float>(type: "float", nullable: false),
                    AmountPaid = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePerMonths", x => x.VehicleMonthId);
                    table.ForeignKey(
                        name: "FK_VehiclePerMonths_MonthlyPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "MonthlyPeriods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePerMonths_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehiclePorts",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ConnectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePorts", x => new { x.VehicleId, x.ConnectorId });
                    table.ForeignKey(
                        name: "FK_VehiclePorts_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalTable: "Connectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePorts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PortId = table.Column<string>(type: "varchar(255)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnergyConsumed = table.Column<float>(type: "float", nullable: false),
                    TotalCost = table.Column<float>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargingSessions_ChargingPorts_PortId",
                        column: x => x.PortId,
                        principalTable: "ChargingPorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargingSessions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ChargingStations",
                columns: new[] { "Id", "Latitude", "Location", "Longitude", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 10.846289725256499, "778 Nguyen Van Qua, Dong Hung Thuan Ward, District 12, Ho Chi Minh City", 106.63358659588795, "Parking lot S778 Nguyen Van Qua", 0 },
                    { 2, 10.778019786911162, "Basement B3, Léman Luxury Apartments, 117 Nguyễn Đình Chiểu, Ward 6, District 3, Ho Chi Minh City", 106.68989161819898, "Léman Luxury Apartments", 0 },
                    { 3, 10.759974990301892, "243 Tan Hoa Dong, Ward 14, District 6, Ho Chi Minh City", 106.62537124357758, "Summer Square Apartment Complex", 0 },
                    { 4, 10.726400325147486, "Basement B2, 15 Nguyen Luong Bang, Tan Phu Ward, District 7, Ho Chi Minh City", 106.72395755358133, "Golden King Apartment Complex", 0 },
                    { 5, 10.744180504637178, "71 Tran Trong Cung, Tan Thuan Dong Ward, District 7, Ho Chi Minh City", 106.73212781504205, "TTTM VinCom+ Nam Long", 0 },
                    { 6, 10.738380975551181, "54 Nguyen Thi Thap, Binh Thuan Ward, District 7, Ho Chi Minh City", 106.72723544339814, "VinFast - Chevrolet Phu My Hung Car Dealership", 0 },
                    { 7, 10.721662104756106, "Green View, Tân Phú Ward, District 7, Ho Chi Minh City", 106.72691002973274, "Green View Apartment Complex", 0 }
                });

            migrationBuilder.InsertData(
                table: "Connectors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AC" },
                    { 2, "CCS" },
                    { 3, "CHAdeMO" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "JEBFEGirUGhlgQadF4xRrofZo9X2", "Quận 9, TP.HCM", "nguyenbuidangkhoixt@gmail.com", "Nguyen Bui Dang Khoi", "0909876543" },
                    { "k825tKKC1aex70inOKxd2lQpJUD3", "Quận 1, TP.HCM", "nguyenxuanthinh@gmail.com", "Nguyen Xuan Thinh", "0901234567" },
                    { "l1sufzGdTdYyIZJ8c0VypXyhmR02", "Quận 3, TP.HCM", "nguyenthai0418@gmail.com", "Nguyen Hung Thai", "0905123456" }
                });

            migrationBuilder.InsertData(
                table: "MonthlyPeriods",
                columns: new[] { "PeriodId", "Month", "Year" },
                values: new object[,]
                {
                    { 1, 1, 2024 },
                    { 2, 2, 2024 },
                    { 3, 3, 2024 },
                    { 4, 4, 2024 },
                    { 5, 5, 2024 },
                    { 6, 6, 2024 },
                    { 7, 7, 2024 },
                    { 8, 8, 2024 },
                    { 9, 9, 2024 },
                    { 10, 10, 2024 },
                    { 11, 11, 2024 },
                    { 12, 12, 2024 },
                    { 13, 1, 2025 },
                    { 14, 2, 2025 },
                    { 15, 3, 2025 },
                    { 16, 4, 2025 },
                    { 17, 5, 2025 },
                    { 18, 6, 2025 },
                    { 19, 7, 2025 },
                    { 20, 8, 2025 },
                    { 21, 9, 2025 },
                    { 22, 10, 2025 },
                    { 23, 11, 2025 },
                    { 24, 12, 2025 }
                });

            migrationBuilder.InsertData(
                table: "PowerRanges",
                columns: new[] { "Id", "Range" },
                values: new object[,]
                {
                    { 1, "0-7" },
                    { 2, "7-50" },
                    { 3, "50-150" }
                });

            migrationBuilder.InsertData(
                table: "PriceTables",
                columns: new[] { "Id", "PenaltyFeePerMinute", "PricePerKWh", "Status", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 800f, 3500f, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1000f, 3858f, 0, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1200f, 4000f, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TimeRanges",
                columns: new[] { "Id", "Range" },
                values: new object[,]
                {
                    { 1, "06:01–17:00" },
                    { 2, "17:01–21:00" },
                    { 3, "21:01–06:00" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Motorbike" },
                    { 2, "Car" }
                });

            migrationBuilder.InsertData(
                table: "ChargingPoints",
                columns: new[] { "Id", "StationId", "Status" },
                values: new object[,]
                {
                    { "1.1", 1, 0 },
                    { "1.2", 1, 0 },
                    { "1.3", 1, 0 },
                    { "1.4", 1, 0 },
                    { "1.5", 1, 0 },
                    { "1.6", 1, 0 },
                    { "1.7", 1, 0 },
                    { "2.1", 2, 0 },
                    { "2.10", 2, 0 },
                    { "2.2", 2, 0 },
                    { "2.3", 2, 0 },
                    { "2.4", 2, 0 },
                    { "2.5", 2, 0 },
                    { "2.6", 2, 0 },
                    { "2.7", 2, 0 },
                    { "2.8", 2, 0 },
                    { "2.9", 2, 0 },
                    { "3.1", 3, 0 },
                    { "3.10", 3, 0 },
                    { "3.2", 3, 0 },
                    { "3.3", 3, 0 },
                    { "3.4", 3, 0 },
                    { "3.5", 3, 0 },
                    { "3.6", 3, 0 },
                    { "3.7", 3, 0 },
                    { "3.8", 3, 0 },
                    { "3.9", 3, 0 },
                    { "4.1", 4, 0 },
                    { "4.10", 4, 0 },
                    { "4.2", 4, 0 },
                    { "4.3", 4, 0 },
                    { "4.4", 4, 0 },
                    { "4.5", 4, 0 },
                    { "4.6", 4, 0 },
                    { "4.7", 4, 0 },
                    { "4.8", 4, 0 },
                    { "4.9", 4, 0 },
                    { "5.1", 5, 0 },
                    { "5.10", 5, 0 },
                    { "5.2", 5, 0 },
                    { "5.3", 5, 0 },
                    { "5.4", 5, 0 },
                    { "5.5", 5, 0 },
                    { "5.6", 5, 0 },
                    { "5.7", 5, 0 },
                    { "5.8", 5, 0 },
                    { "5.9", 5, 0 },
                    { "6.1", 6, 0 },
                    { "6.10", 6, 0 },
                    { "6.2", 6, 0 },
                    { "6.3", 6, 0 },
                    { "6.4", 6, 0 },
                    { "6.5", 6, 0 },
                    { "6.6", 6, 0 },
                    { "6.7", 6, 0 },
                    { "6.8", 6, 0 },
                    { "6.9", 6, 0 },
                    { "7.1", 7, 0 },
                    { "7.10", 7, 0 },
                    { "7.2", 7, 0 },
                    { "7.3", 7, 0 },
                    { "7.4", 7, 0 },
                    { "7.5", 7, 0 },
                    { "7.6", 7, 0 },
                    { "7.7", 7, 0 },
                    { "7.8", 7, 0 },
                    { "7.9", 7, 0 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "BatteryCapacity", "CustomerId", "LicensePlate", "Name", "Status", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, 70, "k825tKKC1aex70inOKxd2lQpJUD3", "51B-67890", "Tesla Model 3", "Active", 2 },
                    { 2, 55, "k825tKKC1aex70inOKxd2lQpJUD3", "30A-12345", "VinFast VF 8", "Active", 2 },
                    { 3, 66, "k825tKKC1aex70inOKxd2lQpJUD3", "29C-56789", "Nissan Leaf", "Blocked", 2 },
                    { 4, 52, "k825tKKC1aex70inOKxd2lQpJUD3", "88D-45678", "Hyundai Ioniq 5", "Active", 2 },
                    { 5, 51, "k825tKKC1aex70inOKxd2lQpJUD3", "77E-99999", "Kia EV6", "Blocked", 2 },
                    { 6, 69, "l1sufzGdTdYyIZJ8c0VypXyhmR02", "68A-12345", "Tesla Model Y", "Active", 2 },
                    { 7, 54, "l1sufzGdTdYyIZJ8c0VypXyhmR02", "99B-67890", "Tesla Model 4", "Active", 2 },
                    { 8, 57, "l1sufzGdTdYyIZJ8c0VypXyhmR02", "12C-34567", "BYD Seal", "Blocked", 2 },
                    { 9, 68, "l1sufzGdTdYyIZJ8c0VypXyhmR02", "34D-89012", "Ford F-150 Lightning", "Active", 2 },
                    { 10, 66, "JEBFEGirUGhlgQadF4xRrofZo9X2", "56E-34567", "Chevrolet Bolt EV", "Active", 2 },
                    { 11, 53, "JEBFEGirUGhlgQadF4xRrofZo9X2", "78F-90123", "Volvo EX30", "Blocked", 2 },
                    { 12, 64, "JEBFEGirUGhlgQadF4xRrofZo9X2", "90G-45678", "Audi e-tron GT", "Active", 2 },
                    { 13, 62, "JEBFEGirUGhlgQadF4xRrofZo9X2", "21H-78901", "Porsche Taycan", "Active", 2 }
                });

            migrationBuilder.InsertData(
                table: "ChargingPorts",
                columns: new[] { "Id", "ConnectorId", "PointId", "Power", "Status" },
                values: new object[,]
                {
                    { "1.1.1", 1, "1.1", 7, "Available" },
                    { "1.1.2", 2, "1.1", 50, "Available" },
                    { "1.1.3", 3, "1.1", 50, "Available" },
                    { "1.2.1", 1, "1.2", 11, "Available" },
                    { "1.2.2", 2, "1.2", 150, "Available" },
                    { "1.2.3", 3, "1.2", 150, "Available" },
                    { "1.3.1", 1, "1.3", 22, "Available" },
                    { "1.3.2", 2, "1.3", 150, "Available" },
                    { "1.3.3", 3, "1.3", 150, "Available" },
                    { "1.4.1", 1, "1.4", 7, "Available" },
                    { "1.4.2", 2, "1.4", 350, "Available" },
                    { "1.4.3", 3, "1.4", 50, "Available" },
                    { "1.5.1", 1, "1.5", 7, "Available" },
                    { "1.5.2", 2, "1.5", 50, "Available" },
                    { "1.5.3", 3, "1.5", 50, "Available" },
                    { "1.6.1", 1, "1.6", 11, "Available" },
                    { "1.6.2", 2, "1.6", 50, "Available" },
                    { "1.6.3", 3, "1.6", 50, "Available" },
                    { "1.7.1", 1, "1.7", 22, "Available" },
                    { "1.7.2", 2, "1.7", 50, "Available" },
                    { "1.7.3", 3, "1.7", 50, "Available" },
                    { "2.1.1", 1, "2.1", 11, "Available" },
                    { "2.1.2", 2, "2.1", 150, "Available" },
                    { "2.1.3", 3, "2.1", 450, "Available" },
                    { "2.10.1", 1, "2.10", 7, "Available" },
                    { "2.10.2", 2, "2.10", 50, "Available" },
                    { "2.10.3", 3, "2.10", 50, "Available" },
                    { "2.2.1", 1, "2.2", 22, "Available" },
                    { "2.2.2", 2, "2.2", 50, "Available" },
                    { "2.2.3", 3, "2.2", 50, "Available" },
                    { "2.3.1", 1, "2.3", 22, "Available" },
                    { "2.3.2", 2, "2.3", 50, "Available" },
                    { "2.3.3", 3, "2.3", 50, "Available" },
                    { "2.4.1", 1, "2.4", 7, "Available" },
                    { "2.4.2", 2, "2.4", 50, "Available" },
                    { "2.4.3", 3, "2.4", 50, "Available" },
                    { "2.5.1", 1, "2.5", 11, "Available" },
                    { "2.5.2", 2, "2.5", 50, "Available" },
                    { "2.5.3", 3, "2.5", 50, "Available" },
                    { "2.6.1", 1, "2.6", 22, "Available" },
                    { "2.6.2", 2, "2.6", 50, "Available" },
                    { "2.6.3", 3, "2.6", 50, "Available" },
                    { "2.7.1", 1, "2.7", 7, "Available" },
                    { "2.7.2", 2, "2.7", 50, "Available" },
                    { "2.7.3", 3, "2.7", 50, "Available" },
                    { "2.8.1", 1, "2.8", 11, "Available" },
                    { "2.8.2", 2, "2.8", 150, "Available" },
                    { "2.8.3", 3, "2.8", 150, "Available" },
                    { "2.9.1", 1, "2.9", 22, "Available" },
                    { "2.9.2", 2, "2.9", 150, "Available" },
                    { "2.9.3", 3, "2.9", 50, "Available" },
                    { "3.1.1", 1, "3.1", 11, "Available" },
                    { "3.1.2", 2, "3.1", 50, "Available" },
                    { "3.1.3", 3, "3.1", 50, "Available" },
                    { "3.10.1", 1, "3.10", 7, "Available" },
                    { "3.10.2", 2, "3.10", 50, "Available" },
                    { "3.10.3", 3, "3.10", 50, "Available" },
                    { "3.2.1", 1, "3.2", 22, "Available" },
                    { "3.2.2", 2, "3.2", 50, "Available" },
                    { "3.2.3", 3, "3.2", 50, "Available" },
                    { "3.3.1", 1, "3.3", 7, "Available" },
                    { "3.3.2", 2, "3.3", 50, "Available" },
                    { "3.3.3", 3, "3.3", 50, "Available" },
                    { "3.4.1", 1, "3.4", 11, "Available" },
                    { "3.4.2", 2, "3.4", 50, "Available" },
                    { "3.4.3", 3, "3.4", 50, "Available" },
                    { "3.5.1", 1, "3.5", 22, "Available" },
                    { "3.5.2", 2, "3.5", 150, "Available" },
                    { "3.5.3", 3, "3.5", 150, "Available" },
                    { "3.6.1", 1, "3.6", 7, "Available" },
                    { "3.6.2", 2, "3.6", 150, "Available" },
                    { "3.6.3", 3, "3.6", 150, "Available" },
                    { "3.7.1", 1, "3.7", 11, "Available" },
                    { "3.7.2", 2, "3.7", 350, "Available" },
                    { "3.7.3", 3, "3.7", 50, "Available" },
                    { "3.8.1", 1, "3.8", 11, "Available" },
                    { "3.8.2", 2, "3.8", 50, "Available" },
                    { "3.8.3", 3, "3.8", 50, "Available" },
                    { "3.9.1", 1, "3.9", 22, "Available" },
                    { "3.9.2", 2, "3.9", 50, "Available" },
                    { "3.9.3", 3, "3.9", 50, "Available" },
                    { "4.1.1", 1, "4.1", 22, "Available" },
                    { "4.1.2", 2, "4.1", 50, "Available" },
                    { "4.1.3", 3, "4.1", 50, "Available" },
                    { "4.10.1", 1, "4.10", 11, "Available" },
                    { "4.10.2", 2, "4.10", 50, "Available" },
                    { "4.10.3", 3, "4.10", 150, "Available" },
                    { "4.2.1", 1, "4.2", 7, "Available" },
                    { "4.2.2", 2, "4.2", 50, "Available" },
                    { "4.2.3", 3, "4.2", 50, "Available" },
                    { "4.3.1", 1, "4.3", 11, "Available" },
                    { "4.3.2", 2, "4.3", 150, "Available" },
                    { "4.3.3", 3, "4.3", 150, "Available" },
                    { "4.4.1", 1, "4.4", 22, "Available" },
                    { "4.4.2", 2, "4.4", 150, "Available" },
                    { "4.4.3", 3, "4.4", 450, "Available" },
                    { "4.5.1", 1, "4.5", 7, "Available" },
                    { "4.5.2", 2, "4.5", 50, "Available" },
                    { "4.5.3", 3, "4.5", 50, "Available" },
                    { "4.6.1", 1, "4.6", 7, "Available" },
                    { "4.6.2", 2, "4.6", 50, "Available" },
                    { "4.6.3", 3, "4.6", 50, "Available" },
                    { "4.7.1", 1, "4.7", 11, "Available" },
                    { "4.7.2", 2, "4.7", 50, "Available" },
                    { "4.7.3", 3, "4.7", 50, "Available" },
                    { "4.8.1", 1, "4.8", 22, "Available" },
                    { "4.8.2", 2, "4.8", 50, "Available" },
                    { "4.8.3", 3, "4.8", 50, "Available" },
                    { "4.9.1", 1, "4.9", 7, "Available" },
                    { "4.9.2", 2, "4.9", 50, "Available" },
                    { "4.9.3", 3, "4.9", 50, "Available" },
                    { "5.1.1", 1, "5.1", 7, "Available" },
                    { "5.1.2", 2, "5.1", 150, "Available" },
                    { "5.1.3", 3, "5.1", 150, "Available" },
                    { "5.10.1", 1, "5.10", 22, "Available" },
                    { "5.10.2", 2, "5.10", 350, "Available" },
                    { "5.10.3", 3, "5.10", 50, "Available" },
                    { "5.2.1", 1, "5.2", 11, "Available" },
                    { "5.2.2", 2, "5.2", 350, "Available" },
                    { "5.2.3", 3, "5.2", 50, "Available" },
                    { "5.3.1", 1, "5.3", 11, "Available" },
                    { "5.3.2", 2, "5.3", 50, "Available" },
                    { "5.3.3", 3, "5.3", 50, "Available" },
                    { "5.4.1", 1, "5.4", 22, "Available" },
                    { "5.4.2", 2, "5.4", 50, "Available" },
                    { "5.4.3", 3, "5.4", 50, "Available" },
                    { "5.5.1", 1, "5.5", 7, "Available" },
                    { "5.5.2", 2, "5.5", 50, "Available" },
                    { "5.5.3", 3, "5.5", 50, "Available" },
                    { "5.6.1", 1, "5.6", 11, "Available" },
                    { "5.6.2", 2, "5.6", 50, "Available" },
                    { "5.6.3", 3, "5.6", 50, "Available" },
                    { "5.7.1", 1, "5.7", 22, "Available" },
                    { "5.7.2", 2, "5.7", 50, "Available" },
                    { "5.7.3", 3, "5.7", 50, "Available" },
                    { "5.8.1", 1, "5.8", 7, "Available" },
                    { "5.8.2", 2, "5.8", 150, "Available" },
                    { "5.8.3", 3, "5.8", 150, "Available" },
                    { "5.9.1", 1, "5.9", 11, "Available" },
                    { "5.9.2", 2, "5.9", 150, "Available" },
                    { "5.9.3", 3, "5.9", 150, "Available" },
                    { "6.1.1", 1, "6.1", 7, "Available" },
                    { "6.1.2", 2, "6.1", 50, "Available" },
                    { "6.1.3", 3, "6.1", 50, "Available" },
                    { "6.10.1", 1, "6.10", 22, "Available" },
                    { "6.10.2", 2, "6.10", 50, "Available" },
                    { "6.10.3", 3, "6.10", 50, "Available" },
                    { "6.2.1", 1, "6.2", 11, "Available" },
                    { "6.2.2", 2, "6.2", 50, "Available" },
                    { "6.2.3", 3, "6.2", 50, "Available" },
                    { "6.3.1", 1, "6.3", 22, "Available" },
                    { "6.3.2", 2, "6.3", 50, "Available" },
                    { "6.3.3", 3, "6.3", 50, "Available" },
                    { "6.4.1", 1, "6.4", 7, "Available" },
                    { "6.4.2", 2, "6.4", 50, "Available" },
                    { "6.4.3", 3, "6.4", 50, "Available" },
                    { "6.5.1", 1, "6.5", 11, "Available" },
                    { "6.5.2", 2, "6.5", 50, "Available" },
                    { "6.5.3", 3, "6.5", 50, "Available" },
                    { "6.6.1", 1, "6.6", 22, "Available" },
                    { "6.6.2", 2, "6.6", 150, "Available" },
                    { "6.6.3", 3, "6.6", 150, "Available" },
                    { "6.7.1", 1, "6.7", 7, "Available" },
                    { "6.7.2", 2, "6.7", 150, "Available" },
                    { "6.7.3", 3, "6.7", 150, "Available" },
                    { "6.8.1", 1, "6.8", 11, "Available" },
                    { "6.8.2", 2, "6.8", 50, "Available" },
                    { "6.8.3", 3, "6.8", 50, "Available" },
                    { "6.9.1", 1, "6.9", 11, "Available" },
                    { "6.9.2", 2, "6.9", 50, "Available" },
                    { "6.9.3", 3, "6.9", 50, "Available" },
                    { "7.1.1", 1, "7.1", 11, "Available" },
                    { "7.1.2", 2, "7.1", 50, "Available" },
                    { "7.1.3", 3, "7.1", 50, "Available" },
                    { "7.10.1", 1, "7.10", 7, "Available" },
                    { "7.10.2", 2, "7.10", 50, "Available" },
                    { "7.10.3", 3, "7.10", 50, "Available" },
                    { "7.2.1", 1, "7.2", 22, "Available" },
                    { "7.2.2", 2, "7.2", 50, "Available" },
                    { "7.2.3", 3, "7.2", 50, "Available" },
                    { "7.3.1", 1, "7.3", 7, "Available" },
                    { "7.3.2", 2, "7.3", 150, "Available" },
                    { "7.3.3", 3, "7.3", 50, "Available" },
                    { "7.4.1", 1, "7.4", 11, "Available" },
                    { "7.4.2", 2, "7.4", 150, "Available" },
                    { "7.4.3", 3, "7.4", 50, "Available" },
                    { "7.5.1", 1, "7.5", 22, "Available" },
                    { "7.5.2", 2, "7.5", 350, "Available" },
                    { "7.5.3", 3, "7.5", 50, "Available" },
                    { "7.6.1", 1, "7.6", 22, "Available" },
                    { "7.6.2", 2, "7.6", 50, "Available" },
                    { "7.6.3", 3, "7.6", 50, "Available" },
                    { "7.7.1", 1, "7.7", 7, "Available" },
                    { "7.7.2", 2, "7.7", 50, "Available" },
                    { "7.7.3", 3, "7.7", 50, "Available" },
                    { "7.8.1", 1, "7.8", 11, "Available" },
                    { "7.8.2", 2, "7.8", 50, "Available" },
                    { "7.8.3", 3, "7.8", 50, "Available" },
                    { "7.9.1", 1, "7.9", 22, "Available" },
                    { "7.9.2", 2, "7.9", 50, "Available" },
                    { "7.9.3", 3, "7.9", 50, "Available" }
                });

            migrationBuilder.InsertData(
                table: "VehicleConnectorTypes",
                columns: new[] { "ConnectorId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "VehiclePerMonths",
                columns: new[] { "VehicleMonthId", "AmountPaid", "PeriodId", "TotalCost", "TotalEnergy", "TotalSessions", "VehicleId" },
                values: new object[,]
                {
                    { 1, 619623f, 19, 619623f, 160.6f, 4, 1 },
                    { 2, 498068f, 19, 498068f, 129.1f, 3, 2 },
                    { 3, 231866f, 19, 231866f, 60.1f, 2, 3 },
                    { 4, 637921f, 19, 637921f, 165.4f, 4, 4 },
                    { 5, 519563f, 19, 519563f, 134.6f, 3, 5 },
                    { 6, 454045f, 19, 454045f, 117.7f, 3, 6 },
                    { 7, 248033f, 19, 248033f, 64.3f, 2, 7 },
                    { 8, 285918f, 19, 285918f, 74.1f, 2, 8 },
                    { 9, 506409f, 19, 506409f, 131.2f, 4, 9 },
                    { 10, 441017f, 19, 441017f, 114.3f, 3, 10 },
                    { 11, 267710f, 19, 267710f, 69.4f, 2, 11 },
                    { 12, 678314f, 19, 678314f, 175.8f, 4, 12 },
                    { 13, 321150f, 19, 321150f, 83.2f, 2, 13 },
                    { 14, 441017f, 20, 441017f, 114.3f, 3, 1 },
                    { 15, 498839f, 20, 498839f, 129.3f, 3, 2 },
                    { 16, 0f, 20, 500383f, 129.7f, 4, 3 },
                    { 17, 321536f, 20, 321536f, 83.3f, 2, 4 },
                    { 18, 701468f, 20, 701468f, 181.8f, 4, 5 },
                    { 19, 538787f, 20, 538787f, 139.6f, 3, 6 },
                    { 20, 504626f, 20, 504626f, 130.8f, 4, 7 },
                    { 21, 527581f, 20, 527581f, 136.7f, 3, 8 },
                    { 22, 310931f, 20, 310931f, 80.6f, 2, 9 },
                    { 23, 293644f, 20, 293644f, 76.1f, 2, 10 },
                    { 24, 421449f, 20, 421449f, 109.2f, 3, 11 },
                    { 25, 333657f, 20, 333657f, 86.5f, 2, 12 },
                    { 26, 662990f, 20, 662990f, 171.8f, 4, 13 },
                    { 27, 299085f, 21, 299085f, 77.5f, 2, 1 },
                    { 28, 669483f, 21, 669483f, 173.5f, 4, 2 },
                    { 29, 0f, 21, 0f, 0f, 0, 3 },
                    { 30, 319128f, 21, 319128f, 82.7f, 2, 4 },
                    { 31, 517272f, 21, 517272f, 134f, 3, 5 },
                    { 32, 451730f, 21, 451730f, 117.1f, 3, 6 },
                    { 33, 530860f, 21, 530860f, 137.6f, 4, 7 },
                    { 34, 0f, 21, 527581f, 136.7f, 3, 8 },
                    { 35, 361097f, 21, 361097f, 93.6f, 3, 9 },
                    { 36, 289876f, 21, 289876f, 75.1f, 2, 10 },
                    { 37, 0f, 21, 269228f, 69.8f, 2, 11 },
                    { 38, 675276f, 21, 675276f, 175f, 4, 12 },
                    { 39, 319514f, 21, 319514f, 82.8f, 2, 13 },
                    { 40, 449275f, 22, 449275f, 116.4f, 3, 1 },
                    { 41, 347220f, 22, 347220f, 90f, 2, 2 },
                    { 42, 0f, 22, 0f, 0f, 0, 3 },
                    { 43, 632832f, 22, 632832f, 164.1f, 4, 4 },
                    { 44, 0f, 22, 519563f, 134.6f, 3, 5 },
                    { 45, 288975f, 22, 288975f, 74.9f, 2, 6 },
                    { 46, 381398f, 22, 381398f, 98.8f, 3, 7 },
                    { 47, 0f, 22, 0f, 0f, 0, 8 },
                    { 48, 361097f, 22, 361097f, 93.6f, 3, 9 },
                    { 49, 288397f, 22, 288397f, 74.7f, 2, 10 },
                    { 50, 0f, 22, 0f, 0f, 0, 11 },
                    { 51, 328336f, 22, 328336f, 85.1f, 2, 12 },
                    { 52, 482708f, 22, 482708f, 125.1f, 3, 13 },
                    { 53, 0f, 23, 157070f, 40.7f, 1, 1 },
                    { 54, 0f, 23, 180237f, 46.7f, 1, 2 },
                    { 55, 0f, 23, 0f, 0f, 0, 3 },
                    { 56, 0f, 23, 317971f, 82.4f, 2, 4 },
                    { 57, 0f, 23, 0f, 0f, 0, 5 },
                    { 58, 0f, 23, 138888f, 36f, 1, 6 },
                    { 59, 0f, 23, 243880f, 63.2f, 2, 7 },
                    { 60, 0f, 23, 0f, 0f, 0, 8 },
                    { 61, 0f, 23, 109247f, 28.3f, 1, 9 },
                    { 62, 0f, 23, 152431f, 39.5f, 1, 10 },
                    { 63, 0f, 23, 0f, 0f, 0, 11 },
                    { 64, 0f, 23, 158178f, 41f, 1, 12 },
                    { 65, 0f, 23, 165445f, 42.9f, 1, 13 }
                });

            migrationBuilder.InsertData(
                table: "VehiclePorts",
                columns: new[] { "ConnectorId", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "ChargingSessions",
                columns: new[] { "Id", "EndTime", "EnergyConsumed", "PortId", "StartTime", "Status", "TotalCost", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 41.2f, "1.1.1", new DateTime(2025, 7, 3, 8, 15, 0, 0, DateTimeKind.Unspecified), 1, 158949f, 1 },
                    { 2, new DateTime(2025, 7, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 36.8f, "2.2.1", new DateTime(2025, 7, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 141974f, 1 },
                    { 3, new DateTime(2025, 7, 15, 11, 15, 0, 0, DateTimeKind.Unspecified), 39.5f, "3.3.1", new DateTime(2025, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 152391f, 1 },
                    { 4, new DateTime(2025, 7, 22, 18, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.1", new DateTime(2025, 7, 22, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 166279f, 1 },
                    { 5, new DateTime(2025, 7, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 47.3f, "5.5.1", new DateTime(2025, 7, 5, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 182483f, 2 },
                    { 6, new DateTime(2025, 7, 12, 18, 25, 0, 0, DateTimeKind.Unspecified), 43.7f, "6.6.1", new DateTime(2025, 7, 12, 16, 10, 0, 0, DateTimeKind.Unspecified), 1, 168594f, 2 },
                    { 7, new DateTime(2025, 7, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), 38.1f, "7.7.1", new DateTime(2025, 7, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 146989f, 2 },
                    { 8, new DateTime(2025, 7, 4, 15, 45, 0, 0, DateTimeKind.Unspecified), 31.2f, "1.2.3", new DateTime(2025, 7, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 120369f, 3 },
                    { 9, new DateTime(2025, 7, 11, 11, 50, 0, 0, DateTimeKind.Unspecified), 28.9f, "2.3.1", new DateTime(2025, 7, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 111496f, 3 },
                    { 10, new DateTime(2025, 7, 6, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.6f, "3.4.1", new DateTime(2025, 7, 6, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 156634f, 4 },
                    { 11, new DateTime(2025, 7, 14, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.3f, "4.5.1", new DateTime(2025, 7, 14, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 163193f, 4 },
                    { 12, new DateTime(2025, 7, 20, 10, 45, 0, 0, DateTimeKind.Unspecified), 37.8f, "5.6.1", new DateTime(2025, 7, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 145832f, 4 },
                    { 13, new DateTime(2025, 7, 26, 16, 30, 0, 0, DateTimeKind.Unspecified), 44.7f, "6.7.1", new DateTime(2025, 7, 26, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, 172452f, 4 },
                    { 14, new DateTime(2025, 7, 7, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.1f, "7.8.1", new DateTime(2025, 7, 7, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 173995f, 5 },
                    { 15, new DateTime(2025, 7, 16, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.7f, "1.3.2", new DateTime(2025, 7, 16, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 160878f, 5 },
                    { 16, new DateTime(2025, 7, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 47.8f, "2.4.2", new DateTime(2025, 7, 23, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 184412f, 5 },
                    { 17, new DateTime(2025, 7, 2, 12, 15, 0, 0, DateTimeKind.Unspecified), 36.5f, "3.5.2", new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 140817f, 6 },
                    { 18, new DateTime(2025, 7, 17, 15, 45, 0, 0, DateTimeKind.Unspecified), 39.2f, "4.6.2", new DateTime(2025, 7, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 151233f, 6 },
                    { 19, new DateTime(2025, 7, 29, 16, 45, 0, 0, DateTimeKind.Unspecified), 42f, "5.7.2", new DateTime(2025, 7, 29, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 162036f, 6 },
                    { 20, new DateTime(2025, 7, 9, 11, 15, 0, 0, DateTimeKind.Unspecified), 30.8f, "6.8.2", new DateTime(2025, 7, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 118826f, 7 },
                    { 21, new DateTime(2025, 7, 21, 14, 45, 0, 0, DateTimeKind.Unspecified), 33.5f, "7.9.2", new DateTime(2025, 7, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 129243f, 7 },
                    { 22, new DateTime(2025, 7, 1, 17, 15, 0, 0, DateTimeKind.Unspecified), 35.7f, "1.4.1", new DateTime(2025, 7, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 137730f, 8 },
                    { 23, new DateTime(2025, 7, 25, 12, 45, 0, 0, DateTimeKind.Unspecified), 38.4f, "2.5.1", new DateTime(2025, 7, 25, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 148147f, 8 },
                    { 24, new DateTime(2025, 7, 4, 13, 15, 0, 0, DateTimeKind.Unspecified), 28.6f, "3.6.1", new DateTime(2025, 7, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 110338f, 9 },
                    { 25, new DateTime(2025, 7, 14, 16, 45, 0, 0, DateTimeKind.Unspecified), 31.4f, "4.7.1", new DateTime(2025, 7, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 121141f, 9 },
                    { 26, new DateTime(2025, 7, 20, 12, 15, 0, 0, DateTimeKind.Unspecified), 34.2f, "5.8.1", new DateTime(2025, 7, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 131943f, 9 },
                    { 27, new DateTime(2025, 7, 27, 17, 45, 0, 0, DateTimeKind.Unspecified), 37f, "6.9.1", new DateTime(2025, 7, 27, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 142746f, 9 },
                    { 28, new DateTime(2025, 7, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), 40f, "7.10.1", new DateTime(2025, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 154320f, 10 },
                    { 29, new DateTime(2025, 7, 13, 10, 45, 0, 0, DateTimeKind.Unspecified), 35.5f, "1.5.1", new DateTime(2025, 7, 13, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 136959f, 10 },
                    { 30, new DateTime(2025, 7, 22, 18, 15, 0, 0, DateTimeKind.Unspecified), 38.8f, "2.6.1", new DateTime(2025, 7, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 149690f, 10 },
                    { 31, new DateTime(2025, 7, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), 33.3f, "3.7.1", new DateTime(2025, 7, 10, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, 128471f, 11 },
                    { 32, new DateTime(2025, 7, 28, 15, 45, 0, 0, DateTimeKind.Unspecified), 36.1f, "4.8.1", new DateTime(2025, 7, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 139273f, 11 },
                    { 33, new DateTime(2025, 7, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 41.5f, "5.9.1", new DateTime(2025, 7, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 160107f, 12 },
                    { 34, new DateTime(2025, 7, 15, 16, 35, 0, 0, DateTimeKind.Unspecified), 44.4f, "6.10.1", new DateTime(2025, 7, 15, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 171295f, 12 },
                    { 35, new DateTime(2025, 7, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), 47.1f, "7.1.1", new DateTime(2025, 7, 21, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 181711f, 12 },
                    { 36, new DateTime(2025, 7, 30, 19, 15, 0, 0, DateTimeKind.Unspecified), 42.8f, "1.6.1", new DateTime(2025, 7, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 165122f, 12 },
                    { 37, new DateTime(2025, 7, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 40.2f, "2.7.1", new DateTime(2025, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 155091f, 13 },
                    { 38, new DateTime(2025, 7, 24, 15, 15, 0, 0, DateTimeKind.Unspecified), 43f, "3.8.1", new DateTime(2025, 7, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 165894f, 13 },
                    { 39, new DateTime(2025, 8, 5, 12, 15, 0, 0, DateTimeKind.Unspecified), 40f, "4.9.1", new DateTime(2025, 8, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 154320f, 1 },
                    { 40, new DateTime(2025, 8, 12, 17, 45, 0, 0, DateTimeKind.Unspecified), 35.5f, "5.10.1", new DateTime(2025, 8, 12, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 136959f, 1 },
                    { 41, new DateTime(2025, 8, 25, 13, 15, 0, 0, DateTimeKind.Unspecified), 38.8f, "6.1.1", new DateTime(2025, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 149690f, 1 },
                    { 42, new DateTime(2025, 8, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), 47.1f, "7.2.1", new DateTime(2025, 8, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 181711f, 2 },
                    { 43, new DateTime(2025, 8, 14, 18, 35, 0, 0, DateTimeKind.Unspecified), 43.9f, "1.7.1", new DateTime(2025, 8, 14, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 169366f, 2 },
                    { 44, new DateTime(2025, 8, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), 38.3f, "2.8.1", new DateTime(2025, 8, 20, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 147761f, 2 },
                    { 45, new DateTime(2025, 8, 2, 15, 45, 0, 0, DateTimeKind.Unspecified), 31.5f, "3.9.1", new DateTime(2025, 8, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 121527f, 3 },
                    { 46, new DateTime(2025, 8, 9, 11, 50, 0, 0, DateTimeKind.Unspecified), 29.1f, "4.10.1", new DateTime(2025, 8, 9, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 112267f, 3 },
                    { 47, new DateTime(2025, 8, 16, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.3f, "5.1.1", new DateTime(2025, 8, 16, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 128471f, 3 },
                    { 48, new DateTime(2025, 8, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 35.8f, "6.2.1", new DateTime(2025, 8, 29, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, 138116f, 3 },
                    { 49, new DateTime(2025, 8, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.8f, "7.3.1", new DateTime(2025, 8, 7, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 157406f, 4 },
                    { 50, new DateTime(2025, 8, 21, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.5f, "1.2.1", new DateTime(2025, 8, 21, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 163965f, 4 },
                    { 51, new DateTime(2025, 8, 8, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.4f, "2.3.2", new DateTime(2025, 8, 8, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 175153f, 5 },
                    { 52, new DateTime(2025, 8, 17, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.9f, "3.4.2", new DateTime(2025, 8, 17, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 161650f, 5 },
                    { 53, new DateTime(2025, 8, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), 48f, "4.5.2", new DateTime(2025, 8, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 185184f, 5 },
                    { 54, new DateTime(2025, 8, 30, 12, 15, 0, 0, DateTimeKind.Unspecified), 46.5f, "5.6.2", new DateTime(2025, 8, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 179397f, 5 },
                    { 55, new DateTime(2025, 8, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "6.7.2", new DateTime(2025, 8, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188656f, 6 },
                    { 56, new DateTime(2025, 8, 15, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "7.8.2", new DateTime(2025, 8, 15, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170523f, 6 },
                    { 57, new DateTime(2025, 8, 26, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.5f, "1.3.3", new DateTime(2025, 8, 26, 9, 20, 0, 0, DateTimeKind.Unspecified), 1, 179397f, 6 },
                    { 58, new DateTime(2025, 8, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 32.1f, "2.4.3", new DateTime(2025, 8, 6, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 123841f, 7 },
                    { 59, new DateTime(2025, 8, 13, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.7f, "3.5.3", new DateTime(2025, 8, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 114582f, 7 },
                    { 60, new DateTime(2025, 8, 22, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.4f, "4.6.3", new DateTime(2025, 8, 22, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 128857f, 7 },
                    { 61, new DateTime(2025, 8, 28, 11, 10, 0, 0, DateTimeKind.Unspecified), 35.6f, "5.7.3", new DateTime(2025, 8, 28, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 137344f, 7 },
                    { 62, new DateTime(2025, 8, 4, 15, 15, 0, 0, DateTimeKind.Unspecified), 49.5f, "6.8.3", new DateTime(2025, 8, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 190971f, 8 },
                    { 63, new DateTime(2025, 8, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.9f, "7.9.3", new DateTime(2025, 8, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 161650f, 8 },
                    { 64, new DateTime(2025, 8, 27, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.3f, "1.5.2", new DateTime(2025, 8, 27, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 174767f, 8 },
                    { 65, new DateTime(2025, 8, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.6f, "2.6.2", new DateTime(2025, 8, 10, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 160492f, 9 },
                    { 66, new DateTime(2025, 8, 24, 13, 30, 0, 0, DateTimeKind.Unspecified), 39f, "3.7.2", new DateTime(2025, 8, 24, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 150462f, 9 },
                    { 67, new DateTime(2025, 8, 8, 14, 15, 0, 0, DateTimeKind.Unspecified), 40.3f, "4.8.2", new DateTime(2025, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 155477f, 10 },
                    { 68, new DateTime(2025, 8, 19, 10, 45, 0, 0, DateTimeKind.Unspecified), 35.8f, "5.9.2", new DateTime(2025, 8, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 138116f, 10 },
                    { 69, new DateTime(2025, 8, 5, 13, 30, 0, 0, DateTimeKind.Unspecified), 33.6f, "6.10.2", new DateTime(2025, 8, 5, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, 129628f, 11 },
                    { 70, new DateTime(2025, 8, 11, 15, 45, 0, 0, DateTimeKind.Unspecified), 36.4f, "7.1.2", new DateTime(2025, 8, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 140431f, 11 },
                    { 71, new DateTime(2025, 8, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), 39.2f, "1.6.2", new DateTime(2025, 8, 28, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 151233f, 11 },
                    { 72, new DateTime(2025, 8, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), 41.8f, "2.7.2", new DateTime(2025, 8, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 161264f, 12 },
                    { 73, new DateTime(2025, 8, 23, 16, 35, 0, 0, DateTimeKind.Unspecified), 44.7f, "3.8.2", new DateTime(2025, 8, 23, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 172452f, 12 },
                    { 74, new DateTime(2025, 8, 3, 10, 15, 0, 0, DateTimeKind.Unspecified), 40.5f, "4.9.2", new DateTime(2025, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 156249f, 13 },
                    { 75, new DateTime(2025, 8, 18, 15, 15, 0, 0, DateTimeKind.Unspecified), 43.3f, "5.10.2", new DateTime(2025, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 167051f, 13 },
                    { 76, new DateTime(2025, 8, 25, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.1f, "6.1.2", new DateTime(2025, 8, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 177853f, 13 },
                    { 77, new DateTime(2025, 8, 31, 18, 35, 0, 0, DateTimeKind.Unspecified), 41.9f, "7.2.2", new DateTime(2025, 8, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 161650f, 13 },
                    { 78, new DateTime(2025, 9, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 41f, "1.1.1", new DateTime(2025, 9, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 158178f, 1 },
                    { 79, new DateTime(2025, 9, 17, 16, 20, 0, 0, DateTimeKind.Unspecified), 36.5f, "2.2.1", new DateTime(2025, 9, 17, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 140817f, 1 },
                    { 80, new DateTime(2025, 9, 4, 13, 45, 0, 0, DateTimeKind.Unspecified), 47f, "3.3.1", new DateTime(2025, 9, 4, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 181326f, 2 },
                    { 81, new DateTime(2025, 9, 11, 18, 25, 0, 0, DateTimeKind.Unspecified), 43.5f, "4.4.1", new DateTime(2025, 9, 11, 16, 10, 0, 0, DateTimeKind.Unspecified), 1, 167823f, 2 },
                    { 82, new DateTime(2025, 9, 19, 9, 30, 0, 0, DateTimeKind.Unspecified), 38f, "5.5.1", new DateTime(2025, 9, 19, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 146604f, 2 },
                    { 83, new DateTime(2025, 9, 26, 17, 45, 0, 0, DateTimeKind.Unspecified), 45f, "6.6.1", new DateTime(2025, 9, 26, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 173610f, 2 },
                    { 84, new DateTime(2025, 9, 6, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.5f, "7.7.1", new DateTime(2025, 9, 6, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 156249f, 4 },
                    { 85, new DateTime(2025, 9, 24, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.2f, "1.2.1", new DateTime(2025, 9, 24, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 162807f, 4 },
                    { 86, new DateTime(2025, 9, 3, 17, 55, 0, 0, DateTimeKind.Unspecified), 45f, "2.3.1", new DateTime(2025, 9, 3, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 173610f, 5 },
                    { 87, new DateTime(2025, 9, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.5f, "3.4.1", new DateTime(2025, 9, 12, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 160107f, 5 },
                    { 88, new DateTime(2025, 9, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 47.5f, "4.5.1", new DateTime(2025, 9, 23, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 183255f, 5 },
                    { 89, new DateTime(2025, 9, 5, 12, 15, 0, 0, DateTimeKind.Unspecified), 36.3f, "5.6.1", new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 140045f, 6 },
                    { 90, new DateTime(2025, 9, 18, 15, 45, 0, 0, DateTimeKind.Unspecified), 39f, "6.7.1", new DateTime(2025, 9, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 150462f, 6 },
                    { 91, new DateTime(2025, 9, 30, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.8f, "7.8.1", new DateTime(2025, 9, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 161264f, 6 },
                    { 92, new DateTime(2025, 9, 9, 11, 15, 0, 0, DateTimeKind.Unspecified), 30.6f, "1.3.1", new DateTime(2025, 9, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 118054f, 7 },
                    { 93, new DateTime(2025, 9, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), 33.3f, "2.4.1", new DateTime(2025, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 128471f, 7 },
                    { 94, new DateTime(2025, 9, 22, 17, 15, 0, 0, DateTimeKind.Unspecified), 35.5f, "3.5.1", new DateTime(2025, 9, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 136959f, 7 },
                    { 95, new DateTime(2025, 9, 28, 12, 45, 0, 0, DateTimeKind.Unspecified), 38.2f, "4.6.1", new DateTime(2025, 9, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 147375f, 7 },
                    { 96, new DateTime(2025, 9, 4, 15, 15, 0, 0, DateTimeKind.Unspecified), 49.5f, "5.7.1", new DateTime(2025, 9, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 190971f, 8 },
                    { 97, new DateTime(2025, 9, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.9f, "6.8.1", new DateTime(2025, 9, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 161650f, 8 },
                    { 98, new DateTime(2025, 9, 27, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.3f, "7.9.1", new DateTime(2025, 9, 27, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 174767f, 8 },
                    { 99, new DateTime(2025, 9, 5, 13, 15, 0, 0, DateTimeKind.Unspecified), 28.4f, "1.4.2", new DateTime(2025, 9, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 109567f, 9 },
                    { 100, new DateTime(2025, 9, 14, 16, 45, 0, 0, DateTimeKind.Unspecified), 31.2f, "2.5.2", new DateTime(2025, 9, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 120369f, 9 },
                    { 101, new DateTime(2025, 9, 27, 12, 15, 0, 0, DateTimeKind.Unspecified), 34f, "3.6.2", new DateTime(2025, 9, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 131172f, 9 },
                    { 102, new DateTime(2025, 9, 7, 14, 15, 0, 0, DateTimeKind.Unspecified), 39.8f, "4.7.2", new DateTime(2025, 9, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 153548f, 10 },
                    { 103, new DateTime(2025, 9, 20, 10, 45, 0, 0, DateTimeKind.Unspecified), 35.3f, "5.8.2", new DateTime(2025, 9, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 136187f, 10 },
                    { 104, new DateTime(2025, 9, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 33.5f, "6.9.2", new DateTime(2025, 9, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, 129243f, 11 },
                    { 105, new DateTime(2025, 9, 26, 15, 45, 0, 0, DateTimeKind.Unspecified), 36.3f, "7.10.2", new DateTime(2025, 9, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 140045f, 11 },
                    { 106, new DateTime(2025, 9, 8, 11, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "1.5.2", new DateTime(2025, 9, 8, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 159335f, 12 },
                    { 107, new DateTime(2025, 9, 16, 16, 35, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.6.2", new DateTime(2025, 9, 16, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 170523f, 12 },
                    { 108, new DateTime(2025, 9, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), 46.9f, "3.7.2", new DateTime(2025, 9, 23, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 180940f, 12 },
                    { 109, new DateTime(2025, 9, 29, 19, 15, 0, 0, DateTimeKind.Unspecified), 42.6f, "4.8.2", new DateTime(2025, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 164350f, 12 },
                    { 110, new DateTime(2025, 9, 7, 10, 15, 0, 0, DateTimeKind.Unspecified), 40f, "5.9.2", new DateTime(2025, 9, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 154320f, 13 },
                    { 111, new DateTime(2025, 9, 25, 15, 15, 0, 0, DateTimeKind.Unspecified), 42.8f, "6.10.2", new DateTime(2025, 9, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 165122f, 13 },
                    { 112, new DateTime(2025, 10, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.8f, "7.1.1", new DateTime(2025, 10, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 157406f, 1 },
                    { 113, new DateTime(2025, 10, 16, 16, 20, 0, 0, DateTimeKind.Unspecified), 36.3f, "1.2.1", new DateTime(2025, 10, 16, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 140045f, 1 },
                    { 114, new DateTime(2025, 10, 28, 11, 15, 0, 0, DateTimeKind.Unspecified), 39.3f, "2.3.1", new DateTime(2025, 10, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 151619f, 1 },
                    { 115, new DateTime(2025, 10, 3, 13, 45, 0, 0, DateTimeKind.Unspecified), 46.8f, "3.4.1", new DateTime(2025, 10, 3, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 180554f, 2 },
                    { 116, new DateTime(2025, 10, 20, 18, 25, 0, 0, DateTimeKind.Unspecified), 43.2f, "4.5.1", new DateTime(2025, 10, 20, 16, 10, 0, 0, DateTimeKind.Unspecified), 1, 166665f, 2 },
                    { 117, new DateTime(2025, 10, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.4f, "5.6.1", new DateTime(2025, 10, 5, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 155863f, 4 },
                    { 118, new DateTime(2025, 10, 14, 19, 10, 0, 0, DateTimeKind.Unspecified), 42f, "6.7.1", new DateTime(2025, 10, 14, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 162036f, 4 },
                    { 119, new DateTime(2025, 10, 22, 10, 45, 0, 0, DateTimeKind.Unspecified), 37.4f, "7.8.1", new DateTime(2025, 10, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 144289f, 4 },
                    { 120, new DateTime(2025, 10, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 44.3f, "1.3.1", new DateTime(2025, 10, 29, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, 170909f, 4 },
                    { 121, new DateTime(2025, 10, 7, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.1f, "2.4.1", new DateTime(2025, 10, 7, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 173995f, 5 },
                    { 122, new DateTime(2025, 10, 17, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.7f, "3.5.1", new DateTime(2025, 10, 17, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 160878f, 5 },
                    { 123, new DateTime(2025, 10, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 47.8f, "4.6.1", new DateTime(2025, 10, 27, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 184412f, 5 },
                    { 124, new DateTime(2025, 10, 4, 12, 15, 0, 0, DateTimeKind.Unspecified), 36.1f, "5.7.1", new DateTime(2025, 10, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 139273f, 6 },
                    { 125, new DateTime(2025, 10, 18, 15, 45, 0, 0, DateTimeKind.Unspecified), 38.8f, "6.8.1", new DateTime(2025, 10, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 149690f, 6 },
                    { 126, new DateTime(2025, 10, 9, 11, 15, 0, 0, DateTimeKind.Unspecified), 30.4f, "7.9.1", new DateTime(2025, 10, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 117283f, 7 },
                    { 127, new DateTime(2025, 10, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), 33.1f, "1.4.2", new DateTime(2025, 10, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 127699f, 7 },
                    { 128, new DateTime(2025, 10, 27, 17, 15, 0, 0, DateTimeKind.Unspecified), 35.3f, "2.5.2", new DateTime(2025, 10, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 136187f, 7 },
                    { 129, new DateTime(2025, 10, 5, 13, 15, 0, 0, DateTimeKind.Unspecified), 28.4f, "3.6.2", new DateTime(2025, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 109567f, 9 },
                    { 130, new DateTime(2025, 10, 14, 16, 45, 0, 0, DateTimeKind.Unspecified), 31.2f, "4.7.2", new DateTime(2025, 10, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 120369f, 9 },
                    { 131, new DateTime(2025, 10, 27, 12, 15, 0, 0, DateTimeKind.Unspecified), 34f, "5.8.2", new DateTime(2025, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 131172f, 9 },
                    { 132, new DateTime(2025, 10, 7, 14, 15, 0, 0, DateTimeKind.Unspecified), 39.6f, "6.9.2", new DateTime(2025, 10, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 152776f, 10 },
                    { 133, new DateTime(2025, 10, 21, 10, 45, 0, 0, DateTimeKind.Unspecified), 35.1f, "7.10.2", new DateTime(2025, 10, 21, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 135415f, 10 },
                    { 134, new DateTime(2025, 10, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 41.1f, "1.5.2", new DateTime(2025, 10, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 158563f, 12 },
                    { 135, new DateTime(2025, 10, 23, 16, 35, 0, 0, DateTimeKind.Unspecified), 44f, "2.6.2", new DateTime(2025, 10, 23, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 169752f, 12 },
                    { 136, new DateTime(2025, 10, 10, 10, 15, 0, 0, DateTimeKind.Unspecified), 40.3f, "3.7.2", new DateTime(2025, 10, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 155477f, 13 },
                    { 137, new DateTime(2025, 10, 19, 15, 15, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.8.2", new DateTime(2025, 10, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 166279f, 13 },
                    { 138, new DateTime(2025, 10, 31, 18, 35, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.9.2", new DateTime(2025, 10, 31, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 160878f, 13 },
                    { 139, new DateTime(2025, 11, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.7f, "6.10.2", new DateTime(2025, 11, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 157020f, 1 },
                    { 140, new DateTime(2025, 11, 3, 13, 45, 0, 0, DateTimeKind.Unspecified), 46.7f, "7.1.2", new DateTime(2025, 11, 3, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 180168f, 2 },
                    { 141, new DateTime(2025, 11, 4, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.3f, "1.4.1", new DateTime(2025, 11, 4, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 155477f, 4 },
                    { 142, new DateTime(2025, 11, 7, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.1f, "2.5.1", new DateTime(2025, 11, 7, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 162421f, 4 },
                    { 143, new DateTime(2025, 11, 5, 12, 15, 0, 0, DateTimeKind.Unspecified), 36f, "4.7.1", new DateTime(2025, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 138888f, 6 },
                    { 144, new DateTime(2025, 11, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), 30.3f, "5.8.1", new DateTime(2025, 11, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 116897f, 7 },
                    { 145, new DateTime(2025, 11, 9, 14, 45, 0, 0, DateTimeKind.Unspecified), 32.9f, "6.9.1", new DateTime(2025, 11, 9, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 126928f, 7 },
                    { 146, new DateTime(2025, 11, 4, 13, 15, 0, 0, DateTimeKind.Unspecified), 28.3f, "7.10.1", new DateTime(2025, 11, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 109181f, 9 },
                    { 147, new DateTime(2025, 11, 5, 14, 15, 0, 0, DateTimeKind.Unspecified), 39.5f, "1.5.1", new DateTime(2025, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 152391f, 10 },
                    { 148, new DateTime(2025, 11, 6, 11, 45, 0, 0, DateTimeKind.Unspecified), 41f, "2.6.1", new DateTime(2025, 11, 6, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 158178f, 12 },
                    { 149, new DateTime(2025, 11, 9, 15, 15, 0, 0, DateTimeKind.Unspecified), 42.9f, "3.7.1", new DateTime(2025, 11, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 165508f, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPoints_StationId",
                table: "ChargingPoints",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPorts_ConnectorId",
                table: "ChargingPorts",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPorts_PointId",
                table: "ChargingPorts",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_PortId",
                table: "ChargingSessions",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_VehicleId",
                table: "ChargingSessions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleConnectorTypes_ConnectorId",
                table: "VehicleConnectorTypes",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_PeriodId",
                table: "VehiclePerMonths",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_VehicleId",
                table: "VehiclePerMonths",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePorts_ConnectorId",
                table: "VehiclePorts",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingSessions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "PowerRanges");

            migrationBuilder.DropTable(
                name: "PriceTables");

            migrationBuilder.DropTable(
                name: "TimeRanges");

            migrationBuilder.DropTable(
                name: "VehicleConnectorTypes");

            migrationBuilder.DropTable(
                name: "VehiclePerMonths");

            migrationBuilder.DropTable(
                name: "VehiclePorts");

            migrationBuilder.DropTable(
                name: "ChargingPorts");

            migrationBuilder.DropTable(
                name: "MonthlyPeriods");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ChargingPoints");

            migrationBuilder.DropTable(
                name: "Connectors");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "ChargingStations");
        }
    }
}
