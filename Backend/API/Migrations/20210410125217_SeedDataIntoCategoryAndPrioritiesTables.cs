using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SeedDataIntoCategoryAndPrioritiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Title" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Education" },
                    { 3, "Uncategorized" }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "Name" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 3);
        }
    }
}
