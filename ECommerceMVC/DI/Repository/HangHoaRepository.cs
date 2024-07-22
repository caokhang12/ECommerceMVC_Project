using ECommerceMVC.DI.Interface;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.DI.Repository
{
    public class HangHoaRepository : IHangHoa
    {
        private readonly HshopContext context;

        public HangHoaRepository(HshopContext context)
        {
            this.context = context;
        }

        public List<HangHoaViewModel> GetAll(int? loai)
        {
            var hangHoas = context.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(hh => hh.MaLoai == loai);
            }
            var result = hangHoas.Select(hh => new HangHoaViewModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia ?? 0,
                Hinh = hh.Hinh ?? "",
                TenLoai = hh.MaLoaiNavigation.TenLoai,
            }).ToList();
            return result;
        }

        public HangHoaViewModel GetById(int id)
        {
            var hangHoa = context.HangHoas
                .Include(hh => hh.MaLoaiNavigation)
                .SingleOrDefault(hh => hh.MaHh == id);
            if (hangHoa == null)
            {
                return null;
            }
            return new HangHoaViewModel
            {
                MaHangHoa = hangHoa.MaHh,
                TenHangHoa = hangHoa.TenHh,
                DonGia = hangHoa.DonGia ?? 0,
                Hinh = hangHoa.Hinh ?? "",
                ChiTiet = hangHoa.MoTa ?? "",
                DiemDanhGia = 0,
                MoTaNgan = hangHoa.MoTaDonVi ?? "",
                TenLoai = hangHoa.MaLoaiNavigation.TenLoai,
            };

        }

        public List<HangHoaViewModel> Search(string? query)
        {
            var hangHoas = context.HangHoas.AsQueryable();
            if (query != null)
            {
                hangHoas = hangHoas.Where(hh => hh.TenHh.Contains(query));
            }
            var result = hangHoas.Select(hh => new HangHoaViewModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia ?? 0,
                Hinh = hh.Hinh ?? "",
                TenLoai = hh.MaLoaiNavigation.TenLoai,
            }).ToList();
            return result;
        }
    }
}
