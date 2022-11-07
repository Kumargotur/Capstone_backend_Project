using Microsoft.EntityFrameworkCore.Migrations;

namespace E_HealthCare_API.Migrations
{
    public partial class cartitemmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartID",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "CartItems",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                newName: "IX_CartItems_UserID");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Users_UserID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CartItems",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_UserID",
                table: "CartItems",
                newName: "IX_CartItems_CartID");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OwnerID",
                table: "Cart",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
