using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class newTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Products_ProductId",
                table: "OrderedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts");

            migrationBuilder.RenameTable(
                name: "OrderedProducts",
                newName: "Order_Products");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_ProductId",
                table: "Order_Products",
                newName: "IX_Order_Products_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_OrderId",
                table: "Order_Products",
                newName: "IX_Order_Products_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Products",
                table: "Order_Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Orders_OrderId",
                table: "Order_Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Products_ProductId",
                table: "Order_Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Orders_OrderId",
                table: "Order_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Products_ProductId",
                table: "Order_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Products",
                table: "Order_Products");

            migrationBuilder.RenameTable(
                name: "Order_Products",
                newName: "OrderedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Products_ProductId",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Products_OrderId",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Orders_OrderId",
                table: "OrderedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Products_ProductId",
                table: "OrderedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
