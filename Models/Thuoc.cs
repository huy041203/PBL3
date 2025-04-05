using PBL3.Constant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class Thuoc
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string TenThuoc { get; set; } = "";
    [Column(TypeName = "decimal(18,2)")]
    public decimal Gia { get; set; }
    public string MoTa { get; set; } = "";
    public DateTime NgaySanXuat { get; set; }
    public DateTime HanSuDung { get; set; }
    public LoaiThuoc LoaiThuoc { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; } = [];
  }
}
