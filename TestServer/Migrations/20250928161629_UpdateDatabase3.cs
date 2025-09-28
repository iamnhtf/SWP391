using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Power",
                table: "ChargingPorts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.2",
                column: "Power",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.1",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.3",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.2",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.3",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.1",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.2",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.3",
                column: "Power",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.1",
                column: "Power",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.2",
                column: "Power",
                value: 22);

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.3",
                column: "Power",
                value: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Power",
                table: "ChargingPorts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.2.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.3.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.4.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.6.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "1.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.10.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.2.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.3.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.4.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.6.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.8.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "2.9.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.10.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.2.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.3.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.4.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.6.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.8.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "3.9.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.1.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.10.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.2.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.3.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.4.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.6.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.7.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.8.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "4.9.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.10.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.2.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.3.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.2",
                column: "Power",
                value: "15 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.4.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.6.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.8.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "5.9.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.10.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.2.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.3.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.4.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.6.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.8.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "6.9.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.1.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.10.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.2.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.3.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.4.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.5.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.1",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.6.3",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.2",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.7.3",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.1",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.2",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.8.3",
                column: "Power",
                value: "7 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.1",
                column: "Power",
                value: "50 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.2",
                column: "Power",
                value: "22 kW");

            migrationBuilder.UpdateData(
                table: "ChargingPorts",
                keyColumn: "Id",
                keyValue: "7.9.3",
                column: "Power",
                value: "7 kW");
        }
    }
}
