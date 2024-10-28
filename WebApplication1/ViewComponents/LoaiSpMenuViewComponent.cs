using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository;
namespace WebApplication1.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpR _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpR loaiSpR)
        {
            _loaiSp = loaiSpR;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp); 
        }
    }
}
