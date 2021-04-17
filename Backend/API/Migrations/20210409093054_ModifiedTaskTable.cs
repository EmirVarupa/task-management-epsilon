using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ModifiedTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Task",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Task",
                newName: "DeletedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_PriorityId",
                table: "Task",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Priorities_PriorityId",
                table: "Task",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Priorities_PriorityId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_PriorityId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Task",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Task",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
