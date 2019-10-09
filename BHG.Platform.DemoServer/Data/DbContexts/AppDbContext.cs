using BHG.Platform.DemoServer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BHG.Platform.DemoServer.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<LiuPengLocation> LiuPengLocations { get; set; }
        public DbSet<LiuPengDistrict> LiuPengDistricts { get; set; }
        public DbSet<LiuPengRegion> LiuPengRegions { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DS"));
        }

    }
}
