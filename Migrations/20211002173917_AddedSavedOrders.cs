using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PavluqueOrderGenerator.Migrations
{
    public partial class AddedSavedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "SavedOrderId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Sku");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SavedOrderId",
                table: "Orders",
                column: "SavedOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SavedOrders_SavedOrderId",
                table: "Orders",
                column: "SavedOrderId",
                principalTable: "SavedOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SavedOrders_SavedOrderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "SavedOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SavedOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SavedOrderId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Sku");
        }
    }
}
