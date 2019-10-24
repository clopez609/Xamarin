using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xamarin.Web.Migrations
{
    public partial class updateCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Courses",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Courses",
                newName: "Day");

            migrationBuilder.AddColumn<DateTime>(
                name: "Hour",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
