using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class ChargingSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChargingSessionId",
                table: "ChargingPoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChargingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicleId = table.Column<int>(type: "int", nullable: false),
                    PortId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnergyConsumed = table.Column<float>(type: "float", nullable: false),
                    TotalCost = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingSessions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "1.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "2.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "3.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "4.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "5.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "6.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.1",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.10",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.2",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.3",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.4",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.5",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.6",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.7",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.8",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChargingPoints",
                keyColumn: "Id",
                keyValue: "7.9",
                column: "ChargingSessionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPoints_ChargingSessionId",
                table: "ChargingPoints",
                column: "ChargingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingPoints_ChargingSessions_ChargingSessionId",
                table: "ChargingPoints",
                column: "ChargingSessionId",
                principalTable: "ChargingSessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingPoints_ChargingSessions_ChargingSessionId",
                table: "ChargingPoints");

            migrationBuilder.DropTable(
                name: "ChargingSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChargingPoints_ChargingSessionId",
                table: "ChargingPoints");

            migrationBuilder.DropColumn(
                name: "ChargingSessionId",
                table: "ChargingPoints");
        }
    }
}
