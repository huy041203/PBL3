using Microsoft.EntityFrameworkCore;
using PBL3.Models;
using PBL3.Constant;
using System;

namespace PBL3.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<BacSi> BacSis { get; set; }
    public DbSet<BenhNhan> BenhNhans { get; set; }
    public DbSet<NhanVienYT> NhanVienYTs { get; set; }
    public DbSet<Khoa> Khoas { get; set; }
    public DbSet<LichHenKham> LichHenKhams { get; set; }
    public DbSet<BanGhiYTe> BanGhiYTes { get; set; }
    public DbSet<DonThuoc> DonThuocs { get; set; }
    public DbSet<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
    public DbSet<Thuoc> Thuocs { get; set; }
    public DbSet<ChanDoanLamSan> ChanDoanLamSans { get; set; }
    public DbSet<KetQuaXetNghiem> KetQuaXetNghiems { get; set; }
    public DbSet<Slot> Slots { get; set; }
    public DbSet<LichLamViec> LichLamViecs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // User-Role relationship
      modelBuilder.Entity<User>()
          .HasOne(u => u.Role)
          .WithMany(r => r.Users)
          .HasForeignKey(u => u.RoleId);

      // User-BacSi relationship
      modelBuilder.Entity<BacSi>()
          .HasOne(b => b.User)
          .WithOne(u => u.BacSi)
          .HasForeignKey<BacSi>(b => b.UserId);

      // User-BenhNhan relationship
      modelBuilder.Entity<BenhNhan>()
          .HasOne(bn => bn.User)
          .WithOne(u => u.BenhNhan)
          .HasForeignKey<BenhNhan>(bn => bn.UserId);

      // User-NhanVienYT relationship
      modelBuilder.Entity<NhanVienYT>()
          .HasOne(nv => nv.User)
          .WithOne(u => u.NhanVienYT)
          .HasForeignKey<NhanVienYT>(nv => nv.UserId);

      // BacSi-Khoa relationship
      modelBuilder.Entity<BacSi>()
          .HasOne(b => b.Khoa)
          .WithMany(k => k.BacSis)
          .HasForeignKey(b => b.KhoaId)
          .OnDelete(DeleteBehavior.NoAction);

      // BacSi-LichLamViec relationship
      modelBuilder.Entity<LichLamViec>()
          .HasOne(l => l.BacSi)
          .WithMany(b => b.LichLamViecs)
          .HasForeignKey(l => l.BacSiId)
          .OnDelete(DeleteBehavior.NoAction);

      // LichLamViec-Slot relationship
      modelBuilder.Entity<Slot>()
          .HasOne(s => s.LichLamViec)
          .WithMany(l => l.Slots)
          .HasForeignKey(s => s.LichLamViecId)
          .OnDelete(DeleteBehavior.NoAction);

      // BacSi-Slot relationship
      modelBuilder.Entity<Slot>()
          .HasOne(s => s.BacSi)
          .WithMany(b => b.Slots)
          .HasForeignKey(s => s.BacSiId)
          .OnDelete(DeleteBehavior.NoAction);

      // Slot-BanGhiYTe relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.Slot)
          .WithOne(s => s.BanGhiYTe)
          .HasForeignKey<BanGhiYTe>(b => b.SlotId)
          .OnDelete(DeleteBehavior.NoAction);

      // BenhNhan-BanGhiYTe relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.BenhNhan)
          .WithMany(bn => bn.BanGhiYTes)
          .HasForeignKey(b => b.BenhNhanId)
          .OnDelete(DeleteBehavior.NoAction);

      // BacSi-BanGhiYTe relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.BacSi)
          .WithMany(bs => bs.BanGhiYTes)
          .HasForeignKey(b => b.BacSiId)
          .OnDelete(DeleteBehavior.NoAction);

      // LichHenKham-BacSi relationship
      modelBuilder.Entity<LichHenKham>()
          .HasOne(l => l.BacSi)
          .WithMany(b => b.LichHenKhams)
          .HasForeignKey(l => l.BacSiId)
          .OnDelete(DeleteBehavior.NoAction);

      // LichHenKham-BenhNhan relationship
      modelBuilder.Entity<LichHenKham>()
          .HasOne(l => l.BenhNhan)
          .WithMany(bn => bn.LichHenKhams)
          .HasForeignKey(l => l.BenhNhanId)
          .OnDelete(DeleteBehavior.NoAction);

      // LichHenKham-BanGhiYTe relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.LichHenKham)
          .WithOne(l => l.BanGhiYTe)
          .HasForeignKey<BanGhiYTe>(b => b.LichHenId)
          .OnDelete(DeleteBehavior.NoAction);

      // BanGhiYTe-DonThuoc relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.DonThuoc)
          .WithOne(d => d.BanGhiYTe)
          .HasForeignKey<DonThuoc>(d => d.BanGhiYTeId)
          .OnDelete(DeleteBehavior.NoAction);

      // DonThuoc-ChiTietDonThuoc relationship
      modelBuilder.Entity<ChiTietDonThuoc>()
          .HasOne(c => c.DonThuoc)
          .WithMany(d => d.ChiTietDonThuocs)
          .HasForeignKey(c => c.DonThuocId)
          .OnDelete(DeleteBehavior.NoAction);

      // ChiTietDonThuoc-Thuoc relationship
      modelBuilder.Entity<ChiTietDonThuoc>()
          .HasOne(c => c.Thuoc)
          .WithMany(t => t.ChiTietDonThuocs)
          .HasForeignKey(c => c.ThuocId)
          .OnDelete(DeleteBehavior.NoAction);

      // BenhNhan-DonThuoc relationship
      modelBuilder.Entity<DonThuoc>()
          .HasOne(d => d.BenhNhan)
          .WithMany(bn => bn.DonThuocs)
          .HasForeignKey(d => d.BenhNhanId)
          .OnDelete(DeleteBehavior.NoAction);

      // Thuoc-DonThuoc relationship
      modelBuilder.Entity<DonThuoc>()
          .HasOne(d => d.Thuoc)
          .WithMany(t => t.DonThuocs)
          .HasForeignKey(d => d.ThuocId)
          .OnDelete(DeleteBehavior.NoAction);

      // KetQuaXetNghiem-BanGhiYTe relationship
      modelBuilder.Entity<KetQuaXetNghiem>()
          .HasOne(k => k.BanGhiYTe)
          .WithMany(b => b.KetQuaXetNghiems)
          .HasForeignKey(k => k.BanGhiYTeId)
          .OnDelete(DeleteBehavior.NoAction);

      // KetQuaXetNghiem-NhanVienYT relationship
      modelBuilder.Entity<KetQuaXetNghiem>()
          .HasOne(k => k.NhanVienYT)
          .WithMany(n => n.KetQuaXetNghiems)
          .HasForeignKey(k => k.NhanVienId)
          .OnDelete(DeleteBehavior.NoAction);

      // KetQuaXetNghiem-BenhNhan relationship
      modelBuilder.Entity<KetQuaXetNghiem>()
          .HasOne(k => k.BenhNhan)
          .WithMany(bn => bn.KetQuaXetNghiems)
          .HasForeignKey(k => k.BenhNhanId)
          .OnDelete(DeleteBehavior.NoAction);

      // ChanDoanLamSan-BanGhiYTe relationship
      modelBuilder.Entity<ChanDoanLamSan>()
          .HasOne(c => c.BanGhiYTe)
          .WithMany(b => b.ChanDoanLamSans)
          .HasForeignKey(c => c.BanGhiYTeId)
          .OnDelete(DeleteBehavior.NoAction);

      // Seed initial data
      var fixedDate = new DateTime(2023, 5, 1);

      modelBuilder.Entity<Role>().HasData(
          new Role { Id = 1, RoleName = "Admin" },
          new Role { Id = 2, RoleName = "Doctor" },
          new Role { Id = 3, RoleName = "Patient" },
          new Role { Id = 4, RoleName = "Staff" }
      );

      modelBuilder.Entity<Khoa>().HasData(
          new Khoa { Id = 1, TenKhoa = "Khoa Nội", IsActive = true },
          new Khoa { Id = 2, TenKhoa = "Khoa Ngoại", IsActive = true },
          new Khoa { Id = 3, TenKhoa = "Khoa Nhi", IsActive = true },
          new Khoa { Id = 4, TenKhoa = "Khoa Sản", IsActive = true },
          new Khoa { Id = 5, TenKhoa = "Khoa Mắt", IsActive = true },
          new Khoa { Id = 6, TenKhoa = "Khoa Tai Mũi Họng", IsActive = true },
          new Khoa { Id = 7, TenKhoa = "Khoa Da liễu", IsActive = true }
      );


      // Seed Users for doctors
      modelBuilder.Entity<User>().HasData(
          new User 
          { 
              Id = 1, 
              Username = "doctor1", 
              Email = "doctor1@gmail.com", 
              FullName = "Nguyễn Văn A", 
              Password = "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==",
              PhoneNumber = "0912345678", 
              Address = "Hà Nội", 
              Gender = Gender.Male, 
              RoleId = 2, 
              IsActive = true,
              CreatedAt = fixedDate,
              UpdatedAt = fixedDate
          },
          new User 
          { 
              Id = 2, 
              Username = "doctor2", 
              Email = "doctor2@gmail.com", 
              FullName = "Trần Thị B", 
              Password = "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==",
              PhoneNumber = "0923456789", 
              Address = "Đà Nẵng", 
              Gender = Gender.Female, 
              RoleId = 2, 
              IsActive = true,
              CreatedAt = fixedDate,
              UpdatedAt = fixedDate
          },
          new User 
          { 
              Id = 3, 
              Username = "doctor3", 
              Email = "doctor3@gmail.com", 
              FullName = "Lê Văn C", 
              Password = "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==",
              PhoneNumber = "0934567890", 
              Address = "Hồ Chí Minh", 
              Gender = Gender.Male, 
              RoleId = 2, 
              IsActive = true,
              CreatedAt = fixedDate,
              UpdatedAt = fixedDate
          },
          new User 
          { 
              Id = 4, 
              Username = "admin", 
              Email = "admin@gmail.com", 
              FullName = "Admin System", 
              Password = "AQAAAAEAACcQAAAAEJmq47sOXHAcSZV1UrBbGkmAw8xK5FQfPV9kUK8LWZ1hEMv/wJBLnmTyLO0fLjqKxA==",
              PhoneNumber = "0987654321", 
              Address = "Hà Nội", 
              Gender = Gender.Male, 
              RoleId = 1, // Admin role 
              IsActive = true,
              CreatedAt = fixedDate,
              UpdatedAt = fixedDate
          }
      );
      
      // Seed BacSi
      modelBuilder.Entity<BacSi>().HasData(
          new BacSi
          {
              Id = 1,
              KhoaId = 1,
              UserId = 1,
              CCCD = "123456789012",
              HoTen = "Nguyễn Văn A",
              SoDienThoai = "0912345678",
              DiaChi = "Hà Nội",
              NgaySinh = new DateTime(1985, 5, 10),
              GioiTinh = Gender.Male,
              PhongKham = "P.101",
              SoNamKinhNghiem = 10,
              GiaKham = 200000,
              MieuTa = "Bác sĩ chuyên khoa Nội với 10 năm kinh nghiệm",
              DiemDanhGia = 4.8,
              IsActive = true
          },
          new BacSi
          {
              Id = 2,
              KhoaId = 4,
              UserId = 2,
              CCCD = "234567890123",
              HoTen = "Trần Thị B",
              SoDienThoai = "0923456789",
              DiaChi = "Đà Nẵng",
              NgaySinh = new DateTime(1988, 7, 15),
              GioiTinh = Gender.Female,
              PhongKham = "P.205",
              SoNamKinhNghiem = 8,
              GiaKham = 250000,
              MieuTa = "Bác sĩ chuyên khoa Sản với 8 năm kinh nghiệm",
              DiemDanhGia = 4.9,
              IsActive = true
          },
          new BacSi
          {
              Id = 3,
              KhoaId = 3,
              UserId = 3,
              CCCD = "345678901234",
              HoTen = "Lê Văn C",
              SoDienThoai = "0934567890",
              DiaChi = "Hồ Chí Minh",
              NgaySinh = new DateTime(1980, 2, 20),
              GioiTinh = Gender.Male,
              PhongKham = "P.307",
              SoNamKinhNghiem = 15,
              GiaKham = 300000,
              MieuTa = "Bác sĩ chuyên khoa Nhi với 15 năm kinh nghiệm",
              DiemDanhGia = 4.7,
              IsActive = true
          }
      );
    }
  }
}