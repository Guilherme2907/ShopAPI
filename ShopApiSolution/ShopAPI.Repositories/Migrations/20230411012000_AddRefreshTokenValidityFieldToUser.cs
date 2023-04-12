using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAPI.Repositories.Migrations
{
    public partial class AddRefreshTokenValidityFieldToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenValidity",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenValidity",
                table: "AspNetUsers");
        }
    }
}
