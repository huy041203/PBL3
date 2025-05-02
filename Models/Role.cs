using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
  public class Role
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string RoleName { get; set; } = "";

    public string Description { get; set; } = "";

    public DateTime CreatedAt { get; set; } = new DateTime(2023, 5, 15);

    // Navigation properties
    public ICollection<User> Users { get; set; } = [];
  }
}