using PBL3.Constant;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class LichHenKham
  {
    [Key]
    public int Id { get; set; }

    public int BacSiId { get; set; }

    public int BenhNhanId { get; set; }

    public DateTime ThoiGian { get; set; }

    public TrangThaiThanhToan TrangThaiThanhToan { get; set; }

    public TrangThaiLichHen TrangThaiLichHen { get; set; }

    [StringLength(500)]
    public string LyDoKham { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal PhiKham { get; set; }

    public string MaThanhToan { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BacSiId")]
    public BacSi BacSi { get; set; } = null!;

    [ForeignKey("BenhNhanId")]
    public BenhNhan BenhNhan { get; set; } = null!;

    public BanGhiYTe? BanGhiYTe { get; set; }
  }
}