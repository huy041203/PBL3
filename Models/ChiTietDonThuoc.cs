using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class ChiTietDonThuoc
  {
    [Key]
    public int Id { get; set; }

    public int DonThuocId { get; set; }

    public int ThuocId { get; set; }

    [StringLength(100)]
    public string LieuLuong { get; set; } = "";

    public int SoLuong { get; set; }

    [StringLength(255)]
    public string CachDung { get; set; } = "";

    [Column(TypeName = "decimal(18,2)")]
    public decimal DonGia { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ThanhTien { get; set; }

    // Navigation properties
    [ForeignKey("DonThuocId")]
    public DonThuoc DonThuoc { get; set; } = null!;

    [ForeignKey("ThuocId")]
    public Thuoc Thuoc { get; set; } = null!;
  }
}