using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBL3.Constant;
public class LichHenKhamRepository : GenericRepository<LichHenKham>, ILichHenKhamRepository
{
    public LichHenKhamRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LichHenKham>> GetByBacSiAsync(int bacSiId)
    {
        return await _dbSet
            .Where(l => l.BacSiId == bacSiId)
            .Include(l => l.BenhNhan)
            .OrderByDescending(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetByBenhNhanAsync(int benhNhanId)
    {
        return await _dbSet
            .Where(l => l.BenhNhanId == benhNhanId)
            .Include(l => l.BacSi)
            .OrderByDescending(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetUpcomingByBacSiAsync(int bacSiId)
    {
        DateTime today = DateTime.Today;
        return await _dbSet
            .Where(l => l.BacSiId == bacSiId && l.ThoiGian >= today)
            .Include(l => l.BenhNhan)
            .OrderBy(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetUpcomingByBenhNhanAsync(int benhNhanId)
    {
        DateTime today = DateTime.Today;
        return await _dbSet
            .Where(l => l.BenhNhanId == benhNhanId && l.ThoiGian >= today)
            .Include(l => l.BacSi)
            .OrderBy(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetByDateAsync(DateTime date)
    {
        return await _dbSet
            .Where(l => l.ThoiGian.Date == date.Date)
            .Include(l => l.BacSi)
            .Include(l => l.BenhNhan)
            .OrderBy(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<LichHenKham>> GetByTrangThaiAsync(TrangThaiLichHen trangThai)
    {
        return await _dbSet
            .Where(l => l.TrangThaiLichHen == trangThai)
            .Include(l => l.BacSi)
            .Include(l => l.BenhNhan)
            .OrderByDescending(l => l.ThoiGian)
            .ToListAsync();
    }
}