using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecommerco_proj.Migrations
{
    /// <inheritdoc />
    public partial class cart3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "634c76b4-3a9c-4560-a594-db1249d28cbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4b89c5a-7f5e-45ff-9530-fba06a64ab63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e11a74db-aadd-4e5e-a76d-68c09a242530", null, "User", "USER" },
                    { "f89e4267-c366-4fde-b96c-2bae54234556", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "634c76b4-3a9c-4560-a594-db1249d28cbc", null, "Admin", "ADMIN" },
                    { "e4b89c5a-7f5e-45ff-9530-fba06a64ab63", null, "User", "USER" }
                });
        }
    }
}
