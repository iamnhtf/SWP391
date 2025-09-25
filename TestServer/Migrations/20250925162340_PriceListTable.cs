using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class PriceListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Connectors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AC" },
                    { 2, "CCS (DC)" },
                    { 3, "CHAdeMO (DC)" }
                });

            migrationBuilder.InsertData(
                table: "PowerRanges",
                columns: new[] { "Id", "Range" },
                values: new object[,]
                {
                    { 1, "0-7" },
                    { 2, "7-50" },
                    { 3, ">50" }
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
                    { 1, "Xe máy" },
                    { 2, "Ô tô" }
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
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "Connectors");

            migrationBuilder.DropTable(
                name: "PowerRanges");

            migrationBuilder.DropTable(
                name: "TimeRanges");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
