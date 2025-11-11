using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "JEBFEGirUGhlgQadF4xRrofZo9X2",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "k825tKKC1aex70inOKxd2lQpJUD3",
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "l1sufzGdTdYyIZJ8c0VypXyhmR02",
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");
        }
    }
}
