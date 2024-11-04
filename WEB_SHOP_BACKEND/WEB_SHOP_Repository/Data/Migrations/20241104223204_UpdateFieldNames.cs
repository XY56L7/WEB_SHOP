using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_SHOP_API.Data.Migrations
{
    public partial class UpdateFieldNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PcitureUrl",
                table: "Products",
                newName: "PictureUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Products",
                newName: "PcitureUrl");
        }
    }
}
