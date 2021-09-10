using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProjectDemoData.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"),
                column: "ConcurrencyStamp",
                value: "26df8c51-8472-4c2f-bfc2-6e90359391df");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a9921d2-f75c-4043-9c97-960a3d9864b1", "AQAAAAEAACcQAAAAEDMLH7fRrbf0KVXiD4RMGHO78xCBFI2GZYNOLNrLxOlVUsfdkYxeZ1Yl+fnxStnZAA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 6, 8, 40, 5, 90, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 6, 8, 40, 5, 91, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 6, 8, 40, 5, 91, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 6, 8, 40, 5, 91, DateTimeKind.Local).AddTicks(490));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"),
                column: "ConcurrencyStamp",
                value: "8b1aecaa-9ec4-4fe5-87f1-0a00b3bd6af9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b7b3219-c256-456a-9991-613d91b8c815", "AQAAAAEAACcQAAAAELUURfTtfBe7DK6ixRGQYliWkfuBkgsBwk0yP900PVc6Hdm+oTILZciNeYWDYvMefw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 33, 9, 241, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 33, 9, 242, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 33, 9, 242, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 33, 9, 242, DateTimeKind.Local).AddTicks(5734));
        }
    }
}
