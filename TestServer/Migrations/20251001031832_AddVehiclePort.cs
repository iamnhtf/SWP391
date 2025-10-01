using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class AddVehiclePort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehiclePorts",
                keyColumns: new[] { "ConnectorId", "VehicleId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "VehiclePorts",
                keyColumns: new[] { "ConnectorId", "VehicleId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "VehiclePorts",
                columns: new[] { "ConnectorId", "VehicleId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehiclePorts",
                keyColumns: new[] { "ConnectorId", "VehicleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "VehiclePorts",
                keyColumns: new[] { "ConnectorId", "VehicleId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "VehiclePorts",
                columns: new[] { "ConnectorId", "VehicleId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 4, 5 }
                });
        }
    }
}
