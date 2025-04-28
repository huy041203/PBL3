using Microsoft.AspNetCore.Mvc;
using PBL3.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> Booking()
        {
            // Lấy danh sách bác sĩ từ cơ sở dữ liệu
            var bacSis = await _unitOfWork.BacSis.FindAsync(bs => bs.IsActive);
            
            // Nếu cần lấy thêm thông tin khoa của bác sĩ, bạn có thể sử dụng Include
            // Điều này cần được cài đặt trong GenericRepository
            
            return View(bacSis);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
