using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess.Configurations
{
    public class TrackConfiguration : IEntityTypeConfiguration<TrackEntity>
    {
        public void Configure(EntityTypeBuilder<TrackEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(a => a.Author)
                .WithMany(u => u.Tracks);

            builder
                .HasOne(t => t.AlbumReference)
                .WithMany(a => a.Tracks);
        }
    }
}
