namespace PBL3.Models
{
  public class Role
  {
    public int Id { get; set; }
    public string RoleName { get; set; } = String.Empty;
    public ICollection<UserRole> UserRoles { get; set; } = [];
  }
}
