using ECommerceMVC.DI.Interface;
using ECommerceMVC.Models;
using ECommerceMVC.Helpers;
using ECommerceMVC.Data;

namespace ECommerceMVC.DI.Repository
{
    public class GioHangRepository : IGioHang
    {
        private readonly HshopContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        const string CART_KEY = "MYCART";

        public GioHangRepository(HshopContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<CartItem> Cart => _httpContextAccessor.HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();

        public List<CartItem> GioHang()
        {
            return Cart;
        }

        public void ThemVaoGio(int id, int quantity)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(x => x.MaHang == id);
            if (item == null)
            {
                var hh = _context.HangHoas.SingleOrDefault(x => x.MaHh == id);
                if (hh == null) return;
                cart.Add(new CartItem
                {
                    MaHang = hh.MaHh,
                    TenHang = hh.TenHh,
                    DonGia = hh.DonGia ?? 0,
                    Hinh = hh.Hinh ?? string.Empty,
                    SoLuong = quantity
                });
            }
            else
            {
                item.SoLuong += quantity;
            }
            _httpContextAccessor.HttpContext.Session.Set(CART_KEY, cart);
        }

        public void XoaGioHang(int id)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(x => x.MaHang == id);
            if (item != null)
            {
                cart.Remove(item);
                _httpContextAccessor.HttpContext.Session.Set(CART_KEY, cart);
            }
        }
    }
}
