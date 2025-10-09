using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PenaltyFeePerMinute", "PricePerKWh", "ValidFrom" },
                values: new object[] { 1000f, 3858f, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PenaltyFeePerMinute", "PricePerKWh", "ValidFrom" },
                values: new object[] { 300f, 4500f, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
