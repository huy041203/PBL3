using PBL3.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class BenhNhan
  {
    [Key]
    public int Id { get; set; }

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

    [StringLength(15)]
    public string SoDienThoaiNguoiThan { get; set; } = "";

    [StringLength(255)]
    public string DiaChi { get; set; } = "";

    public DateTime NgaySinh { get; set; }

    public Gender GioiTinh { get; set; }

    public string DiUng { get; set; } = "";

    public string NhomMau { get; set; } = "";

    public string TienSuBenh { get; set; } = "";

    public string Avatar { get; set; } = "";

    // Navigation properties
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    public ICollection<LichHenKham> LichHenKhams { get; set; } = [];
  }
}