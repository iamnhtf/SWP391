using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class VehicleStatusAndPriceTableStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_PriceTable_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceTable",
                table: "PriceTable");

            migrationBuilder.RenameTable(
                name: "PriceTable",
                newName: "PriceTables");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Vehicles",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceTables",
                table: "PriceTables",
                column: "Id");

            migrationBuilder.InsertData(
                table: "PriceTables",
                columns: new[] { "Id", "PenaltyFeePerMinute", "PricePerKWh", "ValidFrom", "ValidTo" },
                values: new object[] { 1, 300f, 4500f, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1,
                column: "Status",
                value: "Available");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2,
                column: "Status",
                value: "Faulty");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3,
                column: "Status",
                value: "InUse");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4,
                column: "Status",
                value: "Faulty");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5,
                column: "Status",
                value: "Available");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_PriceTables_PriceId",
                table: "ChargingSessions",
                column: "PriceId",
                principalTable: "PriceTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_PriceTables_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceTables",
                table: "PriceTables");

            migrationBuilder.DeleteData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "PriceTables",
                newName: "PriceTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceTable",
                table: "PriceTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_PriceTable_PriceId",
                table: "ChargingSessions",
                column: "PriceId",
                principalTable: "PriceTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
