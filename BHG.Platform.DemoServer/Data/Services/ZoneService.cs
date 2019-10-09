using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHG.Platform.DemoServer.Data.DbContexts;
using BHG.Platform.DemoServer.Data.Entities;

namespace BHG.Platform.DemoServer.Data.Services
{
    public class ZoneService : IZoneService
    {
        private readonly AppDbContext _dbContext;

        public ZoneService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Zone GetZoneById(string id)
        {
            return _dbContext.Zones.FirstOrDefault(z => z.Id == id);
        }
    }
}
