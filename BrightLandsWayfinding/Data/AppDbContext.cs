using BrightLandsWayfinding.Models.Companies;
using BrightLandsWayfinding.Models.Stories;
using BrightLandsWayfinding.Models.Users;
using Microsoft.EntityFrameworkCore;
using BrightLandsWayfinding.Models.Steps;
using BrightLandsWayfinding.Models.Rooms;
using BrightLandsWayfinding.Models.Events;
using BrightLandsWayfinding.Models.Buildings;
using BrightLandsWayfinding.Models.MapRoutes;

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
        public DbSet<Event> Event { get; set; }
        public DbSet<MapRoute> Routes { get; set; }
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
            modelBuilder.Entity<MapRoute>()
                .HasMany(mr => mr.Steps)
                .WithOne(s => s.MapRoute);
        }




    }
}
