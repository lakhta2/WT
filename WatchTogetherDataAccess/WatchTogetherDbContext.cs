using Microsoft.EntityFrameworkCore;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess
{
    public class WatchTogetherDbContext : DbContext
    {
        public WatchTogetherDbContext(DbContextOptions<WatchTogetherDbContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }
        public DbSet<TranslationEntity> Translations { get; set; }
        public DbSet<CurrentlyBroadcastEntity> CurrentlyBroadcasts { get; set; }

    }
}
