using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Infrastructure.Migrations
{
    public partial class FoodPriceMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Price_Value",
                table: "Foods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
