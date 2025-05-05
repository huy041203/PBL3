using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class KetQuaXetNghiemRepository : GenericRepository<KetQuaXetNghiem>, IKetQuaXetNghiemRepository
{
    public KetQuaXetNghiemRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<KetQuaXetNghiem>> GetByBenhNhanAsync(int benhNhanId)
    {
        return await _dbSet
            .Where(k => k.BenhNhanId == benhNhanId)
            .Include(k => k.NhanVienYT)
            .Include(k => k.BanGhiYTe)
                .ThenInclude(b => b.BacSi)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<KetQuaXetNghiem>> GetByNhanVienAsync(int nhanVienId)
    {
        return await _dbSet
            .Where(k => k.NhanVienId == nhanVienId)
            .Include(k => k.BenhNhan)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<KetQuaXetNghiem>> GetByBanGhiYTeAsync(int banGhiYTeId)
    {
        return await _dbSet
            .Where(k => k.BanGhiYTeId == banGhiYTeId)
            .Include(k => k.NhanVienYT)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<KetQuaXetNghiem>> GetByLoaiXetNghiemAsync(string loaiXetNghiem)
    {
        return await _dbSet
            .Where(k => k.LoaiXetNghiem == loaiXetNghiem)
            .Include(k => k.BenhNhan)
            .Include(k => k.NhanVienYT)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
}