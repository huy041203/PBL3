using PBL3.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class NhanVienYT
  {
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string HoTen { get; set; } = "";

    [StringLength(100)]
    public string LoaiXetNghiem { get; set; } = "";

    [StringLength(15)]
    public string SoDienThoai { get; set; } = "";

    [StringLength(255)]
    public string DiaChi { get; set; } = "";

    public DateTime NgaySinh { get; set; }

    public Gender GioiTinh { get; set; }

    [StringLength(12)]
    public string CCCD { get; set; } = "";

    public string PhongLamViec { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal GiaXetNghiem { get; set; }

    public string Avatar { get; set; } = "";

    public bool IsActive { get; set; } = true;

    // Navigation properties
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    public ICollection<KetQuaXetNghiem> KetQuaXetNghiems { get; set; } = [];
  }
}