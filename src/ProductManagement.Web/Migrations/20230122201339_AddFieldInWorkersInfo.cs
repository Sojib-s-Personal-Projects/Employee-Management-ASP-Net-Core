using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Web.Migrations
{
    public partial class AddFieldInWorkersInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PriceConfirmed",
                table: "WorkersInformation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceConfirmed",
                table: "WorkersInformation");
        }
    }
}
