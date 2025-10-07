using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInfoVehiclePerMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePerMonths_Customers_Id",
                table: "VehiclePerMonths");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePerMonths_Id",
                table: "VehiclePerMonths");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VehiclePerMonths");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehiclePerMonths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_VehicleId",
                table: "VehiclePerMonths",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePerMonths_Vehicles_VehicleId",
                table: "VehiclePerMonths",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePerMonths_Vehicles_VehicleId",
                table: "VehiclePerMonths");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePerMonths_VehicleId",
                table: "VehiclePerMonths");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehiclePerMonths");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "VehiclePerMonths",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_Id",
                table: "VehiclePerMonths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePerMonths_Customers_Id",
                table: "VehiclePerMonths",
                column: "Id",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
