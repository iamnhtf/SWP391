using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargingSessions_PriceTables_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChargingSessions_PriceId",
                table: "ChargingSessions");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "ChargingSessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "ChargingSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChargingSessions_PriceId",
                table: "ChargingSessions",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargingSessions_PriceTables_PriceId",
                table: "ChargingSessions",
                column: "PriceId",
                principalTable: "PriceTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
