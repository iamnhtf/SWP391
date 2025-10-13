using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class AddChargingSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChargingSessions",
                columns: new[] { "Id", "EndTime", "EnergyConsumed", "PortId", "StartTime", "Status", "TotalCost", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 41.2f, "1.1.1", new DateTime(2025, 7, 3, 8, 15, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 1 },
                    { 2, new DateTime(2025, 7, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 36.8f, "2.2.1", new DateTime(2025, 7, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 142000f, 1 },
                    { 3, new DateTime(2025, 7, 15, 11, 15, 0, 0, DateTimeKind.Unspecified), 39.5f, "3.3.1", new DateTime(2025, 7, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 152000f, 1 },
                    { 4, new DateTime(2025, 7, 22, 18, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.1", new DateTime(2025, 7, 22, 16, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 5, new DateTime(2025, 7, 28, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.1", new DateTime(2025, 7, 28, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 6, new DateTime(2025, 7, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 47.3f, "1.2.2", new DateTime(2025, 7, 5, 11, 20, 0, 0, DateTimeKind.Unspecified), 1, 182000f, 2 },
                    { 7, new DateTime(2025, 7, 12, 18, 25, 0, 0, DateTimeKind.Unspecified), 43.7f, "2.4.1", new DateTime(2025, 7, 12, 16, 10, 0, 0, DateTimeKind.Unspecified), 1, 168000f, 2 },
                    { 8, new DateTime(2025, 7, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), 38.1f, "3.5.1", new DateTime(2025, 7, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 147000f, 2 },
                    { 9, new DateTime(2025, 7, 25, 17, 45, 0, 0, DateTimeKind.Unspecified), 45.2f, "4.6.1", new DateTime(2025, 7, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 174000f, 2 },
                    { 10, new DateTime(2025, 7, 4, 15, 45, 0, 0, DateTimeKind.Unspecified), 31.2f, "1.3.1", new DateTime(2025, 7, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 1, 120000f, 3 },
                    { 11, new DateTime(2025, 7, 11, 11, 50, 0, 0, DateTimeKind.Unspecified), 28.9f, "2.6.1", new DateTime(2025, 7, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 111000f, 3 },
                    { 12, new DateTime(2025, 7, 19, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.7.1", new DateTime(2025, 7, 19, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 13, new DateTime(2025, 7, 6, 14, 30, 0, 0, DateTimeKind.Unspecified), 40.6f, "1.4.2", new DateTime(2025, 7, 6, 12, 45, 0, 0, DateTimeKind.Unspecified), 1, 156000f, 4 },
                    { 14, new DateTime(2025, 7, 14, 19, 10, 0, 0, DateTimeKind.Unspecified), 42.3f, "2.7.1", new DateTime(2025, 7, 14, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 163000f, 4 },
                    { 15, new DateTime(2025, 7, 20, 10, 45, 0, 0, DateTimeKind.Unspecified), 37.8f, "3.8.1", new DateTime(2025, 7, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 146000f, 4 },
                    { 16, new DateTime(2025, 7, 26, 16, 30, 0, 0, DateTimeKind.Unspecified), 44.7f, "4.9.1", new DateTime(2025, 7, 26, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 17, new DateTime(2025, 7, 7, 17, 55, 0, 0, DateTimeKind.Unspecified), 45.1f, "1.5.1", new DateTime(2025, 7, 7, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 174000f, 5 },
                    { 18, new DateTime(2025, 7, 16, 11, 30, 0, 0, DateTimeKind.Unspecified), 41.7f, "2.8.1", new DateTime(2025, 7, 16, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 5 },
                    { 19, new DateTime(2025, 7, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 47.8f, "3.9.1", new DateTime(2025, 7, 23, 18, 45, 0, 0, DateTimeKind.Unspecified), 1, 184000f, 5 },
                    { 20, new DateTime(2025, 8, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.2", new DateTime(2025, 8, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 21, new DateTime(2025, 8, 9, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.2", new DateTime(2025, 8, 9, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 22, new DateTime(2025, 8, 16, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.2", new DateTime(2025, 8, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 23, new DateTime(2025, 8, 23, 19, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.2", new DateTime(2025, 8, 23, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 24, new DateTime(2025, 8, 30, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.2", new DateTime(2025, 8, 30, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 25, new DateTime(2025, 8, 4, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.3", new DateTime(2025, 8, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 26, new DateTime(2025, 8, 11, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.3", new DateTime(2025, 8, 11, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 27, new DateTime(2025, 8, 18, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.5f, "3.4.3", new DateTime(2025, 8, 18, 9, 20, 0, 0, DateTimeKind.Unspecified), 1, 179000f, 2 },
                    { 28, new DateTime(2025, 8, 25, 17, 40, 0, 0, DateTimeKind.Unspecified), 42.8f, "4.5.3", new DateTime(2025, 8, 25, 15, 15, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 2 },
                    { 29, new DateTime(2025, 8, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.2", new DateTime(2025, 8, 6, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 30, new DateTime(2025, 8, 13, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.2", new DateTime(2025, 8, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 31, new DateTime(2025, 8, 20, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.5.2", new DateTime(2025, 8, 20, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 32, new DateTime(2025, 8, 3, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.1", new DateTime(2025, 8, 3, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 33, new DateTime(2025, 8, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.1", new DateTime(2025, 8, 10, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 },
                    { 34, new DateTime(2025, 8, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 38.7f, "3.6.1", new DateTime(2025, 8, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 149000f, 4 },
                    { 35, new DateTime(2025, 8, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 42.9f, "4.7.1", new DateTime(2025, 8, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 4 },
                    { 36, new DateTime(2025, 8, 5, 15, 15, 0, 0, DateTimeKind.Unspecified), 49.2f, "1.5.2", new DateTime(2025, 8, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 200000f, 5 },
                    { 37, new DateTime(2025, 9, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.3", new DateTime(2025, 9, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 38, new DateTime(2025, 9, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.1", new DateTime(2025, 9, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 39, new DateTime(2025, 9, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.3", new DateTime(2025, 9, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 40, new DateTime(2025, 9, 22, 19, 35, 0, 0, DateTimeKind.Unspecified), 43.1f, "4.4.3", new DateTime(2025, 9, 22, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 166000f, 1 },
                    { 41, new DateTime(2025, 9, 29, 14, 25, 0, 0, DateTimeKind.Unspecified), 41.7f, "5.5.3", new DateTime(2025, 9, 29, 12, 10, 0, 0, DateTimeKind.Unspecified), 1, 161000f, 1 },
                    { 42, new DateTime(2025, 9, 4, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.1", new DateTime(2025, 9, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 43, new DateTime(2025, 9, 11, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.1", new DateTime(2025, 9, 11, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 44, new DateTime(2025, 9, 18, 11, 45, 0, 0, DateTimeKind.Unspecified), 46.5f, "3.4.1", new DateTime(2025, 9, 18, 9, 20, 0, 0, DateTimeKind.Unspecified), 1, 179000f, 2 },
                    { 45, new DateTime(2025, 9, 25, 17, 40, 0, 0, DateTimeKind.Unspecified), 42.8f, "4.5.1", new DateTime(2025, 9, 25, 15, 15, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 2 },
                    { 46, new DateTime(2025, 9, 6, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.3", new DateTime(2025, 9, 6, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 47, new DateTime(2025, 9, 13, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.3", new DateTime(2025, 9, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 48, new DateTime(2025, 9, 20, 19, 35, 0, 0, DateTimeKind.Unspecified), 33.1f, "3.5.3", new DateTime(2025, 9, 20, 17, 20, 0, 0, DateTimeKind.Unspecified), 1, 127000f, 3 },
                    { 49, new DateTime(2025, 9, 3, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.3", new DateTime(2025, 9, 3, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 50, new DateTime(2025, 9, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.2", new DateTime(2025, 9, 10, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 },
                    { 51, new DateTime(2025, 9, 17, 13, 30, 0, 0, DateTimeKind.Unspecified), 38.7f, "3.6.2", new DateTime(2025, 9, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), 1, 149000f, 4 },
                    { 52, new DateTime(2025, 9, 24, 18, 45, 0, 0, DateTimeKind.Unspecified), 42.9f, "4.7.2", new DateTime(2025, 9, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 165000f, 4 },
                    { 53, new DateTime(2025, 10, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 40.2f, "1.1.1", new DateTime(2025, 10, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 155000f, 1 },
                    { 54, new DateTime(2025, 10, 8, 16, 20, 0, 0, DateTimeKind.Unspecified), 37.6f, "2.2.2", new DateTime(2025, 10, 8, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, 145000f, 1 },
                    { 55, new DateTime(2025, 10, 11, 10, 45, 0, 0, DateTimeKind.Unspecified), 38.9f, "3.3.1", new DateTime(2025, 10, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 150000f, 1 },
                    { 56, new DateTime(2025, 10, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), 48.9f, "1.2.2", new DateTime(2025, 10, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, 188000f, 2 },
                    { 57, new DateTime(2025, 10, 9, 18, 30, 0, 0, DateTimeKind.Unspecified), 44.2f, "2.3.3", new DateTime(2025, 10, 9, 16, 45, 0, 0, DateTimeKind.Unspecified), 1, 170000f, 2 },
                    { 58, new DateTime(2025, 10, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), 31.8f, "1.3.1", new DateTime(2025, 10, 5, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, 122000f, 3 },
                    { 59, new DateTime(2025, 10, 10, 12, 15, 0, 0, DateTimeKind.Unspecified), 29.4f, "2.4.1", new DateTime(2025, 10, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 113000f, 3 },
                    { 60, new DateTime(2025, 10, 4, 11, 10, 0, 0, DateTimeKind.Unspecified), 44.6f, "1.4.1", new DateTime(2025, 10, 4, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, 172000f, 4 },
                    { 61, new DateTime(2025, 10, 7, 16, 45, 0, 0, DateTimeKind.Unspecified), 41.3f, "2.5.1", new DateTime(2025, 10, 7, 14, 20, 0, 0, DateTimeKind.Unspecified), 1, 159000f, 4 }
                });

            migrationBuilder.InsertData(
                table: "VehiclePerMonths",
                columns: new[] { "VehicleMonthId", "AmountPaid", "PeriodId", "TotalCost", "TotalEnergy", "TotalSessions", "VehicleId" },
                values: new object[,]
                {
                    { 1, 780000f, 19, 780000f, 202.3f, 5, 1 },
                    { 2, 671000f, 19, 671000f, 174.3f, 4, 2 },
                    { 3, 358000f, 19, 358000f, 93.2f, 3, 3 },
                    { 4, 637000f, 19, 637000f, 165.4f, 4, 4 },
                    { 5, 519000f, 19, 519000f, 134.6f, 3, 5 },
                    { 6, 777000f, 20, 777000f, 201.5f, 5, 1 },
                    { 7, 702000f, 20, 702000f, 182.4f, 4, 2 },
                    { 8, 362000f, 20, 362000f, 94.3f, 3, 3 },
                    { 9, 645000f, 20, 645000f, 167.5f, 4, 4 },
                    { 10, 200000f, 20, 534000f, 138.4f, 3, 5 },
                    { 11, 777000f, 21, 777000f, 201.5f, 5, 1 },
                    { 12, 702000f, 21, 702000f, 182.4f, 4, 2 },
                    { 13, 0f, 21, 362000f, 94.3f, 3, 3 },
                    { 14, 645000f, 21, 645000f, 167.5f, 4, 4 },
                    { 16, 0f, 22, 450000f, 116.7f, 3, 1 },
                    { 17, 0f, 22, 358000f, 93.1f, 2, 2 },
                    { 18, 0f, 22, 331000f, 85.9f, 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ChargingSessions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VehiclePerMonths",
                keyColumn: "VehicleMonthId",
                keyValue: 18);
        }
    }
}
