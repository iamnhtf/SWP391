using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ChargingPortId = table.Column<string>(type: "longtext", nullable: false),
                    ReservedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.3",
                column: "Power",
                value: 450);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.1",
                column: "Power",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.2",
                column: "Power",
                value: 350);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.3",
                column: "Power",
                value: 450);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.3",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.2",
                column: "Power",
                value: 150);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.3",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.1",
                column: "Power",
                value: 30);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.2",
                column: "Power",
                value: 60);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.3",
                column: "Power",
                value: 60);
        }
    }
}
