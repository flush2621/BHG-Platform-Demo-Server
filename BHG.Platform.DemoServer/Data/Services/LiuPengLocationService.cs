using System;
using System.Collections.Generic;
using System.Linq;
using BHG.Platform.DemoServer.Data.DbContexts;
using BHG.Platform.DemoServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BHG.Platform.DemoServer.Data.Services
{
    public class LiuPengLocationService : ILiuPengLocationService
    {
        private readonly AppDbContext _dbContext;
        public LiuPengLocationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public LiuPengLocation GetLiuPengLocationById(int id)
        {
            return _dbContext.LiuPengLocations.FirstOrDefault(z => z.Id == id);
        }
        public List<LiuPengLocation> ListAllStores()
        {
            return _dbContext.LiuPengLocations.OrderBy(c => c.Id).ToList();
        }
        public List<LiuPengLocation> ListAllLocationsByRegionId(int regionId)
        {
            //List<LiuPengLocation> locs = new List<LiuPengLocation>();
            //var districts = _dbContext.LiuPengDistricts.Include("LiuPengLocations").Where(c=>c.LiuPengRegionId==regionId);
            //foreach (LiuPengDistrict d in districts)
            //{
            //    foreach(LiuPengLocation l in d.LiuPengLocations)
            //    {
            //        locs.Add(l);
            //    }
            //}
            return (from a in _dbContext.LiuPengLocations join b in _dbContext.LiuPengDistricts on a.LiuPengDistrictId equals b.Id where b.LiuPengRegionId == regionId select a).ToList();
            
        }
    }
}
