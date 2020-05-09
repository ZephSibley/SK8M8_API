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
        public DbSet<ClientMarkerStar> ClientMarkerStar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationType>().HasData(
               new LocationType { Id = 1, Name = "SkatePark" },
               new LocationType { Id = 2, Name = "Rail" },
               new LocationType { Id = 3, Name = "Ramp" },
               new LocationType { Id = 4, Name = "Plaza" },
               new LocationType { Id = 5, Name = "Pump track"},
               new LocationType { Id = 6, Name = "Dirt track"},
               new LocationType { Id = 7, Name = "Skate path"}
            );

            modelBuilder.Entity<ClientMarkerStar>()
                .HasKey(cms => new {cms.ClientId, cms.MapMarkerId});
            modelBuilder.Entity<ClientMarkerStar>()
                .HasOne(cms => cms.Client)
                .WithMany(c => c.ClientMarkerStars)
                .HasForeignKey(cms => cms.ClientId);
            modelBuilder.Entity<ClientMarkerStar>()
                .HasOne(cms => cms.MapMarker)
                .WithMany(m => m.ClientMarkerStars)
                .HasForeignKey(cms => cms.MapMarkerId);

            modelBuilder.Entity<MapMarker>()
                .HasIndex(m => m.Point);
            
            modelBuilder.Entity<Client>()
                .HasIndex(u => u.Id);
            modelBuilder.Entity<Client>()
                .HasIndex(u => u.Geolocation);
            modelBuilder.Entity<Client>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Client>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }   
}
