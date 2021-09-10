using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProjectDemoData.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 23, 9, 13, 5, 717, DateTimeKind.Local).AddTicks(470), "suitable for men and women", "Vanz" },
                    { 2, new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6697), "suitable for men and women", "Convert" },
                    { 3, new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6779), "suitable for men and women", "Nike" },
                    { 4, new DateTime(2021, 8, 23, 9, 13, 5, 718, DateTimeKind.Local).AddTicks(6785), "suitable for men and women", "Biti" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
