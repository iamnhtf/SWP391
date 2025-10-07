using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangNameDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclePerMonths",
                columns: table => new
                {
                    VehicleMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(type: "varchar(100)", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    TotalSessions = table.Column<int>(type: "int", nullable: false),
                    TotalEnergy = table.Column<float>(type: "float", nullable: false),
                    AmountPaid = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePerMonths", x => x.VehicleMonthId);
                    table.ForeignKey(
                        name: "FK_VehiclePerMonths_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehiclePerMonths_MonthlyPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "MonthlyPeriods",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_Id",
                table: "VehiclePerMonths",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePerMonths_PeriodId",
                table: "VehiclePerMonths",
                column: "PeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclePerMonths");
        }
    }
}
