
using PBL3.Models;

public interface ILichHenService
{
    Task<IEnumerable<BacSi>> GetBacSiKhaDungAsync();
    Task<IEnumerable<DateTime>> GetNgayKhaDungAsync(int bacSiId);
    Task<IEnumerable<Slot>> GetSlotsKhaDungAsync(int bacSiId, DateTime ngay);
    Task<bool> DatLichHenAsync(int benhNhanId, int bacSiId, int slotId, string lyDoKham);
    Task<IEnumerable<LichHenKham>> GetLichHenSapToiAsync(int benhNhanId);
    Task<bool> HuyLichHenAsync(int lichHenId, int benhNhanId);
}