using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class Thuoc
  {
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string TenThuoc { get; set; } = "";
    
    [Required]
    [StringLength(50)]
    public string MaLa { get; set; } = "";
    
    public int HSDMonth { get; set; }
    
    public DateTime NgaySanXuat { get; set; }
    
    [StringLength(500)]
    public string MieuTa { get; set; } = "";
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal GiaThuoc { get; set; }
    
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<DonThuoc> DonThuocs { get; set; } = [];
    public ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; } = [];
  }
}