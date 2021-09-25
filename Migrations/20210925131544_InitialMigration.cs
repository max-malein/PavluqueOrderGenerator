using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPrint",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SkuCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SkuCode = table.Column<string>(type: "text", nullable: true),
                    Male = table.Column<bool>(type: "boolean", nullable: false),
                    Child = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TypeId = table.Column<string>(type: "text", nullable: true),
                    PrintId = table.Column<string>(type: "text", nullable: true),
                    Sizes = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductPrint_PrintId",
                        column: x => x.PrintId,
                        principalTable: "ProductPrint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PrintId",
                table: "Products",
                column: "PrintId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductPrint");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
