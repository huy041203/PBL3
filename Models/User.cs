namespace PBL3.Models
{
  public class User
  {

    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Password { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public enum Gender
    {
      Male,
      Female,
    };
    public int RoleId { get; set; }
    public Role? Role { get; set; }
  }

}
