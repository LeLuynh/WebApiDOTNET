using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProjectDemoData.Migrations
{
    public partial class SeedDataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"), "8b1aecaa-9ec4-4fe5-87f1-0a00b3bd6af9", "Administraction role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"), new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"), 0, "2b7b3219-c256-456a-9991-613d91b8c815", new DateTime(2019, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin-luynh@gmail.com", true, "Le Luynh", false, null, "admin-luynh@gmail.com", "admin", "AQAAAAEAACcQAAAAELUURfTtfBe7DK6ixRGQYliWkfuBkgsBwk0yP900PVc6Hdm+oTILZciNeYWDYvMefw==", null, false, "", false, "admin" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"), new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d2de0ea-abc4-4af6-b546-2dd26813dec2"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 22, 53, 269, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 22, 53, 270, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 22, 53, 270, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 16, 22, 53, 270, DateTimeKind.Local).AddTicks(1138));
        }
    }
}
