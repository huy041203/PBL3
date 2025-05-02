using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class KetQuaXetNghiem
  {
    [Key]
    public int Id { get; set; }

    public int BenhNhanId { get; set; }

    public int NhanVienId { get; set; }

    public int BanGhiYTeId { get; set; }

    public DateTime? ThoiGianBatDauXetNghiem { get; set; }

    public DateTime? ThoiGianKetThucXetNghiem { get; set; }

    [StringLength(100)]
    public string LoaiXetNghiem { get; set; } = "";

    [StringLength(100)]
    public string BoPhanXetNghiem { get; set; } = "";

    [StringLength(500)]
    public string KetQua { get; set; } = "";

    public string FileKetQua { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal GiaXetNghiem { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;

    [ForeignKey("NhanVienId")]
    public NhanVienYT NhanVienYT { get; set; } = null!;

    [ForeignKey("BenhNhanId")]
    public BenhNhan BenhNhan { get; set; } = null!;
  }
}