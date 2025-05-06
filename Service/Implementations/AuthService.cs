// Services/AuthService.cs
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PBL3.Models;
using PBL3.Models.ViewModels;

namespace PBL3.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ValidateUserAsync(LoginViewModel model)
        {
            var user = await GetUserByUsernameAsync(model.Username);
            if (user == null)
                return false;

            return PasswordHasher.VerifyPassword(model.Password, user.Password);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.Username == username);
            return users.FirstOrDefault();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.Email == email);
            return users.FirstOrDefault();
        }

        public ClaimsPrincipal CreateClaimsPrincipal(User user, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roleName)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            return new ClaimsPrincipal(identity);
        }
    }
}