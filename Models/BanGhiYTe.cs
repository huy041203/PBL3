using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class BanGhiYTe
  {
    [Key]
    public int Id { get; set; }

    public int BenhNhanId { get; set; }

    public int SlotId { get; set; }

    public int BacSiId { get; set; }

    public DateTime? ThoiGianBatDauKhamThucTe { get; set; }

    public DateTime? ThoiGianKetThucKham { get; set; }

    [StringLength(500)]
    public string TrieuChung { get; set; } = "";

    [StringLength(500)]
    public string TinhTrang { get; set; } = "";

    [StringLength(500)]
    public string ChanDoan { get; set; } = "";

    [StringLength(500)]
    public string KetQuaKham { get; set; } = "";

    [StringLength(1000)]
    public string GhiChu { get; set; } = "";

    public bool DaKhamLamSan { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BenhNhanId")]
    public BenhNhan BenhNhan { get; set; } = null!;

    [ForeignKey("SlotId")]
    public Slot Slot { get; set; } = null!;

    [ForeignKey("BacSiId")]
    public BacSi BacSi { get; set; } = null!;

    public DonThuoc? DonThuoc { get; set; }

    public ICollection<KetQuaXetNghiem> KetQuaXetNghiems { get; set; } = [];
  }
}