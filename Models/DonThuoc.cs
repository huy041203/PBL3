using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class DonThuoc
  {
    [Key]
    public int Id { get; set; }

    public int ThuocId { get; set; }

    public int BenhNhanId { get; set; }

    public int BanGhiYTeId { get; set; }

    [StringLength(100)]
    public string LuuLuong { get; set; } = "";

    [StringLength(500)]
    public string GhiChu { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal GiaThuoc { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;

    [ForeignKey("ThuocId")]
    public Thuoc Thuoc { get; set; } = null!;

    [ForeignKey("BenhNhanId")]
    public BenhNhan BenhNhan { get; set; } = null!;

    public ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; } = [];
  }
}