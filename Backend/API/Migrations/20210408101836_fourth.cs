using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "LastName",
                "User",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "FirstName",
                "User",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Task",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                "Archived",
                "Task",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "CategoryId",
                "Task",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                "CreationDate",
                "Task",
                "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                "EndDate",
                "Task",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "Priority",
                "Task",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "StartDate",
                "Task",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "Status",
                "Task",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "Title",
                "Task",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                "UserId",
                "Task",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                "Title",
                "Category",
                "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                "IX_Task_CategoryId",
                "Task",
                "CategoryId");

            migrationBuilder.CreateIndex(
                "IX_Task_UserId",
                "Task",
                "UserId");

            migrationBuilder.AddForeignKey(
                "FK_Task_Category_CategoryId",
                "Task",
                "CategoryId",
                "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Task_User_UserId",
                "Task",
                "UserId",
                "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Task_Category_CategoryId",
                "Task");

            migrationBuilder.DropForeignKey(
                "FK_Task_User_UserId",
                "Task");

            migrationBuilder.DropIndex(
                "IX_Task_CategoryId",
                "Task");

            migrationBuilder.DropIndex(
                "IX_Task_UserId",
                "Task");

            migrationBuilder.DropColumn(
                "Archived",
                "Task");

            migrationBuilder.DropColumn(
                "CategoryId",
                "Task");

            migrationBuilder.DropColumn(
                "CreationDate",
                "Task");

            migrationBuilder.DropColumn(
                "EndDate",
                "Task");

            migrationBuilder.DropColumn(
                "Priority",
                "Task");

            migrationBuilder.DropColumn(
                "StartDate",
                "Task");

            migrationBuilder.DropColumn(
                "Status",
                "Task");

            migrationBuilder.DropColumn(
                "Title",
                "Task");

            migrationBuilder.DropColumn(
                "UserId",
                "Task");

            migrationBuilder.AlterColumn<string>(
                "LastName",
                "User",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                "FirstName",
                "User",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Task",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                "Title",
                "Category",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}