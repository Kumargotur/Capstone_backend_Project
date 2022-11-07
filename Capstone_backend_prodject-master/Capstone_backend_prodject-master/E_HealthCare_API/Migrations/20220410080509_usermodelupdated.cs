using Microsoft.EntityFrameworkCore.Migrations;

namespace E_HealthCare_API.Migrations
{
    public partial class usermodelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accountnumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "funds",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accountnumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "funds",
                table: "Users");
        }
    }
}
