using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PaymentTransactions",
                keyColumn: "Id",
                keyValue: 54);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentTransactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "CustomerId", "OrderInfo", "ResponseCode", "TransactionStatus", "VehicleId", "VehicleMonthId" },
                values: new object[,]
                {
                    { 16, 500383.0, new DateTime(2025, 9, 2, 8, 32, 0, 0, DateTimeKind.Utc), "k825tKKC1aex70inOKxd2lQpJUD3", "Payment for Nissan Leaf (Aug-2025)", "00", "00", 3, 16 },
                    { 33, 527581.0, new DateTime(2025, 10, 3, 10, 12, 0, 0, DateTimeKind.Utc), "l1sufzGdTdYyIZJ8c0VypXyhmR02", "Payment for BYD Seal (Sep-2025)", "00", "00", 8, 34 },
                    { 36, 269228.0, new DateTime(2025, 10, 1, 12, 1, 0, 0, DateTimeKind.Utc), "JEBFEGirUGhlgQadF4xRrofZo9X2", "Payment for Volvo EX30 (Sep-2025)", "00", "00", 11, 37 },
                    { 42, 519563.0, new DateTime(2025, 11, 2, 10, 3, 0, 0, DateTimeKind.Utc), "k825tKKC1aex70inOKxd2lQpJUD3", "Payment for Kia EV6 (Oct-2025)", "00", "00", 5, 44 },
                    { 49, 157070.0, new DateTime(2025, 11, 10, 9, 0, 0, 0, DateTimeKind.Utc), "k825tKKC1aex70inOKxd2lQpJUD3", "Payment for Tesla Model 3 (Nov-2025)", "00", "00", 1, 53 },
                    { 50, 180237.0, new DateTime(2025, 11, 10, 9, 5, 0, 0, DateTimeKind.Utc), "k825tKKC1aex70inOKxd2lQpJUD3", "Payment for VinFast VF 8 (Nov-2025)", "00", "00", 2, 54 },
                    { 51, 317971.0, new DateTime(2025, 11, 11, 14, 20, 0, 0, DateTimeKind.Utc), "k825tKKC1aex70inOKxd2lQpJUD3", "Payment for Hyundai Ioniq 5 (Nov-2025)", "00", "00", 4, 56 },
                    { 52, 138888.0, new DateTime(2025, 11, 11, 16, 0, 0, 0, DateTimeKind.Utc), "l1sufzGdTdYyIZJ8c0VypXyhmR02", "Payment for Tesla Model Y (Nov-2025)", "00", "00", 6, 58 },
                    { 53, 109247.0, new DateTime(2025, 11, 12, 8, 0, 0, 0, DateTimeKind.Utc), "l1sufzGdTdYyIZJ8c0VypXyhmR02", "Payment for Ford F-150 Lightning (Nov-2025)", "00", "00", 9, 61 },
                    { 54, 158178.0, new DateTime(2025, 11, 12, 9, 30, 0, 0, DateTimeKind.Utc), "JEBFEGirUGhlgQadF4xRrofZo9X2", "Payment for Audi e-tron GT (Nov-2025)", "00", "00", 12, 64 }
                });
        }
    }
}
