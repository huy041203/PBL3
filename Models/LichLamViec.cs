using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
  public class LichLamViec
  {
    [Key]
    public int Id { get; set; }

    public int BacSiId { get; set; }

    public DateTime NgayLamViec { get; set; }

    public int SoCaDuocKham { get; set; }

    public int SoSlotDaDat { get; set; } = 0;

    // Navigation properties
    [ForeignKey("BacSiId")]
    public BacSi BacSi { get; set; } = null!;

    public ICollection<Slot> Slots { get; set; } = [];
  }
}