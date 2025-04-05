using PBL3.Constant;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class BacSi
  {
    [Key]
    public int Id { get; set; }
    public int KhoaId { get; set; }
    public int UserId { get; set; }
    [Required]
    public string CCCD { get; set; } = "";
    [Required]
    public string HoTen { get; set; } = "";
    [Required]
    public string SoDienThoai { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public DateTime NgaySinh { get; set; }
    public Gender GioiTinh { get; set; }
    public string PhongKham { get; set; } = "";
    public int SoNamKinhNghiem { get; set; }
    public float GiaKham { get; set; }
    public string Description { get; set; } = "";
    public bool IsActive { get; set; } = true;

    // Navigation properties
    [ForeignKey("KhoaId")]
    public Khoa Khoa { get; set; } = null!;
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public ICollection<LichHenKham> LichHenKhams { get; set; } = [];
  }
}
