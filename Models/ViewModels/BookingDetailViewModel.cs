using PBL3.Models;
public class BacSiDetailViewModel
{
    public BacSi BacSi { get; set; }
    public IEnumerable<DateTime> NgayKhaDung { get; set; }
    public Dictionary<DateTime, int> SoChoTrong { get; set; }
    public Dictionary<DateTime, List<Slot>> SlotsTheoNgay { get; set; }
    public string DiaChi { get; set; } = "11a Đường Đinh Bộ Lĩnh, Phường 24, quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam";
}