using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class Renamed_SavedOrder_To_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemSavedOrder");

            migrationBuilder.DropTable(
                name: "SavedOrders");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

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
                        name: "FK_OrderOrderItem_Order_SavedOrdersId",
                        column: x => x.SavedOrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_OrderItems_OrdersSku",
                        column: x => x.OrdersSku,
                        principalTable: "OrderItems",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItem_SavedOrdersId",
                table: "OrderOrderItem",
                column: "SavedOrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderOrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "SavedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemSavedOrder",
                columns: table => new
                {
                    OrdersSku = table.Column<string>(type: "text", nullable: false),
                    SavedOrdersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemSavedOrder", x => new { x.OrdersSku, x.SavedOrdersId });
                    table.ForeignKey(
                        name: "FK_OrderItemSavedOrder_OrderItems_OrdersSku",
                        column: x => x.OrdersSku,
                        principalTable: "OrderItems",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemSavedOrder_SavedOrders_SavedOrdersId",
                        column: x => x.SavedOrdersId,
                        principalTable: "SavedOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSavedOrder_SavedOrdersId",
                table: "OrderItemSavedOrder",
                column: "SavedOrdersId");
        }
    }
}
