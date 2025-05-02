using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBL3.Migrations
{
    /// <inheritdoc />
    public partial class AdminSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "Gender", "IsActive", "Password", "PhoneNumber", "RoleId", "UpdatedAt", "Username" },
                values: new object[] { 4, "Hà Nội", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin System", 0, true, "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==", "0987654321", 1, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
