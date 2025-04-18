using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PBL3.Data;
using System.Security.Claims;

namespace PBL3.Filters
{
  public class RoleAuthorizationFilter : IAuthorizationFilter
  {
    private readonly string[] _allowedRoles;
    private readonly IUnitOfWork _unitOfWork;

    public RoleAuthorizationFilter(string[] allowedRoles, IUnitOfWork unitOfWork)
    {
      _allowedRoles = allowedRoles;
      _unitOfWork = unitOfWork;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      // Kiểm tra nếu user đã đăng nhập
      if (!context.HttpContext.User.Identity.IsAuthenticated)
      {
        context.Result = new RedirectToActionResult("Login", "Account", null);
        return;
      }

      // Lấy thông tin user từ claims
      var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
      if (userIdClaim == null)
      {
        context.Result = new RedirectToActionResult("Login", "Account", null);
        return;
      }

      int userId = int.Parse(userIdClaim.Value);
      // Lấy thông tin user từ database
      var user = _unitOfWork.Users.GetById(userId);
      if (user == null)
      {
        context.Result = new RedirectToActionResult("Login", "Account", null);
        return;
      }

      // Lấy thông tin role của user
      var role = _unitOfWork.Roles.GetById(user.RoleId);
      if (role == null || !_allowedRoles.Contains(role.RoleName))
      {
        context.Result = new ForbidResult();
        return;
      }
    }
  }
}
