using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using PavluqueOrderGenerator.Model;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class Orders_to_jsonb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderItem");

            migrationBuilder.AddColumn<List<OrderItem>>(
                name: "Orders",
                table: "Orders",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orders",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderOrderItem",
                columns: table => new
                {
                    OrdersSku = table.Column<string>(type: "text", nullable: false),
                    SavedOrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderItem", x => new { x.OrdersSku, x.SavedOrdersId });
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_OrderItems_OrdersSku",
                        column: x => x.OrdersSku,
                        principalTable: "OrderItems",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_Orders_SavedOrdersId",
                        column: x => x.SavedOrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItem_SavedOrdersId",
                table: "OrderOrderItem",
                column: "SavedOrdersId");
        }
    }
}
