using Microsoft.EntityFrameworkCore.Migrations;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class addedDbContexts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductPrint_PrintId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_TypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrint",
                table: "ProductPrint");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "ProductPrint",
                newName: "ProductPrints");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrints",
                table: "ProductPrints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductPrints_PrintId",
                table: "Products",
                column: "PrintId",
                principalTable: "ProductPrints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductPrints_PrintId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_TypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrints",
                table: "ProductPrints");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductPrints",
                newName: "ProductPrint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrint",
                table: "ProductPrint",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductPrint_PrintId",
                table: "Products",
                column: "PrintId",
                principalTable: "ProductPrint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
