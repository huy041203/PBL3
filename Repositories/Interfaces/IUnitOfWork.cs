using PBL3.Models;

public interface IUnitOfWork : IDisposable
{
  IGenericRepository<BacSi> BacSis { get; }
  IGenericRepository<BanGhiYTe> BanGhiYTes { get; }
  IGenericRepository<BenhNhan> BenhNhans { get; }
  IGenericRepository<ChanDoanLamSan> ChanDoanLamSans { get; }
  IGenericRepository<ChiTietDonThuoc> ChiTietDonThuocs { get; }
  IGenericRepository<DonThuoc> DonThuocs { get; }
  IGenericRepository<KetQuaXetNghiem> KetQuaXetNghiems { get; }
  IGenericRepository<Khoa> Khoas { get; }    
  IGenericRepository<LichHenKham> LichHenKhams { get; }
  IGenericRepository<NhanVienYT> NhanVienYTs { get; }
  IGenericRepository<Role> Roles { get; }
  IGenericRepository<Thuoc> Thuocs { get; }  
  IGenericRepository<User> Users { get; }   

  Task<int> CompleteAsync();
}