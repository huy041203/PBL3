using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BenhNhanRepository : GenericRepository<BenhNhan>, IBenhNhanRepository
{
    public BenhNhanRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LichHenKham>> GetLichHenKhamByBenhNhanAsync(int benhNhanId)
    {
        return await _context.LichHenKhams
            .Where(l => l.BenhNhanId == benhNhanId)
            .Include(l => l.BacSi)
            .OrderByDescending(l => l.ThoiGian)
            .ToListAsync();
    }

    public async Task<IEnumerable<BanGhiYTe>> GetBanGhiYTeByBenhNhanAsync(int benhNhanId)
    {
        return await _context.BanGhiYTes
            .Where(b => b.BenhNhanId == benhNhanId)
            .Include(b => b.BacSi)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<DonThuoc>> GetDonThuocByBenhNhanAsync(int benhNhanId)
    {
        return await _context.DonThuocs
            .Where(d => d.BenhNhanId == benhNhanId)
            .Include(d => d.BanGhiYTe)
            .Include(d => d.ChiTietDonThuocs)
                .ThenInclude(c => c.Thuoc)
            .OrderByDescending(d => d.CreatedAt)
            .ToListAsync();
    }
}