using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForChargingStationAndDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChargingStations",
                columns: new[] { "Id", "Location", "Name", "PowerOutputKW" },
                values: new object[,]
                {
                    { 1, "Quận 1, TP.HCM", "Trạm Sạc Quận 1", 50 },
                    { 2, "Quận 3, TP.HCM", "Trạm Sạc Quận 3", 60 },
                    { 3, "Quận 7, TP.HCM", "Trạm Sạc Quận 7", 80 },
                    { 4, "TP. Thủ Đức, TP.HCM", "Trạm Sạc Thủ Đức", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
