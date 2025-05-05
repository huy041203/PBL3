using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDonThuocRepository : IGenericRepository<DonThuoc>
{
    Task<IEnumerable<DonThuoc>> GetByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<DonThuoc>> GetByBanGhiYTeAsync(int banGhiYTeId);
    Task<DonThuoc> GetWithDetailsByIdAsync(int donThuocId);
}