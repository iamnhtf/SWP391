using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestServer.Migrations
{
    /// <inheritdoc />
    public partial class AddressStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.846289725256499, "778 Nguyen Van Qua, Dong Hung Thuan Ward, District 12, Ho Chi Minh City", 106.63358659588795, "Parking lot S778 Nguyen Van Qua" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.778019786911162, "Basement B3, Léman Luxury Apartments, 117 Nguyễn Đình Chiểu, Ward 6, District 3, Ho Chi Minh City", 106.68989161819898, "Léman Luxury Apartments" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.759974990301892, "243 Tan Hoa Dong, Ward 14, District 6, Ho Chi Minh City", 106.62537124357758, "Summer Square Apartment Complex" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.726400325147486, "Basement B2, 15 Nguyen Luong Bang, Tan Phu Ward, District 7, Ho Chi Minh City", 106.72395755358133, "Golden King Apartment Complex" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.744180504637178, "71 Tran Trong Cung, Tan Thuan Dong Ward, District 7, Ho Chi Minh City", 106.73212781504205, "TTTM VinCom+ Nam Long" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.738380975551181, "54 Nguyen Thi Thap, Binh Thuan Ward, District 7, Ho Chi Minh City", 106.72723544339814, "VinFast - Chevrolet Phu My Hung Car Dealership" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.721662104756106, "Green View, Tân Phú Ward, District 7, Ho Chi Minh City", 106.72691002973274, "Green View Apartment Complex" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.7944, "Vincom Landmark 81, Binh Thanh District, Ho Chi Minh City", 106.72150000000001, "Landmark 81 Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.801299999999999, "Vincom Cong Hoa, Tan Binh District, Ho Chi Minh City", 106.65000000000001, "Cong Hoa Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.7721, "Vincom Ba Thang Hai, District 10, Ho Chi Minh City", 106.6678, "Ba Thang Hai Charging Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.779500000000001, "Leman Luxury Building, District 3, Ho Chi Minh City", 106.6888, "Leman Luxury Apartments Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.748200000000001, "Nguyen Van Luong Street, District 6, Ho Chi Minh City", 106.6361, "Huynh Hieu Thien Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.735799999999999, "Hoang Quoc Viet Street, District 7, Ho Chi Minh City", 106.7251, "Sky89 Station" });

            migrationBuilder.UpdateData(
                table: "ChargingStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Location", "Longitude", "Name" },
                values: new object[] { 10.7765, "Le Thanh Ton Street, District 1, Ho Chi Minh City", 106.7032, "Center Dong Khoi Station" });
        }
    }
}
