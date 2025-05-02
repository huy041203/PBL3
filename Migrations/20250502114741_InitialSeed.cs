using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PBL3.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "Gender", "IsActive", "Password", "PhoneNumber", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, "Hà Nội", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor1@gmail.com", "Nguyễn Văn A", 0, true, "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==", "0912345678", 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor1" },
                    { 2, "Đà Nẵng", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor2@gmail.com", "Trần Thị B", 1, true, "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==", "0923456789", 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor2" },
                    { 3, "Hồ Chí Minh", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor3@gmail.com", "Lê Văn C", 0, true, "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==", "0934567890", 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor3" }
                });

            migrationBuilder.InsertData(
                table: "BacSis",
                columns: new[] { "Id", "CCCD", "DiaChi", "DiemDanhGia", "GiaKham", "GioiTinh", "HoTen", "IsActive", "KhoaId", "MieuTa", "NgaySinh", "PhongKham", "SoDienThoai", "SoNamKinhNghiem", "UserId" },
                values: new object[,]
                {
                    { 1, "123456789012", "Hà Nội", 4.7999999999999998, 200000m, 0, "Nguyễn Văn A", true, 1, "Bác sĩ chuyên khoa Nội với 10 năm kinh nghiệm", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.101", "0912345678", 10, 1 },
                    { 2, "234567890123", "Đà Nẵng", 4.9000000000000004, 250000m, 1, "Trần Thị B", true, 4, "Bác sĩ chuyên khoa Sản với 8 năm kinh nghiệm", new DateTime(1988, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.205", "0923456789", 8, 2 },
                    { 3, "345678901234", "Hồ Chí Minh", 4.7000000000000002, 300000m, 0, "Lê Văn C", true, 3, "Bác sĩ chuyên khoa Nhi với 15 năm kinh nghiệm", new DateTime(1980, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.307", "0934567890", 15, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BacSis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BacSis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BacSis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
