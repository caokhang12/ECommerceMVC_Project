using ECommerceMVC.Models;

namespace ECommerceMVC.DI.Interface
{
    public interface IGioHang
    {
        List<CartItem> GioHang();
        void ThemVaoGio(int id ,int quantity);
        void XoaGioHang(int id);

    }
}
