using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Locations;
using BrightLandsWayfinding.Models.Offices;
using BrightLandsWayfinding.Models.Stories;
using BrightLandsWayfinding.Models.Users;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Stories)
                .WithOne(s => s.Location);
            modelBuilder.Entity<Story>()
                .HasMany(l => l.Offices)
                .WithOne(o => o.Story);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company);
        }

        public DbSet<BrightLandsWayfinding.Models.Users.User> User { get; set; }
    }
}
