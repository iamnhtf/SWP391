using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "PenaltyFeePerMinute", "PricePerKWh", "ValidFrom", "ValidTo" },
                values: new object[] { "PriceTable for Nov-2025", 1100f, 3900f, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PriceTables",
                columns: new[] { "Id", "Name", "PenaltyFeePerMinute", "PricePerKWh", "Status", "ValidFrom", "ValidTo" },
                values: new object[] { 4, "PriceTable for 2026", 1200f, 4000f, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "PenaltyFeePerMinute", "PricePerKWh", "ValidFrom", "ValidTo" },
                values: new object[] { "PriceTable for 2026", 1200f, 4000f, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
