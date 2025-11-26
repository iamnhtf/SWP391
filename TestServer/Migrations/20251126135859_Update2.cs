using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PackageSubscriptions");

            migrationBuilder.RenameColumn(
                name: "HoldMinutesAtPurchase",
                table: "PackageSubscriptions",
                newName: "ReservationMinutesAtPurchase");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PackageSubscriptions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationMinutesAtPurchase",
                table: "PackageSubscriptions",
                newName: "HoldMinutesAtPurchase");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PackageSubscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PackageSubscriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
