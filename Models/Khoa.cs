using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class Khoa
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string TenKhoa { get; set; } = "";

    [StringLength(500)]
    public string MoTa { get; set; } = "";

    public string Icon { get; set; } = "";

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<BacSi> BacSis { get; set; } = [];
  }
}