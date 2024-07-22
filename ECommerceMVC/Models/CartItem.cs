namespace ECommerceMVC.Models
{
    public class CartItem
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
        public string Hinh { get; set; }
    }
}
