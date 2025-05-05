using PBL3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IKetQuaXetNghiemRepository : IGenericRepository<KetQuaXetNghiem>
{
    Task<IEnumerable<KetQuaXetNghiem>> GetByBenhNhanAsync(int benhNhanId);
    Task<IEnumerable<KetQuaXetNghiem>> GetByNhanVienAsync(int nhanVienId);
    Task<IEnumerable<KetQuaXetNghiem>> GetByBanGhiYTeAsync(int banGhiYTeId);
    Task<IEnumerable<KetQuaXetNghiem>> GetByLoaiXetNghiemAsync(string loaiXetNghiem);
}