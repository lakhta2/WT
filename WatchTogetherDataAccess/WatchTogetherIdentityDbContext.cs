using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Configurations;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess
{
    public class WatchTogetherIdentityDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public WatchTogetherIdentityDbContext(DbContextOptions<WatchTogetherIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AlbumsConfiguration());
            builder.ApplyConfiguration(new CurrentlyBroadcastConfiguration());
            builder.ApplyConfiguration(new TrackConfiguration());
            builder.ApplyConfiguration(new TranslationConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserEntity> Users { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public DbSet<TranslationEntity> Translations { get; set; }
        public DbSet<CurrentlyBroadcastEntity> CurrentlyBroadcasts { get; set; }
    }
}
