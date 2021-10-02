using Microsoft.EntityFrameworkCore.Migrations;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class Renamed_Order_To_OrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Sku);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemSavedOrder");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SavedOrderId = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_Orders_SavedOrders_SavedOrderId",
                        column: x => x.SavedOrderId,
                        principalTable: "SavedOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SavedOrderId",
                table: "Orders",
                column: "SavedOrderId");
        }
    }
}
