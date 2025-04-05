using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class KetQuaXetNghiem
  {
    [Key]
    public int Id { get; set; }
    public int BanGhiYTeId { get; set; }
    public int NhanVienId { get; set; }
    public string LoaiXetNghiem { get; set; } = "";
    public string KetQua { get; set; } = "";
    public DateTime NgayThucHien { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;
    [ForeignKey("NhanVienId")]
    public NhanVienYT NhanVienYT { get; set; } = null!;
  }
}
