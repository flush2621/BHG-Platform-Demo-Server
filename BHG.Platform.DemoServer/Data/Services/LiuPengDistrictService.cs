using System;
using BHG.Platform.DemoServer.Data.DbContexts;
using BHG.Platform.DemoServer.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BHG.Platform.DemoServer.Data.Services
{
    public class LiuPengDistrictService : ILiuPengDistrictService
    {
        private readonly AppDbContext _dbContext;
        public LiuPengDistrictService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LiuPengDistrict GetLiuPengDistrictById(int id)
        {
            return _dbContext.LiuPengDistricts.FirstOrDefault(z => z.Id == id);
        }
        public LiuPengDistrict GetDistrictWithLocaitonsById(int id)
        {
            return _dbContext.LiuPengDistricts.Include("LiuPengLocations").FirstOrDefault(z => z.Id == id);
        }
    }
}
