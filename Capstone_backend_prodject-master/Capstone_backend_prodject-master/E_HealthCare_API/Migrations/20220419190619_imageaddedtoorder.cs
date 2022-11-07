using Microsoft.EntityFrameworkCore.Migrations;

namespace E_HealthCare_API.Migrations
{
    public partial class imageaddedtoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Orders");
        }
    }
}
