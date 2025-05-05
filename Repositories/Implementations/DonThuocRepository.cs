using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DonThuocRepository : GenericRepository<DonThuoc>, IDonThuocRepository
{
    public DonThuocRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DonThuoc>> GetByBenhNhanAsync(int benhNhanId)
    {
        return await _dbSet
            .Where(d => d.BenhNhanId == benhNhanId)
            .Include(d => d.BanGhiYTe)
                .ThenInclude(b => b.BacSi)
            .OrderByDescending(d => d.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<DonThuoc>> GetByBanGhiYTeAsync(int banGhiYTeId)
    {
        return await _dbSet
            .Where(d => d.BanGhiYTeId == banGhiYTeId)
            .Include(d => d.ChiTietDonThuocs)
                .ThenInclude(c => c.Thuoc)
            .ToListAsync();
    }
    
    public async Task<DonThuoc> GetWithDetailsByIdAsync(int donThuocId)
    {
        return await _dbSet
            .Include(d => d.BenhNhan)
            .Include(d => d.BanGhiYTe)
                .ThenInclude(b => b.BacSi)
            .Include(d => d.ChiTietDonThuocs)
                .ThenInclude(c => c.Thuoc)
            .FirstOrDefaultAsync(d => d.Id == donThuocId);
    }
}