using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBacSiRepository : IGenericRepository<BacSi>
{
    Task<IEnumerable<BacSi>> GetBacSiByKhoaAsync(int khoaId);
    Task<IEnumerable<BacSi>> GetActiveAsync();
    Task<IEnumerable<LichHenKham>> GetLichHenKhamByBacSiAsync(int bacSiId);
    Task<IEnumerable<BanGhiYTe>> GetBanGhiYTeByBacSiAsync(int bacSiId);
}