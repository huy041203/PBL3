using Microsoft.EntityFrameworkCore;
using PBL3.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // User-Role relationship
      modelBuilder.Entity<User>()
          .HasOne(u => u.Role)
          .WithOne(r => r.User)
          .HasForeignKey<User>(u => u.RoleId);

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
          .HasForeignKey(b => b.KhoaId);

      // LichHenKham relationships
      modelBuilder.Entity<LichHenKham>()
          .HasOne(l => l.BacSi)
          .WithMany(b => b.LichHenKhams)
          .HasForeignKey(l => l.BacSiId);

      modelBuilder.Entity<LichHenKham>()
          .HasOne(l => l.BenhNhan)
          .WithMany(bn => bn.LichHenKhams)
          .HasForeignKey(l => l.BenhNhanId)
          .OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<LichHenKham>()
          .HasOne(l => l.BanGhiYTe)
          .WithOne(b => b.LichHenKham)
          .HasForeignKey<BanGhiYTe>(b => b.LichHenId);

      // BanGhiYTe-DonThuoc relationship
      modelBuilder.Entity<BanGhiYTe>()
          .HasOne(b => b.DonThuoc)
          .WithOne(d => d.BanGhiYTe)
          .HasForeignKey<DonThuoc>(d => d.BanGhiYTeId);

      // DonThuoc-ChiTietDonThuoc relationship
      modelBuilder.Entity<ChiTietDonThuoc>()
          .HasOne(c => c.DonThuoc)
          .WithMany(d => d.ChiTietDonThuocs)
          .HasForeignKey(c => c.DonThuocId);

      // ChiTietDonThuoc-Thuoc relationship
      modelBuilder.Entity<ChiTietDonThuoc>()
          .HasOne(c => c.Thuoc)
          .WithMany(t => t.ChiTietDonThuocs)
          .HasForeignKey(c => c.ThuocId);

      // KetQuaXetNghiem relationships
      modelBuilder.Entity<KetQuaXetNghiem>()
          .HasOne(k => k.BanGhiYTe)
          .WithMany(b => b.KetQuaXetNghiems)
          .HasForeignKey(k => k.BanGhiYTeId);

      modelBuilder.Entity<KetQuaXetNghiem>()
          .HasOne(k => k.NhanVienYT)
          .WithMany(n => n.KetQuaXetNghiems)
          .HasForeignKey(k => k.NhanVienId)
          .OnDelete(DeleteBehavior.NoAction);

      // Seed initial data
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
    }
  }
}