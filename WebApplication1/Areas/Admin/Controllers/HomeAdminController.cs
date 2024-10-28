using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using X.PagedList;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        // Database context instance
        private readonly QlbanVaLiContext db;

        public HomeAdminController(QlbanVaLiContext context)
        {
            db = context;
        }

        // Index action to display the admin dashboard
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        // Action to display the product list with pagination
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            // Fetch products and order by product name
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);

            return View(lst);
        }

        // GET action to display the form for adding a new product
        [Route("ThemsanPhamMoi")]
        [HttpGet]
        public IActionResult ThemsanPhamMoi()
        {
            
            // Populate dropdowns for product properties
            
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSX", "HangSX");
            ViewBag.MaNuocSX = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");

            return View();
        }

    }
}
