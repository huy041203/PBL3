
using PBL3.Models;
using PBL3.Constant;
public class LichHenService : ILichHenService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public LichHenService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<BacSi>> GetBacSiKhaDungAsync()
    {
        // Lấy danh sách bác sĩ đang hoạt động
        return await _unitOfWork.BacSiRepo.GetActiveAsync();
    }
    
    public async Task<IEnumerable<DateTime>> GetNgayKhaDungAsync(int bacSiId)
    {
        // Lấy danh sách các ngày bác sĩ có lịch làm việc (7 ngày tới)
        var ngayHienTai = DateTime.Today;
        var lichLamViec = await _unitOfWork.BacSis
            .FindAsync(l => l.Id == bacSiId && l.LichLamViecs
                .Any(llv => llv.NgayLamViec >= ngayHienTai && 
                     llv.NgayLamViec <= ngayHienTai.AddDays(7) &&
                     llv.SoCaDuocKham > llv.SoSlotDaDat));
                     
        var danhSachNgay = lichLamViec
            .SelectMany(b => b.LichLamViecs)
            .Select(l => l.NgayLamViec.Date)
            .Distinct()
            .OrderBy(d => d)
            .ToList();
            
        return danhSachNgay;
    }
    
    public async Task<IEnumerable<Slot>> GetSlotsKhaDungAsync(int bacSiId, DateTime ngay)
    {
        // Lấy các slot khả dụng trong ngày đó của bác sĩ
        var lichLamViec = await _unitOfWork.LichLamViecs
            .FirstOrDefaultAsync(l => l.BacSiId == bacSiId && l.NgayLamViec.Date == ngay.Date);
            
        if (lichLamViec == null)
            return new List<Slot>();
            
        var slots = await _unitOfWork.Slots
            .FindAsync(s => s.LichLamViecId == lichLamViec.Id && !s.TrangThaiDatLich);
            
        return slots.OrderBy(s => s.GioBatDau).ToList();
    }
    
    public async Task<bool> DatLichHenAsync(int benhNhanId, int bacSiId, int slotId, string lyDoKham)
    {
        // Kiểm tra slot có còn trống không
        var slot = await _unitOfWork.Slots.GetByIdAsync(slotId);
        if (slot == null || slot.TrangThaiDatLich)
            return false;
            
        // Cập nhật trạng thái slot
        slot.TrangThaiDatLich = true;
        _unitOfWork.Slots.Update(slot);
        
        // Cập nhật SoSlotDaDat trong LichLamViec
        var lichLamViec = await _unitOfWork.LichLamViecs.GetByIdAsync(slot.LichLamViecId);
        lichLamViec.SoSlotDaDat++;
        _unitOfWork.LichLamViecs.Update(lichLamViec);
        
        // Tạo lịch hẹn mới
        var lichHen = new LichHenKham
        {
            BacSiId = bacSiId,
            BenhNhanId = benhNhanId,
            ThoiGian = lichLamViec.NgayLamViec.Date.Add(slot.GioBatDau),
            TrangThaiThanhToan = TrangThaiThanhToan.ChuaThanhToan,
            TrangThaiLichHen = TrangThaiLichHen.ChoXacNhan,
            LyDoKham = lyDoKham,
            PhiKham = slot.TienKham,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        await _unitOfWork.LichHenKhams.AddAsync(lichHen);
        
        // Lưu thay đổi
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
    
    public async Task<IEnumerable<LichHenKham>> GetLichHenSapToiAsync(int benhNhanId)
    {
        // Lấy danh sách lịch hẹn sắp tới của bệnh nhân
        return await _unitOfWork.LichHenKhamRepo.GetUpcomingByBenhNhanAsync(benhNhanId);
    }
    
    public async Task<bool> HuyLichHenAsync(int lichHenId, int benhNhanId)
    {
        // Hủy lịch hẹn và cập nhật trạng thái slot
        var lichHen = await _unitOfWork.LichHenKhams
            .FirstOrDefaultAsync(l => l.Id == lichHenId && l.BenhNhanId == benhNhanId);
            
        if (lichHen == null || lichHen.ThoiGian <= DateTime.Now.AddHours(24))
            return false; // Không thể hủy lịch hẹn trong vòng 24h
            
        lichHen.TrangThaiLichHen = TrangThaiLichHen.DaHuy;
        _unitOfWork.LichHenKhams.Update(lichHen);
        
        // Tìm slot tương ứng và cập nhật trạng thái
        var lichLamViec = await _unitOfWork.LichLamViecs
            .FirstOrDefaultAsync(l => l.BacSiId == lichHen.BacSiId && l.NgayLamViec.Date == lichHen.ThoiGian.Date);
            
        if (lichLamViec != null)
        {
            var slot = await _unitOfWork.Slots
                .FirstOrDefaultAsync(s => s.LichLamViecId == lichLamViec.Id && 
                                     s.GioBatDau <= lichHen.ThoiGian.TimeOfDay && 
                                     s.GioKetThuc > lichHen.ThoiGian.TimeOfDay);
                                     
            if (slot != null)
            {
                slot.TrangThaiDatLich = false;
                _unitOfWork.Slots.Update(slot);
                
                lichLamViec.SoSlotDaDat--;
                _unitOfWork.LichLamViecs.Update(lichLamViec);
            }
        }
        
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
}