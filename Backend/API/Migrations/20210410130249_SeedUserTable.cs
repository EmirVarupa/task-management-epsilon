using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SeedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ajna", "Fetic" },
                    { 2, "Harun", "Smaka" },
                    { 3, "Dzenan", "Bejdic" },
                    { 4, "Emir", "Varupa" },
                    { 5, "Adis", "Skender" },
                    { 6, "Hana", "Sehic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 6);
        }
    }
}
