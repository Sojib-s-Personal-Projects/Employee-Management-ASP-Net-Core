using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Web.Migrations
{
    public partial class WorkerEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Workers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Workers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000001L,
                column: "Id",
                value: new Guid("13530e69-aeb3-4a44-b6a0-714546093fe7"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000002L,
                column: "Id",
                value: new Guid("2fa3a5d2-c1f9-48a8-9ce4-cc05c3b739ae"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000003L,
                column: "Id",
                value: new Guid("9fc6abea-0d6d-4168-b147-549f2a64a174"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000004L,
                column: "Id",
                value: new Guid("da27fb57-9979-4ecc-baaa-d329663d84c4"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000005L,
                column: "Id",
                value: new Guid("13bdc36d-4439-4973-86bd-3297ea07b83d"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000006L,
                column: "Id",
                value: new Guid("28923949-c440-42e5-a0ce-d223ca37b09c"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000007L,
                column: "Id",
                value: new Guid("f0c01180-6812-408d-ac9f-f062afd88b42"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000008L,
                column: "Id",
                value: new Guid("84b84d3f-6502-4f0a-8987-ae0a25f851f0"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000009L,
                column: "Id",
                value: new Guid("be8fe95c-6556-4bc4-b0fe-d604485d1655"));

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000010L,
                column: "Id",
                value: new Guid("c1b2e030-a264-4d50-814b-2bcba273efe0"));
        }
    }
}
