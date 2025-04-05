using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class ChiTietDonThuoc
  {
    [Key]
    public int Id { get; set; }
    public int DonThuocId { get; set; }
    public int ThuocId { get; set; }
    public string LieuLuong { get; set; } = "";
    public int SoLuong { get; set; }
    public string CachDung { get; set; } = "";

    // Navigation properties
    [ForeignKey("DonThuocId")]
    public DonThuoc DonThuoc { get; set; } = null!;
    [ForeignKey("ThuocId")]
    public Thuoc Thuoc { get; set; } = null!;
  }

}
