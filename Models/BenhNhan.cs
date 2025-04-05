using PBL3.Constant;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class BenhNhan
  {
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [Required]
    public string CCCD { get; set; } = "";
    [Required]
    public string HoTen { get; set; } = "";
    [Required]
    public string SoDienThoai { get; set; } = "";
    public string SoDienThoaiNguoiThan { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public DateTime NgaySinh { get; set; }
    public Gender GioiTinh { get; set; }
    public string DiUng { get; set; } = "";

    // Navigation properties
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public ICollection<LichHenKham> LichHenKhams { get; set; } = [];
  }

}
