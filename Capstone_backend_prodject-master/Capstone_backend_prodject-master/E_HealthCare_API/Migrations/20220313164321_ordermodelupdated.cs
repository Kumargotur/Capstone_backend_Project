using Microsoft.EntityFrameworkCore.Migrations;

namespace E_HealthCare_API.Migrations
{
    public partial class ordermodelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                newName: "IX_Orders_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ordernumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ordernumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
