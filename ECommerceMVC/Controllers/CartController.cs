using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Helpers;
using ECommerceMVC.DI.Interface;

namespace ECommerceMVC.Controllers
{
    public class CartController : Controller
    {

        private readonly IGioHang _gioHang;
        public CartController(IGioHang gioHang) => _gioHang = gioHang;

        public IActionResult Index()
        {
            var cart = _gioHang.GioHang();
            return View(cart);
        }
        public IActionResult AddToCart(int id,int quantity = 1)
        {
            _gioHang.ThemVaoGio(id, quantity);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _gioHang.XoaGioHang(id);
            return RedirectToAction("Index");
        }
    }
}

