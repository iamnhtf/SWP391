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
                    { "C001", "Quận 1, TP.HCM", "thinh.nguyen@example.com", "Nguyễn Xuân Thịnh", "0901234567" },
                    { "C002", "Quận 3, TP.HCM", "thai.nguyen@example.com", "Nguyễn Hưng Thái", "0912345678" },
                    { "C003", "Quận 7, TP.HCM", "khoi.nguyen@example.com", "Nguyễn Bùi Đăng Khôi", "0923456789" },
                    { "C004", "Quận Bình Thạnh, TP.HCM", "duc.le@example.com", "Lê Minh Đức", "0934567890" },
                    { "C005", "Quận 10, TP.HCM", "theanh.vu@example.com", "Vũ Thế Anh", "0945678901" },
                    { "C006", "Quận Tân Bình, TP.HCM", "vhung.tran@example.com", "Trần Văn Hùng", "0951122334" },
                    { "C007", "Quận 5, TP.HCM", "lan.pham@example.com", "Phạm Thị Lan", "0962233445" },
                    { "C008", "Quận 2, TP.HCM", "tuan.hoang@example.com", "Hoàng Anh Tuấn", "0973344556" },
                    { "C009", "Quận 4, TP.HCM", "mqun.do@example.com", "Đỗ Minh Quân", "0984455667" },
                    { "C010", "Quận Phú Nhuận, TP.HCM", "hoa.le@example.com", "Lê Thị Hòa", "0905566778" },
                    { "k825tKKC1aex70inOKxd2lQpJUD3", "Quận 1, TP.HCM", "nguyenxuanthinh@gmail.com", "Nguyen Xuan Thinh", "0901234567" }
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
                    { 1, 75, "k825tKKC1aex70inOKxd2lQpJUD3", "51B-67890", "Tesla Model 3", "Active", 2 },
                    { 2, 82, "k825tKKC1aex70inOKxd2lQpJUD3", "30A-12345", "VinFast VF 8", "Active", 2 },
                    { 3, 40, "k825tKKC1aex70inOKxd2lQpJUD3", "29C-56789", "Nissan Leaf", "Blocked", 2 },
                    { 4, 77, "k825tKKC1aex70inOKxd2lQpJUD3", "88D-45678", "Hyundai Ioniq 5", "Active", 2 },
                    { 5, 74, "k825tKKC1aex70inOKxd2lQpJUD3", "77E-99999", "Kia EV6", "Blocked", 2 }
                });

            migrationBuilder.InsertData(
                table: "ChargingPorts",
                columns: new[] { "Id", "ConnectorId", "PointId", "Power", "Status" },
                values: new object[,]
                {
                    { "1.1.1", 1, "1.1", 7, "Available" },
                    { "1.1.2", 2, "1.1", 22, "InUse" },
                    { "1.1.3", 3, "1.1", 50, "Available" },
                    { "1.2.1", 1, "1.2", 7, "Available" },
                    { "1.2.2", 2, "1.2", 22, "Faulty" },
                    { "1.2.3", 3, "1.2", 150, "InUse" },
                    { "1.3.1", 1, "1.3", 7, "InUse" },
                    { "1.3.2", 2, "1.3", 22, "Available" },
                    { "1.3.3", 3, "1.3", 50, "Available" },
                    { "1.4.1", 1, "1.4", 7, "Available" },
                    { "1.4.2", 2, "1.4", 22, "Available" },
                    { "1.4.3", 3, "1.4", 150, "Faulty" },
                    { "1.5.1", 1, "1.5", 7, "Available" },
                    { "1.5.2", 2, "1.5", 22, "InUse" },
                    { "1.5.3", 3, "1.5", 50, "Available" },
                    { "1.6.1", 1, "1.6", 7, "InUse" },
                    { "1.6.2", 2, "1.6", 22, "Available" },
                    { "1.6.3", 3, "1.6", 150, "Available" },
                    { "1.7.1", 1, "1.7", 7, "Available" },
                    { "1.7.2", 2, "1.7", 22, "Faulty" },
                    { "1.7.3", 3, "1.7", 50, "InUse" },
                    { "2.1.1", 1, "2.1", 7, "Available" },
                    { "2.1.2", 2, "2.1", 22, "InUse" },
                    { "2.1.3", 3, "2.1", 50, "Faulty" },
                    { "2.10.1", 1, "2.10", 7, "Available" },
                    { "2.10.2", 2, "2.10", 50, "InUse" },
                    { "2.10.3", 3, "2.10", 22, "Faulty" },
                    { "2.2.1", 1, "2.2", 22, "Available" },
                    { "2.2.2", 2, "2.2", 150, "InUse" },
                    { "2.2.3", 3, "2.2", 7, "Faulty" },
                    { "2.3.1", 1, "2.3", 50, "Available" },
                    { "2.3.2", 2, "2.3", 22, "InUse" },
                    { "2.3.3", 3, "2.3", 7, "Faulty" },
                    { "2.4.1", 1, "2.4", 150, "Available" },
                    { "2.4.2", 2, "2.4", 7, "InUse" },
                    { "2.4.3", 3, "2.4", 22, "Faulty" },
                    { "2.5.1", 1, "2.5", 22, "Available" },
                    { "2.5.2", 2, "2.5", 50, "InUse" },
                    { "2.5.3", 3, "2.5", 150, "Faulty" },
                    { "2.6.1", 1, "2.6", 7, "Available" },
                    { "2.6.2", 2, "2.6", 150, "InUse" },
                    { "2.6.3", 3, "2.6", 22, "Faulty" },
                    { "2.7.1", 1, "2.7", 22, "Available" },
                    { "2.7.2", 2, "2.7", 7, "InUse" },
                    { "2.7.3", 3, "2.7", 50, "Faulty" },
                    { "2.8.1", 1, "2.8", 50, "Available" },
                    { "2.8.2", 2, "2.8", 22, "InUse" },
                    { "2.8.3", 3, "2.8", 7, "Faulty" },
                    { "2.9.1", 1, "2.9", 150, "Available" },
                    { "2.9.2", 2, "2.9", 22, "InUse" },
                    { "2.9.3", 3, "2.9", 7, "Faulty" },
                    { "3.1.1", 1, "3.1", 7, "Available" },
                    { "3.1.2", 2, "3.1", 22, "InUse" },
                    { "3.1.3", 3, "3.1", 50, "Faulty" },
                    { "3.10.1", 1, "3.10", 7, "Available" },
                    { "3.10.2", 2, "3.10", 50, "InUse" },
                    { "3.10.3", 3, "3.10", 22, "Faulty" },
                    { "3.2.1", 1, "3.2", 22, "Available" },
                    { "3.2.2", 2, "3.2", 150, "InUse" },
                    { "3.2.3", 3, "3.2", 7, "Faulty" },
                    { "3.3.1", 1, "3.3", 50, "Available" },
                    { "3.3.2", 2, "3.3", 22, "InUse" },
                    { "3.3.3", 3, "3.3", 7, "Faulty" },
                    { "3.4.1", 1, "3.4", 150, "Available" },
                    { "3.4.2", 2, "3.4", 7, "InUse" },
                    { "3.4.3", 3, "3.4", 22, "Faulty" },
                    { "3.5.1", 1, "3.5", 22, "Available" },
                    { "3.5.2", 2, "3.5", 50, "InUse" },
                    { "3.5.3", 3, "3.5", 150, "Faulty" },
                    { "3.6.1", 1, "3.6", 7, "Available" },
                    { "3.6.2", 2, "3.6", 150, "InUse" },
                    { "3.6.3", 3, "3.6", 22, "Faulty" },
                    { "3.7.1", 1, "3.7", 22, "Available" },
                    { "3.7.2", 2, "3.7", 7, "InUse" },
                    { "3.7.3", 3, "3.7", 50, "Faulty" },
                    { "3.8.1", 1, "3.8", 50, "Available" },
                    { "3.8.2", 2, "3.8", 22, "InUse" },
                    { "3.8.3", 3, "3.8", 7, "Faulty" },
                    { "3.9.1", 1, "3.9", 150, "Available" },
                    { "3.9.2", 2, "3.9", 22, "InUse" },
                    { "3.9.3", 3, "3.9", 7, "Faulty" },
                    { "4.1.1", 1, "4.1", 22, "Available" },
                    { "4.1.2", 2, "4.1", 50, "InUse" },
                    { "4.1.3", 3, "4.1", 7, "Faulty" },
                    { "4.10.1", 1, "4.10", 7, "Available" },
                    { "4.10.2", 2, "4.10", 22, "InUse" },
                    { "4.10.3", 3, "4.10", 150, "Faulty" },
                    { "4.2.1", 1, "4.2", 150, "Available" },
                    { "4.2.2", 2, "4.2", 22, "InUse" },
                    { "4.2.3", 3, "4.2", 7, "Faulty" },
                    { "4.3.1", 1, "4.3", 7, "Available" },
                    { "4.3.2", 2, "4.3", 22, "InUse" },
                    { "4.3.3", 3, "4.3", 50, "Faulty" },
                    { "4.4.1", 1, "4.4", 22, "Available" },
                    { "4.4.2", 2, "4.4", 150, "InUse" },
                    { "4.4.3", 3, "4.4", 7, "Faulty" },
                    { "4.5.1", 1, "4.5", 50, "Available" },
                    { "4.5.2", 2, "4.5", 22, "InUse" },
                    { "4.5.3", 3, "4.5", 150, "Faulty" },
                    { "4.6.1", 1, "4.6", 7, "Available" },
                    { "4.6.2", 2, "4.6", 50, "InUse" },
                    { "4.6.3", 3, "4.6", 22, "Faulty" },
                    { "4.7.1", 1, "4.7", 150, "Available" },
                    { "4.7.2", 2, "4.7", 22, "InUse" },
                    { "4.7.3", 3, "4.7", 7, "Faulty" },
                    { "4.8.1", 1, "4.8", 22, "Available" },
                    { "4.8.2", 2, "4.8", 7, "InUse" },
                    { "4.8.3", 3, "4.8", 50, "Faulty" },
                    { "4.9.1", 1, "4.9", 50, "Available" },
                    { "4.9.2", 2, "4.9", 150, "InUse" },
                    { "4.9.3", 3, "4.9", 22, "Faulty" },
                    { "5.1.1", 1, "5.1", 7, "Available" },
                    { "5.1.2", 2, "5.1", 22, "InUse" },
                    { "5.1.3", 3, "5.1", 50, "Faulty" },
                    { "5.10.1", 1, "5.10", 150, "Available" },
                    { "5.10.2", 2, "5.10", 22, "InUse" },
                    { "5.10.3", 3, "5.10", 7, "Faulty" },
                    { "5.2.1", 1, "5.2", 150, "Available" },
                    { "5.2.2", 2, "5.2", 7, "InUse" },
                    { "5.2.3", 3, "5.2", 22, "Faulty" },
                    { "5.3.1", 1, "5.3", 22, "Available" },
                    { "5.3.2", 2, "5.3", 50, "InUse" },
                    { "5.3.3", 3, "5.3", 7, "Faulty" },
                    { "5.4.1", 1, "5.4", 7, "Available" },
                    { "5.4.2", 2, "5.4", 150, "InUse" },
                    { "5.4.3", 3, "5.4", 22, "Faulty" },
                    { "5.5.1", 1, "5.5", 22, "Available" },
                    { "5.5.2", 2, "5.5", 7, "InUse" },
                    { "5.5.3", 3, "5.5", 150, "Faulty" },
                    { "5.6.1", 1, "5.6", 50, "Available" },
                    { "5.6.2", 2, "5.6", 22, "InUse" },
                    { "5.6.3", 3, "5.6", 7, "Faulty" },
                    { "5.7.1", 1, "5.7", 150, "Available" },
                    { "5.7.2", 2, "5.7", 22, "InUse" },
                    { "5.7.3", 3, "5.7", 50, "Faulty" },
                    { "5.8.1", 1, "5.8", 7, "Available" },
                    { "5.8.2", 2, "5.8", 50, "InUse" },
                    { "5.8.3", 3, "5.8", 150, "Faulty" },
                    { "5.9.1", 1, "5.9", 22, "Available" },
                    { "5.9.2", 2, "5.9", 7, "InUse" },
                    { "5.9.3", 3, "5.9", 50, "Faulty" },
                    { "6.1.1", 1, "6.1", 7, "Available" },
                    { "6.1.2", 2, "6.1", 22, "InUse" },
                    { "6.1.3", 3, "6.1", 50, "Faulty" },
                    { "6.10.1", 1, "6.10", 150, "Available" },
                    { "6.10.2", 2, "6.10", 22, "InUse" },
                    { "6.10.3", 3, "6.10", 7, "Faulty" },
                    { "6.2.1", 1, "6.2", 150, "Available" },
                    { "6.2.2", 2, "6.2", 7, "InUse" },
                    { "6.2.3", 3, "6.2", 22, "Faulty" },
                    { "6.3.1", 1, "6.3", 22, "Available" },
                    { "6.3.2", 2, "6.3", 50, "InUse" },
                    { "6.3.3", 3, "6.3", 7, "Faulty" },
                    { "6.4.1", 1, "6.4", 7, "Available" },
                    { "6.4.2", 2, "6.4", 150, "InUse" },
                    { "6.4.3", 3, "6.4", 22, "Faulty" },
                    { "6.5.1", 1, "6.5", 22, "Available" },
                    { "6.5.2", 2, "6.5", 7, "InUse" },
                    { "6.5.3", 3, "6.5", 150, "Faulty" },
                    { "6.6.1", 1, "6.6", 50, "Available" },
                    { "6.6.2", 2, "6.6", 22, "InUse" },
                    { "6.6.3", 3, "6.6", 7, "Faulty" },
                    { "6.7.1", 1, "6.7", 150, "Available" },
                    { "6.7.2", 2, "6.7", 22, "InUse" },
                    { "6.7.3", 3, "6.7", 50, "Faulty" },
                    { "6.8.1", 1, "6.8", 7, "Available" },
                    { "6.8.2", 2, "6.8", 50, "InUse" },
                    { "6.8.3", 3, "6.8", 150, "Faulty" },
                    { "6.9.1", 1, "6.9", 22, "Available" },
                    { "6.9.2", 2, "6.9", 7, "InUse" },
                    { "6.9.3", 3, "6.9", 50, "Faulty" },
                    { "7.1.1", 1, "7.1", 22, "Available" },
                    { "7.1.2", 2, "7.1", 7, "InUse" },
                    { "7.1.3", 3, "7.1", 150, "Faulty" },
                    { "7.10.1", 1, "7.10", 50, "Available" },
                    { "7.10.2", 2, "7.10", 150, "InUse" },
                    { "7.10.3", 3, "7.10", 22, "Faulty" },
                    { "7.2.1", 1, "7.2", 50, "Available" },
                    { "7.2.2", 2, "7.2", 22, "InUse" },
                    { "7.2.3", 3, "7.2", 7, "Faulty" },
                    { "7.3.1", 1, "7.3", 7, "Available" },
                    { "7.3.2", 2, "7.3", 150, "InUse" },
                    { "7.3.3", 3, "7.3", 22, "Faulty" },
                    { "7.4.1", 1, "7.4", 22, "Available" },
                    { "7.4.2", 2, "7.4", 50, "InUse" },
                    { "7.4.3", 3, "7.4", 7, "Faulty" },
                    { "7.5.1", 1, "7.5", 150, "Available" },
                    { "7.5.2", 2, "7.5", 22, "InUse" },
                    { "7.5.3", 3, "7.5", 50, "Faulty" },
                    { "7.6.1", 1, "7.6", 7, "Available" },
                    { "7.6.2", 2, "7.6", 150, "InUse" },
                    { "7.6.3", 3, "7.6", 22, "Faulty" },
                    { "7.7.1", 1, "7.7", 50, "Available" },
                    { "7.7.2", 2, "7.7", 7, "InUse" },
                    { "7.7.3", 3, "7.7", 150, "Faulty" },
                    { "7.8.1", 1, "7.8", 22, "Available" },
                    { "7.8.2", 2, "7.8", 50, "InUse" },
                    { "7.8.3", 3, "7.8", 7, "Faulty" },
                    { "7.9.1", 1, "7.9", 150, "Available" },
                    { "7.9.2", 2, "7.9", 22, "InUse" },
                    { "7.9.3", 3, "7.9", 7, "Faulty" }
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
                    { 1, 780000f, 19, 780000f, 202.3f, 5, 1 },
                    { 2, 671000f, 19, 671000f, 174.3f, 4, 2 },
                    { 3, 358000f, 19, 358000f, 93.2f, 3, 3 },
                    { 4, 637000f, 19, 637000f, 165.4f, 4, 4 },
                    { 5, 519000f, 19, 519000f, 134.6f, 3, 5 },
                    { 6, 777000f, 20, 777000f, 201.5f, 5, 1 },
                    { 7, 702000f, 20, 702000f, 182.4f, 4, 2 },
                    { 8, 362000f, 20, 362000f, 94.3f, 3, 3 },
                    { 9, 645000f, 20, 645000f, 167.5f, 4, 4 },
                    { 10, 200000f, 20, 534000f, 138.4f, 3, 5 },
                    { 11, 777000f, 21, 777000f, 201.5f, 5, 1 },
                    { 12, 702000f, 21, 702000f, 182.4f, 4, 2 },
                    { 13, 0f, 21, 362000f, 94.3f, 3, 3 },
                    { 14, 645000f, 21, 645000f, 167.5f, 4, 4 },
                    { 16, 0f, 22, 450000f, 116.7f, 3, 1 },
                    { 17, 0f, 22, 358000f, 93.1f, 2, 2 },
                    { 18, 0f, 22, 331000f, 85.9f, 2, 4 }
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
                    { 1, new DateTime(2025, 7, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 41.2f, "1.1.1", new DateTime(2025, 7, 3, 8, 15, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 1 },
                    { 2, new DateTime(2025, 7, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 36.8f, "2.2.1", new DateTime(2025, 7, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 142000f, 1 },
                    { 3, new DateTime(2025, 7, 15, 11, 15, 0, 0, DateTimeKind.Unspecified), 39.5f, "3.3.1", new DateTime(2025, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 152000f, 1 },
                    { 4, new DateTime(2025, 7, 22, 18, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.1", new DateTime(2025, 7, 22, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 5, new DateTime(2025, 7, 28, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.1", new DateTime(2025, 7, 28, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 6, new DateTime(2025, 7, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 47.3f, "1.2.2", new DateTime(2025, 7, 5, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 182000f, 2 },
                    { 7, new DateTime(2025, 7, 12, 18, 25, 0, 0, DateTimeKind.Unspecified), 43.7f, "2.4.1", new DateTime(2025, 7, 12, 16, 10, 0, 0, DateTimeKind.Unspecified), 1, 168000f, 2 },
                    { 8, new DateTime(2025, 7, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), 38.1f, "3.5.1", new DateTime(2025, 7, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 147000f, 2 },
                    { 9, new DateTime(2025, 7, 25, 17, 45, 0, 0, DateTimeKind.Unspecified), 45.2f, "4.6.1", new DateTime(2025, 7, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 174000f, 2 },
                    { 10, new DateTime(2025, 7, 4, 15, 45, 0, 0, DateTimeKind.Unspecified), 31.2f, "1.3.1", new DateTime(2025, 7, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 120000f, 3 },
                    { 11, new DateTime(2025, 7, 11, 11, 50, 0, 0, DateTimeKind.Unspecified), 28.9f, "2.6.1", new DateTime(2025, 7, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 111000f, 3 },
                    { 12, new DateTime(2025, 7, 19, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.7.1", new DateTime(2025, 7, 19, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 13, new DateTime(2025, 7, 6, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.6f, "1.4.2", new DateTime(2025, 7, 6, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 156000f, 4 },
                    { 14, new DateTime(2025, 7, 14, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.3f, "2.7.1", new DateTime(2025, 7, 14, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 163000f, 4 },
                    { 15, new DateTime(2025, 7, 20, 10, 45, 0, 0, DateTimeKind.Unspecified), 37.8f, "3.8.1", new DateTime(2025, 7, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 146000f, 4 },
                    { 16, new DateTime(2025, 7, 26, 16, 30, 0, 0, DateTimeKind.Unspecified), 44.7f, "4.9.1", new DateTime(2025, 7, 26, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 17, new DateTime(2025, 7, 7, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.1f, "1.5.1", new DateTime(2025, 7, 7, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 174000f, 5 },
                    { 18, new DateTime(2025, 7, 16, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.7f, "2.8.1", new DateTime(2025, 7, 16, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 5 },
                    { 19, new DateTime(2025, 7, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 47.8f, "3.9.1", new DateTime(2025, 7, 23, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 184000f, 5 },
                    { 20, new DateTime(2025, 8, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.2", new DateTime(2025, 8, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 21, new DateTime(2025, 8, 9, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.2", new DateTime(2025, 8, 9, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 22, new DateTime(2025, 8, 16, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.2", new DateTime(2025, 8, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 23, new DateTime(2025, 8, 23, 19, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.2", new DateTime(2025, 8, 23, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 24, new DateTime(2025, 8, 30, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.2", new DateTime(2025, 8, 30, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 25, new DateTime(2025, 8, 4, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.3", new DateTime(2025, 8, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 26, new DateTime(2025, 8, 11, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.3", new DateTime(2025, 8, 11, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 27, new DateTime(2025, 8, 18, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.5f, "3.4.3", new DateTime(2025, 8, 18, 9, 20, 0, 0, DateTimeKind.Unspecified), 1, 179000f, 2 },
                    { 28, new DateTime(2025, 8, 25, 17, 40, 0, 0, DateTimeKind.Unspecified), 42.8f, "4.5.3", new DateTime(2025, 8, 25, 15, 15, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 2 },
                    { 29, new DateTime(2025, 8, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.2", new DateTime(2025, 8, 6, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 30, new DateTime(2025, 8, 13, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.2", new DateTime(2025, 8, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 31, new DateTime(2025, 8, 20, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.5.2", new DateTime(2025, 8, 20, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 32, new DateTime(2025, 8, 3, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.1", new DateTime(2025, 8, 3, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 33, new DateTime(2025, 8, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.1", new DateTime(2025, 8, 10, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 },
                    { 34, new DateTime(2025, 8, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 38.7f, "3.6.1", new DateTime(2025, 8, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 149000f, 4 },
                    { 35, new DateTime(2025, 8, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 42.9f, "4.7.1", new DateTime(2025, 8, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 4 },
                    { 36, new DateTime(2025, 8, 5, 15, 15, 0, 0, DateTimeKind.Unspecified), 49.2f, "1.5.2", new DateTime(2025, 8, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 200000f, 5 },
                    { 37, new DateTime(2025, 9, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.3", new DateTime(2025, 9, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 38, new DateTime(2025, 9, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.1", new DateTime(2025, 9, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 39, new DateTime(2025, 9, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.3", new DateTime(2025, 9, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 40, new DateTime(2025, 9, 22, 19, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.3", new DateTime(2025, 9, 22, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 41, new DateTime(2025, 9, 29, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.3", new DateTime(2025, 9, 29, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 42, new DateTime(2025, 9, 4, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.1", new DateTime(2025, 9, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 43, new DateTime(2025, 9, 11, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.1", new DateTime(2025, 9, 11, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 44, new DateTime(2025, 9, 18, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.5f, "3.4.1", new DateTime(2025, 9, 18, 9, 20, 0, 0, DateTimeKind.Unspecified), 1, 179000f, 2 },
                    { 45, new DateTime(2025, 9, 25, 17, 40, 0, 0, DateTimeKind.Unspecified), 42.8f, "4.5.1", new DateTime(2025, 9, 25, 15, 15, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 2 },
                    { 46, new DateTime(2025, 9, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.3", new DateTime(2025, 9, 6, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 47, new DateTime(2025, 9, 13, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.3", new DateTime(2025, 9, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 48, new DateTime(2025, 9, 20, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.5.3", new DateTime(2025, 9, 20, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 49, new DateTime(2025, 9, 3, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.3", new DateTime(2025, 9, 3, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 50, new DateTime(2025, 9, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.2", new DateTime(2025, 9, 10, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 },
                    { 51, new DateTime(2025, 9, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 38.7f, "3.6.2", new DateTime(2025, 9, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 149000f, 4 },
                    { 52, new DateTime(2025, 9, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 42.9f, "4.7.2", new DateTime(2025, 9, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 4 },
                    { 53, new DateTime(2025, 10, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.1", new DateTime(2025, 10, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 54, new DateTime(2025, 10, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.2", new DateTime(2025, 10, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 55, new DateTime(2025, 10, 11, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.1", new DateTime(2025, 10, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 56, new DateTime(2025, 10, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.2", new DateTime(2025, 10, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 57, new DateTime(2025, 10, 9, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.3", new DateTime(2025, 10, 9, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 58, new DateTime(2025, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.1", new DateTime(2025, 10, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 59, new DateTime(2025, 10, 10, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.1", new DateTime(2025, 10, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 60, new DateTime(2025, 10, 4, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.1", new DateTime(2025, 10, 4, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 61, new DateTime(2025, 10, 7, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.1", new DateTime(2025, 10, 7, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 }
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
