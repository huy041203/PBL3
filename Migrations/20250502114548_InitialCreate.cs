using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PBL3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaLa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HSDMonth = table.Column<int>(type: "int", nullable: false),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MieuTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GiaThuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BacSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    PhongKham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNamKinhNghiem = table.Column<int>(type: "int", nullable: false),
                    GiaKham = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MieuTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiemDanhGia = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacSis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BacSis_Khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BacSis_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenhNhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SoDienThoaiNguoiThan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    DiUng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomMau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienSuBenh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenhNhans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienYTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiXetNghiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PhongLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaXetNghiem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienYTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVienYTs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichLamViecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BacSiId = table.Column<int>(type: "int", nullable: false),
                    NgayLamViec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoCaDuocKham = table.Column<int>(type: "int", nullable: false),
                    SoSlotDaDat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichLamViecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichLamViecs_BacSis_BacSiId",
                        column: x => x.BacSiId,
                        principalTable: "BacSis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LichHenKhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BacSiId = table.Column<int>(type: "int", nullable: false),
                    BenhNhanId = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiThanhToan = table.Column<int>(type: "int", nullable: false),
                    TrangThaiLichHen = table.Column<int>(type: "int", nullable: false),
                    LyDoKham = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhiKham = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHenKhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichHenKhams_BacSis_BacSiId",
                        column: x => x.BacSiId,
                        principalTable: "BacSis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LichHenKhams_BenhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "BenhNhans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LichLamViecId = table.Column<int>(type: "int", nullable: false),
                    BacSiId = table.Column<int>(type: "int", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    TienKham = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThaiThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiDatLich = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiKham = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_BacSis_BacSiId",
                        column: x => x.BacSiId,
                        principalTable: "BacSis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Slots_LichLamViecs_LichLamViecId",
                        column: x => x.LichLamViecId,
                        principalTable: "LichLamViecs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BanGhiYTes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanId = table.Column<int>(type: "int", nullable: false),
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    BacSiId = table.Column<int>(type: "int", nullable: false),
                    LichHenId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDauKhamThucTe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThucKham = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrieuChung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ChanDoan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KetQuaKham = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DaKhamLamSan = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanGhiYTes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanGhiYTes_BacSis_BacSiId",
                        column: x => x.BacSiId,
                        principalTable: "BacSis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BanGhiYTes_BenhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "BenhNhans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BanGhiYTes_LichHenKhams_LichHenId",
                        column: x => x.LichHenId,
                        principalTable: "LichHenKhams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BanGhiYTes_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChanDoanLamSans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BanGhiYTeId = table.Column<int>(type: "int", nullable: false),
                    TrieuChung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HuyetAp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TinhTrangBenh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NhipTim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhietDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CanNang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChieuCao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChanDoanLamSans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChanDoanLamSans_BanGhiYTes_BanGhiYTeId",
                        column: x => x.BanGhiYTeId,
                        principalTable: "BanGhiYTes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonThuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThuocId = table.Column<int>(type: "int", nullable: false),
                    BenhNhanId = table.Column<int>(type: "int", nullable: false),
                    BanGhiYTeId = table.Column<int>(type: "int", nullable: false),
                    LuuLuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GiaThuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonThuocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonThuocs_BanGhiYTes_BanGhiYTeId",
                        column: x => x.BanGhiYTeId,
                        principalTable: "BanGhiYTes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonThuocs_BenhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "BenhNhans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonThuocs_Thuocs_ThuocId",
                        column: x => x.ThuocId,
                        principalTable: "Thuocs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KetQuaXetNghiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    BanGhiYTeId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDauXetNghiem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThucXetNghiem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoaiXetNghiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BoPhanXetNghiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KetQua = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileKetQua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaXetNghiem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaXetNghiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuaXetNghiems_BanGhiYTes_BanGhiYTeId",
                        column: x => x.BanGhiYTeId,
                        principalTable: "BanGhiYTes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KetQuaXetNghiems_BenhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "BenhNhans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KetQuaXetNghiems_NhanVienYTs_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVienYTs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonThuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonThuocId = table.Column<int>(type: "int", nullable: false),
                    ThuocId = table.Column<int>(type: "int", nullable: false),
                    LieuLuong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    CachDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonThuocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDonThuocs_DonThuocs_DonThuocId",
                        column: x => x.DonThuocId,
                        principalTable: "DonThuocs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietDonThuocs_Thuocs_ThuocId",
                        column: x => x.ThuocId,
                        principalTable: "Thuocs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "Id", "Icon", "IsActive", "MoTa", "TenKhoa" },
                values: new object[,]
                {
                    { 1, "", true, "", "Khoa Nội" },
                    { 2, "", true, "", "Khoa Ngoại" },
                    { 3, "", true, "", "Khoa Nhi" },
                    { 4, "", true, "", "Khoa Sản" },
                    { 5, "", true, "", "Khoa Mắt" },
                    { 6, "", true, "", "Khoa Tai Mũi Họng" },
                    { 7, "", true, "", "Khoa Da liễu" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Admin" },
                    { 2, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Doctor" },
                    { 3, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Patient" },
                    { 4, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Staff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacSis_KhoaId",
                table: "BacSis",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_BacSis_UserId",
                table: "BacSis",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanGhiYTes_BacSiId",
                table: "BanGhiYTes",
                column: "BacSiId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGhiYTes_BenhNhanId",
                table: "BanGhiYTes",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_BanGhiYTes_LichHenId",
                table: "BanGhiYTes",
                column: "LichHenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanGhiYTes_SlotId",
                table: "BanGhiYTes",
                column: "SlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhans_UserId",
                table: "BenhNhans",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChanDoanLamSans_BanGhiYTeId",
                table: "ChanDoanLamSans",
                column: "BanGhiYTeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonThuocs_DonThuocId",
                table: "ChiTietDonThuocs",
                column: "DonThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonThuocs_ThuocId",
                table: "ChiTietDonThuocs",
                column: "ThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DonThuocs_BanGhiYTeId",
                table: "DonThuocs",
                column: "BanGhiYTeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonThuocs_BenhNhanId",
                table: "DonThuocs",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DonThuocs_ThuocId",
                table: "DonThuocs",
                column: "ThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaXetNghiems_BanGhiYTeId",
                table: "KetQuaXetNghiems",
                column: "BanGhiYTeId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaXetNghiems_BenhNhanId",
                table: "KetQuaXetNghiems",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaXetNghiems_NhanVienId",
                table: "KetQuaXetNghiems",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHenKhams_BacSiId",
                table: "LichHenKhams",
                column: "BacSiId");

            migrationBuilder.CreateIndex(
                name: "IX_LichHenKhams_BenhNhanId",
                table: "LichHenKhams",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_LichLamViecs_BacSiId",
                table: "LichLamViecs",
                column: "BacSiId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienYTs_UserId",
                table: "NhanVienYTs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slots_BacSiId",
                table: "Slots",
                column: "BacSiId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_LichLamViecId",
                table: "Slots",
                column: "LichLamViecId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChanDoanLamSans");

            migrationBuilder.DropTable(
                name: "ChiTietDonThuocs");

            migrationBuilder.DropTable(
                name: "KetQuaXetNghiems");

            migrationBuilder.DropTable(
                name: "DonThuocs");

            migrationBuilder.DropTable(
                name: "NhanVienYTs");

            migrationBuilder.DropTable(
                name: "BanGhiYTes");

            migrationBuilder.DropTable(
                name: "Thuocs");

            migrationBuilder.DropTable(
                name: "LichHenKhams");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "BenhNhans");

            migrationBuilder.DropTable(
                name: "LichLamViecs");

            migrationBuilder.DropTable(
                name: "BacSis");

            migrationBuilder.DropTable(
                name: "Khoas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
