using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PBL3.Models.ViewModels;
using PBL3.Services;

namespace PBL3.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                // Nếu model không hợp lệ, thêm TempData để hiển thị lỗi
                TempData["LoginError"] = "Vui lòng nhập đủ thông tin đăng nhập";
                
                // Trả về trang hiện tại
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            if (await _authService.ValidateUserAsync(model))
            {
                var user = await _authService.GetUserByUsernameAsync(model.Username);
                var role = _unitOfWork.Roles.GetById(user.RoleId);

                if (role == null)
                {
                    TempData["LoginError"] = "Tài khoản không có quyền truy cập";
                    
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }

                var principal = _authService.CreateClaimsPrincipal(user, role.RoleName);
                
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync("CookieAuth", principal, authProperties);

                TempData["Success"] = "Đăng nhập thành công!";

                // Người dùng đang cố truy cập một trang cụ thể
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                
                // Điều hướng mặc định dựa vào role
                switch (role.RoleName)
                {
                    case "BenhNhan":
                        return RedirectToAction("TongQuan", "DatLichHen");
                    case "BacSi":
                        return RedirectToAction("LichLamViec", "BacSi");
                    case "Admin":
                        return RedirectToAction("Dashboard", "Admin");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }

            TempData["LoginError"] = "Tên đăng nhập hoặc mật khẩu không đúng";
            
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
