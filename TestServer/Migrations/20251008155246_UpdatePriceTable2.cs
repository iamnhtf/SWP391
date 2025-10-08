using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PriceTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PriceTables",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PriceTables");
        }
    }
}
