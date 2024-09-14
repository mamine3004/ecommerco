using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecommerco_proj.Migrations
{
    /// <inheritdoc />
    public partial class cart4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e11a74db-aadd-4e5e-a76d-68c09a242530");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f89e4267-c366-4fde-b96c-2bae54234556");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b72d778-cacd-4633-95e8-298110ccfcdd", null, "Admin", "ADMIN" },
                    { "b7dff641-d9fd-414b-83b1-5e23b7d6d6bb", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b72d778-cacd-4633-95e8-298110ccfcdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7dff641-d9fd-414b-83b1-5e23b7d6d6bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e11a74db-aadd-4e5e-a76d-68c09a242530", null, "User", "USER" },
                    { "f89e4267-c366-4fde-b96c-2bae54234556", null, "Admin", "ADMIN" }
                });
        }
    }
}
