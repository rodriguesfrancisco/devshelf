using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevShelf.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnsToUserBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReadingStatus",
                table: "UserBook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "ReadingStatus",
                table: "UserBook");
        }
    }
}
