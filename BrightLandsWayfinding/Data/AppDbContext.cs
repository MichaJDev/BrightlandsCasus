using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Locations;
using BrightLandsWayfinding.Models.Stories;
using BrightLandsWayfinding.Models.Users;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Models.Steps;
using BrightLandsWayfinding.Models.Rooms;
using BrightLandsWayfinding.Models.Events;

namespace BrightLandsWayfinding.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Step> Step { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .HasMany(l => l.Stories)
                .WithOne(s => s.Building);
            modelBuilder.Entity<Story>()
                .HasMany(l => l.Rooms)
                .WithOne(o => o.Story);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company);
        }

        public DbSet<BrightLandsWayfinding.Models.Events.Event> Event { get; set; }


    }
}
