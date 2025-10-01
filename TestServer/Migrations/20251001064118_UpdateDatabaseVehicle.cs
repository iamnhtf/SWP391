using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "51B-67890", "Tesla Model 3" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "30A-12345", "VinFast VF 8" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "29C-56789", "Toyota Camry" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "88D-45678", "Hyundai Ioniq 5" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "77E-99999", "Kia EV6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "ABC-123", "D1" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "XYZ-789", "D1" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "LMN-456", "D2" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "DEF-321", "D3" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                columns: new[] { "LicensePlate", "Name" },
                values: new object[] { "UVW-987", "D4" });
        }
    }
}
