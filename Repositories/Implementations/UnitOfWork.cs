using System.Threading.Tasks;
using PBL3.Data;
using PBL3.Models;
using PBL3;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IGenericRepository<BacSi> BacSis { get; private set; }
    public IGenericRepository<BanGhiYTe> BanGhiYTes { get; private set; }
    public IGenericRepository<BenhNhan> BenhNhans { get; private set; }
    public IGenericRepository<ChanDoanLamSan> ChanDoanLamSans { get; private set; }
    public IGenericRepository<ChiTietDonThuoc> ChiTietDonThuocs { get; private set; }
    public IGenericRepository<DonThuoc> DonThuocs { get; private set; }
    public IGenericRepository<KetQuaXetNghiem> KetQuaXetNghiems { get; private set; }
    public IGenericRepository<Khoa> Khoas { get; private set; }
    public IGenericRepository<LichHenKham> LichHenKhams { get; private set; }
    public IGenericRepository<NhanVienYT> NhanVienYTs { get; private set; }
    public IGenericRepository<Role> Roles { get; private set; }
    public IGenericRepository<Thuoc> Thuocs { get; private set; }
    public IGenericRepository<User> Users { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        BacSis = new GenericRepository<BacSi>(_context);
        BanGhiYTes = new GenericRepository<BanGhiYTe>(_context);
        BenhNhans = new GenericRepository<BenhNhan>(_context);
        ChanDoanLamSans = new GenericRepository<ChanDoanLamSan>(_context);
        ChiTietDonThuocs = new GenericRepository<ChiTietDonThuoc>(_context);
        DonThuocs = new GenericRepository<DonThuoc>(_context);
        KetQuaXetNghiems = new GenericRepository<KetQuaXetNghiem>(_context);
        Khoas = new GenericRepository<Khoa>(_context);
        LichHenKhams = new GenericRepository<LichHenKham>(_context);
        NhanVienYTs = new GenericRepository<NhanVienYT>(_context);
        Roles = new GenericRepository<Role>(_context);
        Thuocs = new GenericRepository<Thuoc>(_context);
        Users = new GenericRepository<User>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}