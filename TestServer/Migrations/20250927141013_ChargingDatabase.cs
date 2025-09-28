using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class ChargingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChargingPoints",
                columns: new[] { "Id", "StationId" },
                values: new object[,]
                {
                    { "1.1", 1 },
                    { "2.1", 2 },
                    { "3.1", 3 },
                    { "4.1", 4 },
                    { "5.1", 5 },
                    { "6.1", 6 },
                    { "7.1", 7 }
                });

            migrationBuilder.UpdateData(
            table: "ChargingStations",
            keyColumn: "Id",
            keyValue: 1,
            columns: new[] { "Location", "Name" },
            values: new object[] { "L1 Floor, Vincom Centre Landmark 81, 208 Nguyen Huu Canh Street, Ward 22, Binh Thanh District, Ho Chi Minh City", "Landmark 81 Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location", "Name" },
                values: new object[] { "1st Floor, Vincom Cong Hoa Trade Center, 15-17 Cong Hoa Street, Ward 4, Tan Binh District, Ho Chi Minh City", "Cong Hoa Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location", "Name" },
                values: new object[] { "1st Floor, Vincom Ba Thang Hai Trade Center, 3C 3 Thang 2 Street, Ward 11, District 10, Ho Chi Minh City", "Ba Thang Hai Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location", "Name" },
                values: new object[] { "B3 Basement, Leman Luxury Building, 117 Nguyen Dinh Chieu Street, Ward 6, District 3, Ho Chi Minh City", "Leman Luxury Apartments Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Location", "Name" },
                values: new object[] { "130/30G Nguyen Van Luong Street, Ward 10, District 6, Ho Chi Minh City", "Huynh Hieu Thien Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Location", "Name" },
                values: new object[] { "89 Hoang Quoc Viet Street, Phu Thuan Ward, District 7, Ho Chi Minh City", "Sky89 Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Location", "Name" },
                values: new object[] { "B5 Basement, 72 Le Thanh Ton Street, District 1, Ho Chi Minh City", "Center Dong Khoi Station" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Motorbike");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Car");
                
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingPorts");

            migrationBuilder.DropTable(
                name: "ChargingPoints");

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

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Số 130/30G, Nguyễn Văn Lượng, P.10, Quận 6", "Trạm Sạc Huỳnh Hiếu Thiện" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Số 89, Hoàng Quốc Việt, P. Phú Thuận, Quận 7", "Trạm Sạc Sky89" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Hầm B5, số 72 Lê Thánh Tôn, Quận 1", "Trạm Sạc Center Đồng Khởi" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Xe máy");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ô tô");
        }
    }
}
