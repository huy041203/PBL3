using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class BanGhiYTe
  {
    [Key]
    public int Id { get; set; }
    public int LichHenId { get; set; }
    public string GhiChu { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("LichHenId")]
    public LichHenKham LichHenKham { get; set; } = null!;
    public DonThuoc? DonThuoc { get; set; }
    public ICollection<ChanDoanLamSan> ChanDoanLamSans { get; set; } = [];
    public ICollection<KetQuaXetNghiem> KetQuaXetNghiems { get; set; } = [];
  }
}
