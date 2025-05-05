using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBenhNhanRepository : IGenericRepository<BenhNhan>
{
    Task<IEnumerable<LichHenKham>> GetLichHenKhamByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<BanGhiYTe>> GetBanGhiYTeByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<DonThuoc>> GetDonThuocByBenhNhanAsync(int benhNhanId);
}