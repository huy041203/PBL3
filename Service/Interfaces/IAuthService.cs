// Services/IAuthService.cs
using System.Security.Claims;
using PBL3.Models;
using PBL3.Models.ViewModels;

namespace PBL3.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateUserAsync(LoginViewModel model);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        ClaimsPrincipal CreateClaimsPrincipal(User user, string roleName);
        
    }
}