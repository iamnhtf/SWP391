using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEndpoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[] { "k825tKKC1aex70inOKxd2lQpJUD3", "Quận 1, TP.HCM", "nguyenxuanthinh@gmail.com", "Nguyen Xuan Thinh", "0901234567" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "k825tKKC1aex70inOKxd2lQpJUD3");
        }
    }
}
