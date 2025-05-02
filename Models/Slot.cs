using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class Slot
  {
    [Key]
    public int Id { get; set; }

    public int LichLamViecId { get; set; }

    public int BacSiId { get; set; }

    public TimeSpan GioBatDau { get; set; }

    public TimeSpan GioKetThuc { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TienKham { get; set; }

    public bool TrangThaiThanhToan { get; set; } = false;

    public bool TrangThaiDatLich { get; set; } = false;

    public bool TrangThaiKham { get; set; } = false;

    // Navigation properties
    [ForeignKey("BacSiId")]
    public BacSi BacSi { get; set; } = null!;

    [ForeignKey("LichLamViecId")]
    public LichLamViec LichLamViec { get; set; } = null!;

    public BanGhiYTe? BanGhiYTe { get; set; }
  }
}