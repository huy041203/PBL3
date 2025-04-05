using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using PBL3.Constant;
namespace PBL3.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
    [Required]
    public string FullName { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public Gender Gender { get; set; }
    public int RoleId { get; set; }
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