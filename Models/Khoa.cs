using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class Khoa
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string TenKhoa { get; set; } = "";
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<BacSi> BacSis { get; set; } = [];
  }

}
