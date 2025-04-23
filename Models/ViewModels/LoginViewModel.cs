// Models/ViewModels/LoginViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
    public string ReturnUrl { get; set; }
  }
}