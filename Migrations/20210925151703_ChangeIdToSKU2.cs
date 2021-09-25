using Microsoft.EntityFrameworkCore.Migrations;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class ChangeIdToSKU2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "SKU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SKU",
                table: "Products",
                newName: "Id");
        }
    }
}
