using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PBL3.Data;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace PBL3.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRolesAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Kiểm tra nếu user đã đăng nhập
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            // Lấy UnitOfWork từ DI container
            var unitOfWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();

            // Lấy thông tin user từ claims
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            int userId = int.Parse(userIdClaim.Value);
            
            // Lấy thông tin user từ database
            var user = unitOfWork.Users.GetById(userId);
            if (user == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            // Lấy thông tin role của user
            var role = unitOfWork.Roles.GetById(user.RoleId);
            if (role == null || !_roles.Contains(role.RoleName))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
