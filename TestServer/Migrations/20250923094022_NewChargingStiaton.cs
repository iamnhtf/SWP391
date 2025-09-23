using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class NewChargingStiaton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Tầng L1, Vincom Centre Landmark 81, 208 Nguyễn Hữu Cảnh, P.22, Q. Bình Thạnh, TP.HCM", "Trạm Sạc Landmark 81" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Tầng 1, Trung tâm thương mại Vincom Cộng Hòa, 15-17 Cộng Hòa, P.4, Q. Tân Bình, TP.HCM", "Trạm Sạc Cộng Hòa" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Tầng 1, TTTM Vincom Ba Tháng Hai, 3C Đường 3 Tháng 2, P.11, Q.10, TP.HCM", "Trạm Sạc Ba Tháng Hai" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Tầng hầm B3, tòa Léman Luxury, 117 Nguyễn Đình Chiểu, P.6, Quận 3", "Trạm Sạc Léman Luxury Apartments" });

            migrationBuilder.InsertData(
                table: "ChargingStations",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 5, "Số 130/30G, Nguyễn Văn Lượng, P.10, Quận 6", "Trạm Sạc Huỳnh Hiếu Thiện" },
                    { 6, "Số 89, Hoàng Quốc Việt, P. Phú Thuận, Quận 7", "Trạm Sạc Sky89" },
                    { 7, "Hầm B5, số 72 Lê Thánh Tôn, Quận 1", "Trạm Sạc Center Đồng Khởi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Quận 1, TP.HCM", "Trạm Sạc Quận 1" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Quận 3, TP.HCM", "Trạm Sạc Quận 3" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Quận 7, TP.HCM", "Trạm Sạc Quận 7" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location", "Name" },
                values: new object[] { "TP. Thủ Đức, TP.HCM", "Trạm Sạc Thủ Đức" });
        }
    }
}
