using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMonthLyPeriodAndUserPerMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyPeriods",
                columns: table => new
                {
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPeriods", x => x.PeriodId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersPerMonths",
                columns: table => new
                {
                    UserMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(type: "varchar(100)", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    TotalSessions = table.Column<int>(type: "int", nullable: false),
                    TotalEnergy = table.Column<float>(type: "float", nullable: false),
                    AmountPaid = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPerMonths", x => x.UserMonthId);
                    table.ForeignKey(
                        name: "FK_UsersPerMonths_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPerMonths_MonthlyPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "MonthlyPeriods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPerMonths_Id",
                table: "UsersPerMonths",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPerMonths_PeriodId",
                table: "UsersPerMonths",
                column: "PeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPerMonths");

            migrationBuilder.DropTable(
                name: "MonthlyPeriods");
        }
    }
}
