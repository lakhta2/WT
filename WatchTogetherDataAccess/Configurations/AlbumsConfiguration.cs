using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess.Configurations
{
    public class AlbumsConfiguration : IEntityTypeConfiguration<AlbumEntity>
    {
        public void Configure(EntityTypeBuilder<AlbumEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .HasOne(a => a.Author)
                .WithMany(a => a.Albums);

            builder
                .HasMany(a => a.Tracks)
                .WithOne(t => t.AlbumReference)
                .HasForeignKey(t => t.AlbumId);
        }
    }
}
