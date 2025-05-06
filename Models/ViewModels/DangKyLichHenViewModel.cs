using PBL3.Models;
public class DangKyLichHenViewModel
{
    public int BacSiId { get; set; }
    public DateTime NgayKham { get; set; }
    public int SlotId { get; set; }
    public string LyDoKham { get; set; }
    public List<BacSi> DanhSachBacSi { get; set; }
    public List<Slot> SlotsKhaDung { get; set; }
}