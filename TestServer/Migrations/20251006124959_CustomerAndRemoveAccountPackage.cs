using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class CustomerAndRemoveAccountPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AccountPackages");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Vehicles",
                type: "longtext",
                nullable: false);

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
                    { "C010", "Quận Phú Nhuận, TP.HCM", "hoa.le@example.com", "Lê Thị Hòa", "0905566778" }
                });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "CustomerId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "CustomerId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "CustomerId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "CustomerId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                column: "CustomerId",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "AccountPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiscountPercent = table.Column<double>(type: "double", nullable: false),
                    MinTotalSpend = table.Column<double>(type: "double", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPackages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountPackageId = table.Column<int>(type: "int", nullable: true),
                    Car = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    LicenseNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TotalSpend = table.Column<double>(type: "double", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AccountPackageId",
                table: "Drivers",
                column: "AccountPackageId");
        }
    }
}
