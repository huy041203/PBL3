using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class ChanDoanLamSan
  {
    [Key]
    public int Id { get; set; }
    public int BanGhiYTeId { get; set; }
    public string TrieuChung { get; set; } = "";
    public string HuyetAp { get; set; } = "";
    public string TinhTrangBenh { get; set; } = "";
    public string NhipTim { get; set; } = "";
    public string NhietDo { get; set; } = "";
    public string CanNang { get; set; } = "";
    public string ChieuCao { get; set; } = "";
    public string Note { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;
  }

}
