using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChargingPoints",
                columns: new[] { "Id", "StationId" },
                values: new object[,]
                {
                    { "1.2", 1 },
                    { "1.3", 1 },
                    { "1.4", 1 },
                    { "1.5", 1 },
                    { "1.6", 1 },
                    { "1.7", 1 },
                    { "2.10", 2 },
                    { "2.2", 2 },
                    { "2.3", 2 },
                    { "2.4", 2 },
                    { "2.5", 2 },
                    { "2.6", 2 },
                    { "2.7", 2 },
                    { "2.8", 2 },
                    { "2.9", 2 },
                    { "3.10", 3 },
                    { "3.2", 3 },
                    { "3.3", 3 },
                    { "3.4", 3 },
                    { "3.5", 3 },
                    { "3.6", 3 },
                    { "3.7", 3 },
                    { "3.8", 3 },
                    { "3.9", 3 },
                    { "4.10", 4 },
                    { "4.2", 4 },
                    { "4.3", 4 },
                    { "4.4", 4 },
                    { "4.5", 4 },
                    { "4.6", 4 },
                    { "4.7", 4 },
                    { "4.8", 4 },
                    { "4.9", 4 },
                    { "5.10", 5 },
                    { "5.2", 5 },
                    { "5.3", 5 },
                    { "5.4", 5 },
                    { "5.5", 5 },
                    { "5.6", 5 },
                    { "5.7", 5 },
                    { "5.8", 5 },
                    { "5.9", 5 },
                    { "6.10", 6 },
                    { "6.2", 6 },
                    { "6.3", 6 },
                    { "6.4", 6 },
                    { "6.5", 6 },
                    { "6.6", 6 },
                    { "6.7", 6 },
                    { "6.8", 6 },
                    { "6.9", 6 },
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

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { "22 kW", "InUse" });

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { "50 kW", "InUse" });

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { "7 kW", "InUse" });

            migrationBuilder.InsertData(
                table: "ChargingPorts",
                columns: new[] { "Id", "ConnectorId", "PointId", "Power", "Status" },
                values: new object[,]
                {
                    { "1.1.3", 3, "1.1", "50 kW", "Available" },
                    { "2.1.3", 3, "2.1", "50 kW", "Faulty" },
                    { "3.1.3", 3, "3.1", "50 kW", "Faulty" },
                    { "4.1.3", 3, "4.1", "7 kW", "Faulty" },
                    { "5.1.3", 3, "5.1", "50 kW", "Faulty" },
                    { "6.1.3", 3, "6.1", "50 kW", "Faulty" },
                    { "7.1.3", 3, "7.1", "150 kW", "Faulty" }
                });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Vincom Landmark 81, Binh Thanh District, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Vincom Cong Hoa, Tan Binh District, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "Vincom Ba Thang Hai, District 10, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Leman Luxury Building, District 3, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "Nguyen Van Luong Street, District 6, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "Hoang Quoc Viet Street, District 7, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "Le Thanh Ton Street, District 1, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "PowerRanges",
                keyColumn: "Id",
                keyValue: 3,
                column: "Range",
                value: "50-150");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "car");

            migrationBuilder.InsertData(
                table: "ChargingPorts",
                columns: new[] { "Id", "ConnectorId", "PointId", "Power", "Status" },
                values: new object[,]
                {
                    { "1.2.1", 1, "1.2", "7 kW", "Available" },
                    { "1.2.2", 2, "1.2", "22 kW", "Faulty" },
                    { "1.2.3", 3, "1.2", "150 kW", "InUse" },
                    { "1.3.1", 1, "1.3", "7 kW", "InUse" },
                    { "1.3.2", 2, "1.3", "22 kW", "Available" },
                    { "1.3.3", 3, "1.3", "50 kW", "Available" },
                    { "1.4.1", 1, "1.4", "7 kW", "Available" },
                    { "1.4.2", 2, "1.4", "22 kW", "Available" },
                    { "1.4.3", 3, "1.4", "150 kW", "Faulty" },
                    { "1.5.1", 1, "1.5", "7 kW", "Available" },
                    { "1.5.2", 2, "1.5", "22 kW", "InUse" },
                    { "1.5.3", 3, "1.5", "50 kW", "Available" },
                    { "1.6.1", 1, "1.6", "7 kW", "InUse" },
                    { "1.6.2", 2, "1.6", "22 kW", "Available" },
                    { "1.6.3", 3, "1.6", "150 kW", "Available" },
                    { "1.7.1", 1, "1.7", "7 kW", "Available" },
                    { "1.7.2", 2, "1.7", "22 kW", "Faulty" },
                    { "1.7.3", 3, "1.7", "50 kW", "InUse" },
                    { "2.10.1", 1, "2.10", "7 kW", "Available" },
                    { "2.10.2", 2, "2.10", "50 kW", "InUse" },
                    { "2.10.3", 3, "2.10", "22 kW", "Faulty" },
                    { "2.2.1", 1, "2.2", "22 kW", "Available" },
                    { "2.2.2", 2, "2.2", "150 kW", "InUse" },
                    { "2.2.3", 3, "2.2", "7 kW", "Faulty" },
                    { "2.3.1", 1, "2.3", "50 kW", "Available" },
                    { "2.3.2", 2, "2.3", "22 kW", "InUse" },
                    { "2.3.3", 3, "2.3", "7 kW", "Faulty" },
                    { "2.4.1", 1, "2.4", "150 kW", "Available" },
                    { "2.4.2", 2, "2.4", "7 kW", "InUse" },
                    { "2.4.3", 3, "2.4", "22 kW", "Faulty" },
                    { "2.5.1", 1, "2.5", "22 kW", "Available" },
                    { "2.5.2", 2, "2.5", "50 kW", "InUse" },
                    { "2.5.3", 3, "2.5", "150 kW", "Faulty" },
                    { "2.6.1", 1, "2.6", "7 kW", "Available" },
                    { "2.6.2", 2, "2.6", "150 kW", "InUse" },
                    { "2.6.3", 3, "2.6", "22 kW", "Faulty" },
                    { "2.7.1", 1, "2.7", "22 kW", "Available" },
                    { "2.7.2", 2, "2.7", "7 kW", "InUse" },
                    { "2.7.3", 3, "2.7", "50 kW", "Faulty" },
                    { "2.8.1", 1, "2.8", "50 kW", "Available" },
                    { "2.8.2", 2, "2.8", "22 kW", "InUse" },
                    { "2.8.3", 3, "2.8", "7 kW", "Faulty" },
                    { "2.9.1", 1, "2.9", "150 kW", "Available" },
                    { "2.9.2", 2, "2.9", "22 kW", "InUse" },
                    { "2.9.3", 3, "2.9", "7 kW", "Faulty" },
                    { "3.10.1", 1, "3.10", "7 kW", "Available" },
                    { "3.10.2", 2, "3.10", "50 kW", "InUse" },
                    { "3.10.3", 3, "3.10", "22 kW", "Faulty" },
                    { "3.2.1", 1, "3.2", "22 kW", "Available" },
                    { "3.2.2", 2, "3.2", "150 kW", "InUse" },
                    { "3.2.3", 3, "3.2", "7 kW", "Faulty" },
                    { "3.3.1", 1, "3.3", "50 kW", "Available" },
                    { "3.3.2", 2, "3.3", "22 kW", "InUse" },
                    { "3.3.3", 3, "3.3", "7 kW", "Faulty" },
                    { "3.4.1", 1, "3.4", "150 kW", "Available" },
                    { "3.4.2", 2, "3.4", "7 kW", "InUse" },
                    { "3.4.3", 3, "3.4", "22 kW", "Faulty" },
                    { "3.5.1", 1, "3.5", "22 kW", "Available" },
                    { "3.5.2", 2, "3.5", "50 kW", "InUse" },
                    { "3.5.3", 3, "3.5", "150 kW", "Faulty" },
                    { "3.6.1", 1, "3.6", "7 kW", "Available" },
                    { "3.6.2", 2, "3.6", "150 kW", "InUse" },
                    { "3.6.3", 3, "3.6", "22 kW", "Faulty" },
                    { "3.7.1", 1, "3.7", "22 kW", "Available" },
                    { "3.7.2", 2, "3.7", "7 kW", "InUse" },
                    { "3.7.3", 3, "3.7", "50 kW", "Faulty" },
                    { "3.8.1", 1, "3.8", "50 kW", "Available" },
                    { "3.8.2", 2, "3.8", "22 kW", "InUse" },
                    { "3.8.3", 3, "3.8", "7 kW", "Faulty" },
                    { "3.9.1", 1, "3.9", "150 kW", "Available" },
                    { "3.9.2", 2, "3.9", "22 kW", "InUse" },
                    { "3.9.3", 3, "3.9", "7 kW", "Faulty" },
                    { "4.10.1", 1, "4.10", "7 kW", "Available" },
                    { "4.10.2", 2, "4.10", "22 kW", "InUse" },
                    { "4.10.3", 3, "4.10", "150 kW", "Faulty" },
                    { "4.2.1", 1, "4.2", "150 kW", "Available" },
                    { "4.2.2", 2, "4.2", "22 kW", "InUse" },
                    { "4.2.3", 3, "4.2", "7 kW", "Faulty" },
                    { "4.3.1", 1, "4.3", "7 kW", "Available" },
                    { "4.3.2", 2, "4.3", "22 kW", "InUse" },
                    { "4.3.3", 3, "4.3", "50 kW", "Faulty" },
                    { "4.4.1", 1, "4.4", "22 kW", "Available" },
                    { "4.4.2", 2, "4.4", "150 kW", "InUse" },
                    { "4.4.3", 3, "4.4", "7 kW", "Faulty" },
                    { "4.5.1", 1, "4.5", "50 kW", "Available" },
                    { "4.5.2", 2, "4.5", "22 kW", "InUse" },
                    { "4.5.3", 3, "4.5", "150 kW", "Faulty" },
                    { "4.6.1", 1, "4.6", "7 kW", "Available" },
                    { "4.6.2", 2, "4.6", "50 kW", "InUse" },
                    { "4.6.3", 3, "4.6", "22 kW", "Faulty" },
                    { "4.7.1", 1, "4.7", "150 kW", "Available" },
                    { "4.7.2", 2, "4.7", "22 kW", "InUse" },
                    { "4.7.3", 3, "4.7", "7 kW", "Faulty" },
                    { "4.8.1", 1, "4.8", "22 kW", "Available" },
                    { "4.8.2", 2, "4.8", "7 kW", "InUse" },
                    { "4.8.3", 3, "4.8", "50 kW", "Faulty" },
                    { "4.9.1", 1, "4.9", "50 kW", "Available" },
                    { "4.9.2", 2, "4.9", "150 kW", "InUse" },
                    { "4.9.3", 3, "4.9", "22 kW", "Faulty" },
                    { "5.10.1", 1, "5.10", "150 kW", "Available" },
                    { "5.10.2", 2, "5.10", "22 kW", "InUse" },
                    { "5.10.3", 3, "5.10", "7 kW", "Faulty" },
                    { "5.2.1", 1, "5.2", "150 kW", "Available" },
                    { "5.2.2", 2, "5.2", "7 kW", "InUse" },
                    { "5.2.3", 3, "5.2", "22 kW", "Faulty" },
                    { "5.3.1", 1, "5.3", "22 kW", "Available" },
                    { "5.3.2", 2, "5.3", "50 kW", "InUse" },
                    { "5.3.3", 3, "5.3", "7 kW", "Faulty" },
                    { "5.4.1", 1, "5.4", "7 kW", "Available" },
                    { "5.4.2", 2, "5.4", "150 kW", "InUse" },
                    { "5.4.3", 3, "5.4", "22 kW", "Faulty" },
                    { "5.5.1", 1, "5.5", "22 kW", "Available" },
                    { "5.5.2", 2, "5.5", "7 kW", "InUse" },
                    { "5.5.3", 3, "5.5", "150 kW", "Faulty" },
                    { "5.6.1", 1, "5.6", "50 kW", "Available" },
                    { "5.6.2", 2, "5.6", "22 kW", "InUse" },
                    { "5.6.3", 3, "5.6", "7 kW", "Faulty" },
                    { "5.7.1", 1, "5.7", "150 kW", "Available" },
                    { "5.7.2", 2, "5.7", "22 kW", "InUse" },
                    { "5.7.3", 3, "5.7", "50 kW", "Faulty" },
                    { "5.8.1", 1, "5.8", "7 kW", "Available" },
                    { "5.8.2", 2, "5.8", "50 kW", "InUse" },
                    { "5.8.3", 3, "5.8", "150 kW", "Faulty" },
                    { "5.9.1", 1, "5.9", "22 kW", "Available" },
                    { "5.9.2", 2, "5.9", "7 kW", "InUse" },
                    { "5.9.3", 3, "5.9", "50 kW", "Faulty" },
                    { "6.10.1", 1, "6.10", "150 kW", "Available" },
                    { "6.10.2", 2, "6.10", "22 kW", "InUse" },
                    { "6.10.3", 3, "6.10", "7 kW", "Faulty" },
                    { "6.2.1", 1, "6.2", "150 kW", "Available" },
                    { "6.2.2", 2, "6.2", "7 kW", "InUse" },
                    { "6.2.3", 3, "6.2", "22 kW", "Faulty" },
                    { "6.3.1", 1, "6.3", "22 kW", "Available" },
                    { "6.3.2", 2, "6.3", "50 kW", "InUse" },
                    { "6.3.3", 3, "6.3", "7 kW", "Faulty" },
                    { "6.4.1", 1, "6.4", "7 kW", "Available" },
                    { "6.4.2", 2, "6.4", "150 kW", "InUse" },
                    { "6.4.3", 3, "6.4", "22 kW", "Faulty" },
                    { "6.5.1", 1, "6.5", "22 kW", "Available" },
                    { "6.5.2", 2, "6.5", "7 kW", "InUse" },
                    { "6.5.3", 3, "6.5", "150 kW", "Faulty" },
                    { "6.6.1", 1, "6.6", "50 kW", "Available" },
                    { "6.6.2", 2, "6.6", "22 kW", "InUse" },
                    { "6.6.3", 3, "6.6", "7 kW", "Faulty" },
                    { "6.7.1", 1, "6.7", "150 kW", "Available" },
                    { "6.7.2", 2, "6.7", "22 kW", "InUse" },
                    { "6.7.3", 3, "6.7", "50 kW", "Faulty" },
                    { "6.8.1", 1, "6.8", "7 kW", "Available" },
                    { "6.8.2", 2, "6.8", "50 kW", "InUse" },
                    { "6.8.3", 3, "6.8", "150 kW", "Faulty" },
                    { "6.9.1", 1, "6.9", "22 kW", "Available" },
                    { "6.9.2", 2, "6.9", "7 kW", "InUse" },
                    { "6.9.3", 3, "6.9", "50 kW", "Faulty" },
                    { "7.10.1", 1, "7.10", "50 kW", "Available" },
                    { "7.10.2", 2, "7.10", "150 kW", "InUse" },
                    { "7.10.3", 3, "7.10", "22 kW", "Faulty" },
                    { "7.2.1", 1, "7.2", "50 kW", "Available" },
                    { "7.2.2", 2, "7.2", "22 kW", "InUse" },
                    { "7.2.3", 3, "7.2", "7 kW", "Faulty" },
                    { "7.3.1", 1, "7.3", "7 kW", "Available" },
                    { "7.3.2", 2, "7.3", "150 kW", "InUse" },
                    { "7.3.3", 3, "7.3", "22 kW", "Faulty" },
                    { "7.4.1", 1, "7.4", "22 kW", "Available" },
                    { "7.4.2", 2, "7.4", "50 kW", "InUse" },
                    { "7.4.3", 3, "7.4", "7 kW", "Faulty" },
                    { "7.5.1", 1, "7.5", "150 kW", "Available" },
                    { "7.5.2", 2, "7.5", "22 kW", "InUse" },
                    { "7.5.3", 3, "7.5", "50 kW", "Faulty" },
                    { "7.6.1", 1, "7.6", "7 kW", "Available" },
                    { "7.6.2", 2, "7.6", "150 kW", "InUse" },
                    { "7.6.3", 3, "7.6", "22 kW", "Faulty" },
                    { "7.7.1", 1, "7.7", "50 kW", "Available" },
                    { "7.7.2", 2, "7.7", "7 kW", "InUse" },
                    { "7.7.3", 3, "7.7", "150 kW", "Faulty" },
                    { "7.8.1", 1, "7.8", "22 kW", "Available" },
                    { "7.8.2", 2, "7.8", "50 kW", "InUse" },
                    { "7.8.3", 3, "7.8", "7 kW", "Faulty" },
                    { "7.9.1", 1, "7.9", "150 kW", "Available" },
                    { "7.9.2", 2, "7.9", "22 kW", "InUse" },
                    { "7.9.3", 3, "7.9", "7 kW", "Faulty" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.3");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.1");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.2");

            migrationBuilder.DeleteData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.9");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.9");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.9");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.9");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.9");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.10");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.2");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.3");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.4");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.5");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.6");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.7");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.8");

            migrationBuilder.DeleteData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.9");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { ">50 kW", "Faulty" });

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { "7 kW", "Faulty" });

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: ">50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                columns: new[] { "Power", "Status" },
                values: new object[] { "50 kW", "Faulty" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "L1 Floor, Vincom Centre Landmark 81, 208 Nguyen Huu Canh Street, Ward 22, Binh Thanh District, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "1st Floor, Vincom Cong Hoa Trade Center, 15-17 Cong Hoa Street, Ward 4, Tan Binh District, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "1st Floor, Vincom Ba Thang Hai Trade Center, 3C 3 Thang 2 Street, Ward 11, District 10, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "B3 Basement, Leman Luxury Building, 117 Nguyen Dinh Chieu Street, Ward 6, District 3, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "130/30G Nguyen Van Luong Street, Ward 10, District 6, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "89 Hoang Quoc Viet Street, Phu Thuan Ward, District 7, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "B5 Basement, 72 Le Thanh Ton Street, District 1, Ho Chi Minh City");

            migrationBuilder.UpdateData(
                table: "PowerRanges",
                keyColumn: "Id",
                keyValue: 3,
                column: "Range",
                value: ">50");

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Car");
        }
    }
}
