using ECommerceMVC.Models;

namespace ECommerceMVC.DI.Interface
{
    public interface IHangHoa
    {
        List<HangHoaViewModel> GetAll(int? loai);
        List<HangHoaViewModel> Search(string? query);
        HangHoaViewModel GetById(int id);

    }
}
