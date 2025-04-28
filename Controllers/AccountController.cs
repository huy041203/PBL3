using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PBL3.Models.ViewModels;
using PBL3.Services;
using PBL3.Models;

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


                
                // Điều hướng mặc định dựa vào role
                switch (role.RoleName)
                {
                    case "Patient":
                        return RedirectToAction("Booking", "Home");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra email đã tồn tại
                var existingUser = await _authService.GetUserByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    TempData["RegisterError"] = "Email này đã được sử dụng";
                    
                    // Trả về trang hiện tại
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                
                // Tạo user mới
                var user = new User
                {
                    Username = model.Email,
                    Email = model.Email,
                    FullName = model.FullName,
                    Password = PasswordHasher.HashPassword(model.Password),
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Gender = model.Gender,
                    RoleId = 3, // Role cho BenhNhan
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                
                // Tạo bệnh nhân
                var benhNhan = new BenhNhan
                {
                    UserId = user.Id,
                    CCCD = model.IdentityCard,
                    NgaySinh = model.DateOfBirth
                };
                
                await _unitOfWork.BenhNhans.AddAsync(benhNhan);
                await _unitOfWork.CompleteAsync();
                
                // Đăng nhập tự động
                var role = _unitOfWork.Roles.GetById(user.RoleId);
                var principal = _authService.CreateClaimsPrincipal(user, role.RoleName);
                
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };
                
                await HttpContext.SignInAsync("CookieAuth", principal, authProperties);
                
                TempData["Success"] = "Đăng ký thành công!";
                
                // Chuyển hướng
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            
            // Nếu có lỗi validation
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    TempData["RegisterError"] = error.ErrorMessage;
                    break;
                }
                if (TempData["RegisterError"] != null) break;
            }
            
            // Trả về trang hiện tại
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
