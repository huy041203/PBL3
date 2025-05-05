using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BacSiRepository : GenericRepository<BacSi>, IBacSiRepository
{
    public BacSiRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BacSi>> GetBacSiByKhoaAsync(int khoaId)
    {
        return await _dbSet
            .Where(b => b.KhoaId == khoaId && b.IsActive)
            .Include(b => b.Khoa)
            .Include(b => b.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<BacSi>> GetActiveAsync()
    {
        return await _dbSet
            .Where(b => b.IsActive)
            .Include(b => b.Khoa)
            .Include(b => b.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetLichHenKhamByBacSiAsync(int bacSiId)
    {
        return await _context.LichHenKhams
            .Where(l => l.BacSiId == bacSiId)
            .Include(l => l.BenhNhan)
            .OrderByDescending(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<BanGhiYTe>> GetBanGhiYTeByBacSiAsync(int bacSiId)
    {
        return await _context.BanGhiYTes
            .Where(b => b.BacSiId == bacSiId)
            .Include(b => b.BenhNhan)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();
    }
}