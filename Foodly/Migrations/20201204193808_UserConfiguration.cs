using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodly.Migrations
{
    public partial class UserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhoto",
                table: "Users",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePhotoData",
                table: "Users",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoData",
                table: "Users");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePhoto",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
