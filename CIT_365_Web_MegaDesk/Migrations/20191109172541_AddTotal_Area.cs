using Microsoft.EntityFrameworkCore.Migrations;

namespace CIT_365_Web_MegaDesk.Migrations
{
    public partial class AddTotal_Area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeskTopArea",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "QuoteTotal",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeskTopArea",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "QuoteTotal",
                table: "Quote");
        }
    }
}
