using ECommerceMVC.DI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IHangHoa _hanghoa;

        public HangHoaController(IHangHoa hangHoa)
        {
            _hanghoa = hangHoa;
        }
        public IActionResult Index(int? loai)
        {
            var dsHangHoa = _hanghoa.GetAll(loai);
            return View(dsHangHoa);
        }

        public IActionResult Search(string? query)
        {
            var dsHangHoa = _hanghoa.Search(query);
            return View(dsHangHoa);
        }

        public IActionResult Detail(int id)
        {
            var hangHoa = _hanghoa.GetById(id);
            if (hangHoa == null)
            {
                return RedirectToAction("Error404", "Home");
            }
            return View(hangHoa);
        }
    }
}
