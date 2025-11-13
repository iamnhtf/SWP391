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
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PriceTables",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ValidFrom", "ValidTo" },
                values: new object[] { "PriceTable for 2024", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ValidFrom" },
                values: new object[] { "PriceTable for 2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ValidTo" },
                values: new object[] { "PriceTable for 2026", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PriceTables");

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ValidFrom", "ValidTo" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValidFrom",
                value: new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 3,
                column: "ValidTo",
                value: new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
