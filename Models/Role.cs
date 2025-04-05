using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using PBL3.Constant;
namespace PBL3.Models
{
  public class Role
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string RoleName { get; set; } = "";
    public DateTime CreatedAt { get; set; } = new DateTime(2023, 5, 15);
    public User? User { get; set; }
  }
}
