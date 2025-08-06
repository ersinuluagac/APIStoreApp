using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61b16197-3799-40d3-b382-7f6f5d29e2d6", "8d068ba8-2a03-467f-8997-32629b7e84c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd6d8dbc-f202-4619-9c38-099a01cfb2cc", "69ba6602-f436-455f-ab63-e0f724f45c53", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8297e27-87a0-4c30-a7e5-a1b4c5e68e6e", "6f91a60d-7cdb-4662-afbe-f0551a0227c5", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b16197-3799-40d3-b382-7f6f5d29e2d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd6d8dbc-f202-4619-9c38-099a01cfb2cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8297e27-87a0-4c30-a7e5-a1b4c5e68e6e");
        }
    }
}
