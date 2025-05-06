using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PBL3.Models;
using PBL3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;

public class LichHenController : Controller
{
    private readonly ILichHenService _lichHenService;
    private readonly IUnitOfWork _unitOfWork;
    
    public LichHenController(ILichHenService lichHenService, IUnitOfWork unitOfWork)
    {
        _lichHenService = lichHenService;
        _unitOfWork = unitOfWork;
    }
    
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> DatLich()
    {
        var viewModel = new DangKyLichHenViewModel
        {
            DanhSachBacSi = (await _lichHenService.GetBacSiKhaDungAsync()).ToList()
        };
        
        return View(viewModel);
    }
    
    [HttpGet]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetNgayKhaDung(int bacSiId)
    {
        var ngayKhaDung = await _lichHenService.GetNgayKhaDungAsync(bacSiId);
        return Json(ngayKhaDung.Select(d => d.ToString("yyyy-MM-dd")));
    }
    
    [HttpGet]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetSlotsKhaDung(int bacSiId, DateTime ngay)
    {
        var slots = await _lichHenService.GetSlotsKhaDungAsync(bacSiId, ngay);
        return Json(slots.Select(s => new
        {
            id = s.Id,
            gioBatDau = s.GioBatDau.ToString(@"hh\:mm"),
            gioKetThuc = s.GioKetThuc.ToString(@"hh\:mm"),
            tienKham = s.TienKham
        }));
    }
    
    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> DatLich(DangKyLichHenViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
            
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var benhNhan = await _unitOfWork.BenhNhans.FirstOrDefaultAsync(b => b.UserId == int.Parse(userId));
        
        if (benhNhan == null)
            return RedirectToAction("Profile", "BenhNhan");
            
        var result = await _lichHenService.DatLichHenAsync(
            benhNhan.Id, 
            model.BacSiId,
            model.SlotId,
            model.LyDoKham);
            
        if (result)
            return RedirectToAction("LichHenDaDat");
            
        ModelState.AddModelError("", "Không thể đặt lịch, vui lòng thử lại sau.");
        model.DanhSachBacSi = (await _lichHenService.GetBacSiKhaDungAsync()).ToList();
        return View(model);
    }
    
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> LichHenDaDat()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var benhNhan = await _unitOfWork.BenhNhans.FirstOrDefaultAsync(b => b.UserId == int.Parse(userId));
        
        if (benhNhan == null)
            return RedirectToAction("Profile", "BenhNhan");
            
        var lichHen = await _lichHenService.GetLichHenSapToiAsync(benhNhan.Id);
        return View(lichHen);
    }
    
    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> HuyLich(int lichHenId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var benhNhan = await _unitOfWork.BenhNhans.FirstOrDefaultAsync(b => b.UserId == int.Parse(userId));
        
        if (benhNhan == null)
            return RedirectToAction("Profile", "BenhNhan");
            
        var result = await _lichHenService.HuyLichHenAsync(lichHenId, benhNhan.Id);
        
        return RedirectToAction("LichHenDaDat");
    }

    [HttpGet]
    public async Task<IActionResult> BookingDetail(int bacSiId)
    {
        var bacSis = await _unitOfWork.BacSis.GetAllIncludingAsync(b => b.Khoa);
        var bacSi = bacSis.FirstOrDefault(b => b.Id == bacSiId);
        
        if (bacSi == null)
            return NotFound();
        
        var ngayHienTai = DateTime.Today;
        var ngayKhaDung = await _lichHenService.GetNgayKhaDungAsync(bacSiId);
        
        var soChoTrong = new Dictionary<DateTime, int>();
        var slotsTheoNgay = new Dictionary<DateTime, List<Slot>>();
        
        foreach (var ngay in ngayKhaDung)
        {
            var slots = await _lichHenService.GetSlotsKhaDungAsync(bacSiId, ngay);
            var danhSachSlot = slots.ToList();
            soChoTrong.Add(ngay, danhSachSlot.Count);
            slotsTheoNgay.Add(ngay, danhSachSlot);
        }
        
        var viewModel = new BacSiDetailViewModel
        {
            BacSi = bacSi,
            NgayKhaDung = ngayKhaDung,
            SoChoTrong = soChoTrong,
            SlotsTheoNgay = slotsTheoNgay
        };
        
        return View("BookingDetail", viewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> DatLichTuDetail(int bacSiId, int slotId, string lyDoKham)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return RedirectToAction("Login", "Account");
        
        var benhNhan = await _unitOfWork.BenhNhans.FirstOrDefaultAsync(b => b.UserId == int.Parse(userId));
        
        if (benhNhan == null)
            return RedirectToAction("Profile", "BenhNhan");
        
        var result = await _lichHenService.DatLichHenAsync(
            benhNhan.Id, 
            bacSiId,
            slotId,
            lyDoKham);
        
        if (result)
            return RedirectToAction("LichHenDaDat");
        
        TempData["ErrorMessage"] = "Không thể đặt lịch, vui lòng thử lại sau.";
        return RedirectToAction("BacSiDetail", new { bacSiId = bacSiId });
    }
}