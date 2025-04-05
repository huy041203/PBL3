using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class DonThuoc
  {
    [Key]
    public int Id { get; set; }
    public int BanGhiYTeId { get; set; }
    public string ChiDanSuDung { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BanGhiYTeId")]
    public BanGhiYTe BanGhiYTe { get; set; } = null!;
    public ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; } = [];
  }
}
