using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SE310_28102024.Models;
using X.PagedList;

namespace SE310_28102024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        ProductContext db = new ProductContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 20;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.Products.AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> lst = new PagedList<Product>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]

        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult SuaSanPham(int Id)
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            var sanPham = db.Products.Find(Id);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]

        public IActionResult XoaSanPham(int Id)
        {
            TempData["Message"] = "";
            db.Remove(db.Products.Find(Id));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    };
}
