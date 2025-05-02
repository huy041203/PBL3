using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class ChanDoanLamSan
  {
    [Key]
    public int Id { get; set; }

    public int BanGhiYTeId { get; set; }

    [StringLength(500)]
    public string TrieuChung { get; set; } = "";

    [StringLength(50)]
    public string HuyetAp { get; set; } = "";

    [StringLength(500)]
    public string TinhTrangBenh { get; set; } = "";

    [StringLength(50)]
    public string NhipTim { get; set; } = "";

    [StringLength(50)]
    public string NhietDo { get; set; } = "";

    [StringLength(50)]
    public string CanNang { get; set; } = "";

    [StringLength(50)]
    public string ChieuCao { get; set; } = "";

    [StringLength(500)]
    public string Note { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;
  }
}