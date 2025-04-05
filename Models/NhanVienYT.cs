using PBL3.Constant;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class NhanVienYT
  {
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [Required]
    public string HoTen { get; set; } = "";
    public string ChuyenMon { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public DateTime NgaySinh { get; set; }
    public Gender GioiTinh { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public ICollection<KetQuaXetNghiem> KetQuaXetNghiems { get; set; } = [];
  }
}
