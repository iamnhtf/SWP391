using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    MinTotalSpend = table.Column<double>(type: "double", nullable: false),
                    DiscountPercent = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPackages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false)
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
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LicenseNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Car = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TotalSpend = table.Column<double>(type: "double", nullable: false),
                    AccountPackageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_AccountPackages_AccountPackageId",
                        column: x => x.AccountPackageId,
                        principalTable: "AccountPackages",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChargingPoints",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false)
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
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    ConnectorId = table.Column<int>(type: "int", nullable: false),
                    PowerRangeId = table.Column<int>(type: "int", nullable: false),
                    TimeRangeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceLists_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalTable: "Connectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceLists_PowerRanges_PowerRangeId",
                        column: x => x.PowerRangeId,
                        principalTable: "PowerRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceLists_TimeRanges_TimeRangeId",
                        column: x => x.TimeRangeId,
                        principalTable: "TimeRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceLists_VehicleTypes_VehicleTypeId",
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

            migrationBuilder.InsertData(
                table: "AccountPackages",
                columns: new[] { "Id", "DiscountPercent", "MinTotalSpend", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, 0.0, "Normal" },
                    { 2, 5.0, 100000.0, "Silver" },
                    { 3, 10.0, 200000.0, "Gold" },
                    { 4, 15.0, 300000.0, "Diamond" }
                });

            migrationBuilder.InsertData(
                table: "ChargingStations",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Vincom Landmark 81, Binh Thanh District, Ho Chi Minh City", "Landmark 81 Charging Station" },
                    { 2, "Vincom Cong Hoa, Tan Binh District, Ho Chi Minh City", "Cong Hoa Charging Station" },
                    { 3, "Vincom Ba Thang Hai, District 10, Ho Chi Minh City", "Ba Thang Hai Charging Station" },
                    { 4, "Leman Luxury Building, District 3, Ho Chi Minh City", "Leman Luxury Apartments Station" },
                    { 5, "Nguyen Van Luong Street, District 6, Ho Chi Minh City", "Huynh Hieu Thien Station" },
                    { 6, "Hoang Quoc Viet Street, District 7, Ho Chi Minh City", "Sky89 Station" },
                    { 7, "Le Thanh Ton Street, District 1, Ho Chi Minh City", "Center Dong Khoi Station" }
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
                table: "Drivers",
                columns: new[] { "Id", "AccountPackageId", "Car", "LicenseNumber", "Name", "PhoneNumber", "TotalSpend" },
                values: new object[,]
                {
                    { 1, null, "", "", "Nguyễn Xuân Thịnh", "", 0.0 },
                    { 2, null, "", "", "Nguyễn Hưng Thái", "", 0.0 },
                    { 3, null, "", "", "Nguyễn Bùi Đăng Khôi", "", 0.0 },
                    { 4, null, "", "", "Lê Minh Đức", "", 0.0 },
                    { 5, null, "", "", "Vũ Thế Anh", "", 0.0 }
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
                    { 2, "car" }
                });

            migrationBuilder.InsertData(
                table: "ChargingPoints",
                columns: new[] { "Id", "StationId" },
                values: new object[,]
                {
                    { "1.1", 1 },
                    { "1.2", 1 },
                    { "1.3", 1 },
                    { "1.4", 1 },
                    { "1.5", 1 },
                    { "1.6", 1 },
                    { "1.7", 1 },
                    { "2.1", 2 },
                    { "2.10", 2 },
                    { "2.2", 2 },
                    { "2.3", 2 },
                    { "2.4", 2 },
                    { "2.5", 2 },
                    { "2.6", 2 },
                    { "2.7", 2 },
                    { "2.8", 2 },
                    { "2.9", 2 },
                    { "3.1", 3 },
                    { "3.10", 3 },
                    { "3.2", 3 },
                    { "3.3", 3 },
                    { "3.4", 3 },
                    { "3.5", 3 },
                    { "3.6", 3 },
                    { "3.7", 3 },
                    { "3.8", 3 },
                    { "3.9", 3 },
                    { "4.1", 4 },
                    { "4.10", 4 },
                    { "4.2", 4 },
                    { "4.3", 4 },
                    { "4.4", 4 },
                    { "4.5", 4 },
                    { "4.6", 4 },
                    { "4.7", 4 },
                    { "4.8", 4 },
                    { "4.9", 4 },
                    { "5.1", 5 },
                    { "5.10", 5 },
                    { "5.2", 5 },
                    { "5.3", 5 },
                    { "5.4", 5 },
                    { "5.5", 5 },
                    { "5.6", 5 },
                    { "5.7", 5 },
                    { "5.8", 5 },
                    { "5.9", 5 },
                    { "6.1", 6 },
                    { "6.10", 6 },
                    { "6.2", 6 },
                    { "6.3", 6 },
                    { "6.4", 6 },
                    { "6.5", 6 },
                    { "6.6", 6 },
                    { "6.7", 6 },
                    { "6.8", 6 },
                    { "6.9", 6 },
                    { "7.1", 7 },
                    { "7.10", 7 },
                    { "7.2", 7 },
                    { "7.3", 7 },
                    { "7.4", 7 },
                    { "7.5", 7 },
                    { "7.6", 7 },
                    { "7.7", 7 },
                    { "7.8", 7 },
                    { "7.9", 7 }
                });

            migrationBuilder.InsertData(
                table: "PriceLists",
                columns: new[] { "Id", "ConnectorId", "PowerRangeId", "Price", "TimeRangeId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 3500.0, 1, 1 },
                    { 2, 1, 1, 4500.0, 2, 1 },
                    { 3, 1, 1, 3000.0, 3, 1 },
                    { 4, 1, 2, 4000.0, 1, 1 },
                    { 5, 1, 2, 5500.0, 2, 1 },
                    { 6, 1, 2, 3500.0, 3, 1 },
                    { 7, 1, 3, 5500.0, 1, 1 },
                    { 8, 1, 3, 7000.0, 2, 1 },
                    { 9, 1, 3, 4500.0, 3, 1 },
                    { 10, 2, 1, 4500.0, 1, 1 },
                    { 11, 2, 1, 6000.0, 2, 1 },
                    { 12, 2, 1, 4000.0, 3, 1 },
                    { 13, 2, 2, 6000.0, 1, 1 },
                    { 14, 2, 2, 7500.0, 2, 1 },
                    { 15, 2, 2, 5000.0, 3, 1 },
                    { 16, 2, 3, 7000.0, 1, 1 },
                    { 17, 2, 3, 9000.0, 2, 1 },
                    { 18, 2, 3, 6000.0, 3, 1 },
                    { 19, 3, 1, 4500.0, 1, 1 },
                    { 20, 3, 1, 6000.0, 2, 1 },
                    { 21, 3, 1, 4000.0, 3, 1 },
                    { 22, 3, 2, 6000.0, 1, 1 },
                    { 23, 3, 2, 7500.0, 2, 1 },
                    { 24, 3, 2, 5000.0, 3, 1 },
                    { 25, 3, 3, 7000.0, 1, 1 },
                    { 26, 3, 3, 9000.0, 2, 1 },
                    { 27, 3, 3, 6000.0, 3, 1 },
                    { 28, 1, 1, 4500.0, 1, 2 },
                    { 29, 1, 1, 6000.0, 2, 2 },
                    { 30, 1, 1, 4000.0, 3, 2 },
                    { 31, 1, 2, 5500.0, 1, 2 },
                    { 32, 1, 2, 7000.0, 2, 2 },
                    { 33, 1, 2, 4500.0, 3, 2 },
                    { 34, 1, 3, 6500.0, 1, 2 },
                    { 35, 1, 3, 8000.0, 2, 2 },
                    { 36, 1, 3, 5500.0, 3, 2 },
                    { 37, 2, 1, 5500.0, 1, 2 },
                    { 38, 2, 1, 7000.0, 2, 2 },
                    { 39, 2, 1, 5000.0, 3, 2 },
                    { 40, 2, 2, 7000.0, 1, 2 },
                    { 41, 2, 2, 9000.0, 2, 2 },
                    { 42, 2, 2, 6500.0, 3, 2 },
                    { 43, 2, 3, 8500.0, 1, 2 },
                    { 44, 2, 3, 10500.0, 2, 2 },
                    { 45, 2, 3, 7500.0, 3, 2 },
                    { 46, 3, 1, 5500.0, 1, 2 },
                    { 47, 3, 1, 7000.0, 2, 2 },
                    { 48, 3, 1, 5000.0, 3, 2 },
                    { 49, 3, 2, 7000.0, 1, 2 },
                    { 50, 3, 2, 9000.0, 2, 2 },
                    { 51, 3, 2, 6500.0, 3, 2 },
                    { 52, 3, 3, 8500.0, 1, 2 },
                    { 53, 3, 3, 10500.0, 2, 2 },
                    { 54, 3, 3, 7500.0, 3, 2 }
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
                name: "IX_Drivers_AccountPackageId",
                table: "Drivers",
                column: "AccountPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ConnectorId",
                table: "PriceLists",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_PowerRangeId",
                table: "PriceLists",
                column: "PowerRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_TimeRangeId",
                table: "PriceLists",
                column: "TimeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_VehicleTypeId",
                table: "PriceLists",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingPorts");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "ChargingPoints");

            migrationBuilder.DropTable(
                name: "AccountPackages");

            migrationBuilder.DropTable(
                name: "Connectors");

            migrationBuilder.DropTable(
                name: "PowerRanges");

            migrationBuilder.DropTable(
                name: "TimeRanges");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "ChargingStations");
        }
    }
}
