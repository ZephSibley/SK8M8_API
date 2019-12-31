using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
