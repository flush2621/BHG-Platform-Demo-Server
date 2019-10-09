using BHG.Platform.DemoServer.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BHG.Platform.DemoServer.Data.Services
{
    public interface ILiuPengLocationService
    {
        LiuPengLocation GetLiuPengLocationById(int Id);
        List<LiuPengLocation> ListAllStores();
        List<LiuPengLocation> ListAllLocationsByRegionId(int regionId);
    }
}
