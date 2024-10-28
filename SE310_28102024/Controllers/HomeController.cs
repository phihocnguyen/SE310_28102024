﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310_WebAPI.Models;
using System.Diagnostics;
using X.PagedList;

namespace WebBanThucAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HanghoaContext db = new HanghoaContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.HangHoas.AsNoTracking().OrderBy(x => x.TenHang);
            PagedList<HangHoa> lst = new PagedList<HangHoa>(lstSanPham, pageNumber, pageSize);
            
            return View(lst);
        }
        //public IActionResult ChiTietSanPham(string maSp)
        //{
        //    var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
        //    var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
        //    ViewBag.anhSanPham = anhSanPham;
        //    return View(sanPham);
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}