using Microsoft.EntityFrameworkCore;

namespace Sk8M8_API.Models
{
    public class SkateContext : DbContext
    {
        public SkateContext(DbContextOptions<SkateContext> options) : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientLogin> ClientLogin { get; set; }
        public DbSet<MapMarker> MapMarker { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }
        public DbSet<MediaRating> MediaRating { get; set; }
        public DbSet<MarkerCategory> MarkerCategory { get; set; }
        public DbSet<ClientMarker> ClientMarker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationType>().HasData(
               new LocationType { Id = 1, Name = "SkatePark" },
               new LocationType { Id = 2, Name = "Rail" },
               new LocationType { Id = 3, Name = "Ramp" },
               new LocationType { Id = 4, Name = "Plaza" }
            );
        }
    }   
}
