using Microsoft.EntityFrameworkCore.Migrations;

namespace E_HealthCare_API.Migrations
{
    public partial class cartmodelitemsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "CartItems");
        }
    }
}
