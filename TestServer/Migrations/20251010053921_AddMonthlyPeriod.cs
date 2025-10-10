using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class AddMonthlyPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MonthlyPeriods",
                columns: new[] { "PeriodId", "Month", "Year" },
                values: new object[,]
                {
                    { 1, 1, 2024 },
                    { 2, 2, 2024 },
                    { 3, 3, 2024 },
                    { 4, 4, 2024 },
                    { 5, 5, 2024 },
                    { 6, 6, 2024 },
                    { 7, 7, 2024 },
                    { 8, 8, 2024 },
                    { 9, 9, 2024 },
                    { 10, 10, 2024 },
                    { 11, 11, 2024 },
                    { 12, 12, 2024 },
                    { 13, 1, 2025 },
                    { 14, 2, 2025 },
                    { 15, 3, 2025 },
                    { 16, 4, 2025 },
                    { 17, 5, 2025 },
                    { 18, 6, 2025 },
                    { 19, 7, 2025 },
                    { 20, 8, 2025 },
                    { 21, 9, 2025 },
                    { 22, 10, 2025 },
                    { 23, 11, 2025 },
                    { 24, 12, 2025 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MonthlyPeriods",
                keyColumn: "PeriodId",
                keyValue: 24);
        }
    }
}
