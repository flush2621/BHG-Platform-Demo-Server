using BHG.Platform.DemoServer.Data.Entities;

namespace BHG.Platform.DemoServer.Data.Services
{
    public interface ILiuPengDistrictService
    {
        LiuPengDistrict GetLiuPengDistrictById(int Id);
        LiuPengDistrict GetDistrictWithLocaitonsById(int id);
    }
}
