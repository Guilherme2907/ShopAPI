using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAPI.Repositories.Migrations
{
    public partial class DeleteOrderIdFromPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "payments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
