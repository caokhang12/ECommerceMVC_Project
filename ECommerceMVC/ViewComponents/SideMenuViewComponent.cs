using ECommerceMVC.Data;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECommerceMVC.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        private readonly HshopContext _db;
        public SideMenuViewComponent(HshopContext dbContext) => _db = dbContext;

        public IViewComponentResult Invoke()
        {
            var menu = _db.Loais.Select(loai => new LoaiViewModel
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
                SoLuong = loai.HangHoas.Count()
            });
            return View(menu);
        }
    }
}
