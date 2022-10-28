using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Locations;
using BrightLandsWayfinding.Models.Offices;
using BrightLandsWayfinding.Models.Stories;
using Microsoft.EntityFrameworkCore;

namespace BrightLandsWayfinding.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Office> Offices { get; set; } 
        public DbSet<Story> Stories { get; set; }
    }
}
