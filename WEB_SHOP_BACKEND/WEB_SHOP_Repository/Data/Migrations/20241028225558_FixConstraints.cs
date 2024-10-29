using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_SHOP_API.Data.Migrations
{
    public partial class FixConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductBrands",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductBrands");
        }
    }
}
