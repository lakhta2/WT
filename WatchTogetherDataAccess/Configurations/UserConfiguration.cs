using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchTogetherDataAccess.Entities;
using WatchTogetherCore.Models;

namespace WatchTogetherDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(u => u.Albums)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.ArtistId);

            builder
                .HasMany(u => u.Tracks)
                .WithOne(t => t.Author)
                .HasForeignKey(t => t.AuthorId);

            builder
                .HasMany(u => u.Translations)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
