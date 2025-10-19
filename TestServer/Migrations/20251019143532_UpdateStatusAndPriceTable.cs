using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatusAndPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ChargingStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ChargingPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.1",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.10",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.4",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.5",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.6",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.7",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.8",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.9",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PenaltyFeePerMinute", "PricePerKWh", "Status", "ValidFrom", "ValidTo" },
                values: new object[] { 800f, 3500f, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PriceTables",
                columns: new[] { "Id", "PenaltyFeePerMinute", "PricePerKWh", "Status", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 2, 1000f, 3858f, 0, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1200f, 4000f, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ChargingStations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ChargingPoints");

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PenaltyFeePerMinute", "PricePerKWh", "Status", "ValidFrom", "ValidTo" },
                values: new object[] { 1000f, 3858f, 0, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
