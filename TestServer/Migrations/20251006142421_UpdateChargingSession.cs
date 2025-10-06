using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChargingSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vehicleId",
                table: "ChargingSessions",
                newName: "VehicleId");

            migrationBuilder.AlterColumn<string>(
                name: "PortId",
                table: "ChargingSessions",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PricePerKWh = table.Column<float>(type: "float", nullable: false),
                    PenaltyFeePerMinute = table.Column<float>(type: "float", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_PortId",
                table: "ChargingSessions",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_PriceId",
                table: "ChargingSessions",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_VehicleId",
                table: "ChargingSessions",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_ChargingPorts_PortId",
                table: "ChargingSessions",
                column: "PortId",
                principalTable: "ChargingPorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_PriceTable_PriceId",
                table: "ChargingSessions",
                column: "PriceId",
                principalTable: "PriceTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_Vehicles_VehicleId",
                table: "ChargingSessions",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_ChargingPorts_PortId",
                table: "ChargingSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_PriceTable_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_Vehicles_VehicleId",
                table: "ChargingSessions");

            migrationBuilder.DropTable(
                name: "PriceTable");

            migrationBuilder.DropIndex(
                name: "IX_ChargingSessions_PortId",
                table: "ChargingSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChargingSessions_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChargingSessions_VehicleId",
                table: "ChargingSessions");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "ChargingSessions",
                newName: "vehicleId");

            migrationBuilder.AlterColumn<int>(
                name: "PortId",
                table: "ChargingSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
