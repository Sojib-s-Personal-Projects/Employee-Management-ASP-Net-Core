using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Web.Data.Migrations
{
    public partial class AddWorkersTableSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Roll", "DateOfBirth", "FathersName", "Id", "MothersName", "Name", "PermanentDistrict", "PostName", "Quota", "User" },
                values: new object[,]
                {
                    { 11000001L, new DateTime(1992, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABDUL BATEN SARKER", new Guid("13530e69-aeb3-4a44-b6a0-714546093fe7"), "SALINA AKTER", "MD ISRAFIL SORKER", "Munshiganj", "Stenographer-Cum-Computer Operator", "Ansar-VDP", "11LQWESM" },
                    { 11000002L, new DateTime(1993, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD. ABDUL GONI", new Guid("2fa3a5d2-c1f9-48a8-9ce4-cc05c3b739ae"), "HASINA AKTHER", "SYFUL ISLAM", "Kishorganj", "Stenographer-Cum-Computer Operator", "Physically Handicapped", "146DK6YZ" },
                    { 11000003L, new DateTime(1996, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD ALIMUDDIN MOLLA", new Guid("9fc6abea-0d6d-4168-b147-549f2a64a174"), "SEFALI BEGUM", "SUJAN", "Rajbari", "Stenographer-Cum-Computer Operator", "Non Quota", "16ZHEPC4" },
                    { 11000004L, new DateTime(1994, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD. ENAMUL HAQUE KHAN", new Guid("da27fb57-9979-4ecc-baaa-d329663d84c4"), "RINA BEGUM", "SUBARNA AKHTER", "Gopalganj", "Stenographer-Cum-Computer Operator ", "Non Quota", "1718Q6MA" },
                    { 11000005L, new DateTime(1991, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIAKOT ALI", new Guid("13bdc36d-4439-4973-86bd-3297ea07b83d"), "RASIDA BEGUM", "LUTFOR RAHMAN", " Rajbari", "Stenographer-Cum-Computer Operator ", "Ansar-VDP", "17NUT467" },
                    { 11000006L, new DateTime(1991, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD. NAOSHADUL HAQUE", new Guid("28923949-c440-42e5-a0ce-d223ca37b09c"), "MOST. KHALEDA BIBI", "MOST. MAHBUBA KHANOM", "Naogaon", "Stenographer-Cum-Computer Operator ", "Non Quota", "1BATJVHD" },
                    { 11000007L, new DateTime(1992, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "NARAYAN CHANDRA SARKAR", new Guid("f0c01180-6812-408d-ac9f-f062afd88b42"), "NANDA RANI SARKAR", "KRISHNO KUMAR SARKAR", "Bogura", "Stenographer-Cum-Computer Operator ", "Non Quota", "1F26E9FU" },
                    { 11000008L, new DateTime(1992, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "NARAYAN KUMAR DAS", new Guid("84b84d3f-6502-4f0a-8987-ae0a25f851f0"), "BASONA RANI DAS", "PROSENJIT KUMAR DAS", "Khulna", "Stenographer-Cum-Computer Operator ", "Non Quota", "1EV6P37Z" },
                    { 11000009L, new DateTime(1990, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD. MOYEN UDDIN", new Guid("be8fe95c-6556-4bc4-b0fe-d604485d1655"), "SHUKHZAN KHATUN", "MD. TAREK AZIZ", "Kushtia", "Stenographer-Cum-Computer Operator ", "Child of Freedom Fighter", "11LQWESM" },
                    { 11000010L, new DateTime(1990, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MONORANJAN KUNDO", new Guid("c1b2e030-a264-4d50-814b-2bcba273efe0"), "ANJANA KUNDO", "ANOUP KUNDO", "Manikganj", "Stenographer-Cum-Computer Operator ", "Non Quota", "1JXCS1TV" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000001L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000002L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000003L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000004L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000005L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000006L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000007L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000008L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000009L);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Roll",
                keyValue: 11000010L);
        }
    }
}
