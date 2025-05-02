using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PBL3.Constant;

namespace PBL3.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = "";

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = "";

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = "";

    [Required]
    [StringLength(255)]
    public string Password { get; set; } = "";

    [StringLength(15)]
    public string PhoneNumber { get; set; } = "";

    [StringLength(255)]
    public string Address { get; set; } = "";

    public Gender Gender { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
    public BacSi? BacSi { get; set; }
    public BenhNhan? BenhNhan { get; set; }
    public NhanVienYT? NhanVienYT { get; set; }
  }
}