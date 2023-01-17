using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Web.Migrations
{
    public partial class UpdateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Roll",
                table: "WorkersInformation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_WorkersInformation_Roll",
                table: "WorkersInformation",
                column: "Roll",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersInformation_Workers_Roll",
                table: "WorkersInformation",
                column: "Roll",
                principalTable: "Workers",
                principalColumn: "Roll",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkersInformation_Workers_Roll",
                table: "WorkersInformation");

            migrationBuilder.DropIndex(
                name: "IX_WorkersInformation_Roll",
                table: "WorkersInformation");

            migrationBuilder.DropColumn(
                name: "Roll",
                table: "WorkersInformation");
        }
    }
}
