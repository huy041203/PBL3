using PBL3.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class BacSi
  {
    [Key]
    public int Id { get; set; }

    public int KhoaId { get; set; }

    public int UserId { get; set; }

    [Required]
    [StringLength(12)]
    public string CCCD { get; set; } = "";

    [Required]
    [StringLength(100)]
    public string HoTen { get; set; } = "";

    [Required]
    [StringLength(15)]
    public string SoDienThoai { get; set; } = "";

    [StringLength(255)]
    public string DiaChi { get; set; } = "";

    public DateTime NgaySinh { get; set; }

    public Gender GioiTinh { get; set; }

    public string PhongKham { get; set; } = "";

    public int SoNamKinhNghiem { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal GiaKham { get; set; }

    public string MieuTa { get; set; } = "";

    public double DiemDanhGia { get; set; } = 0;

    public bool IsActive { get; set; } = true;

    // Navigation properties
    [ForeignKey("KhoaId")]
    public Khoa Khoa { get; set; } = null!;

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    public ICollection<LichLamViec> LichLamViecs { get; set; } = [];
    
    public ICollection<Slot> Slots { get; set; } = [];
    
    public ICollection<BanGhiYTe> BanGhiYTes { get; set; } = [];
  }
}