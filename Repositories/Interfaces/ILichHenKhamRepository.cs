using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL3.Constant;
public interface ILichHenKhamRepository : IGenericRepository<LichHenKham>
{
    Task<IEnumerable<LichHenKham>> GetByBacSiAsync(int bacSiId);
    Task<IEnumerable<LichHenKham>> GetByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<LichHenKham>> GetUpcomingByBacSiAsync(int bacSiId);
    Task<IEnumerable<LichHenKham>> GetUpcomingByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<LichHenKham>> GetByDateAsync(DateTime date);
    Task<IEnumerable<LichHenKham>> GetByTrangThaiAsync(TrangThaiLichHen trangThai);
}