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
    public class CurrentlyBroadcastConfiguration : IEntityTypeConfiguration<CurrentlyBroadcastEntity>
    {
        public void Configure(EntityTypeBuilder<CurrentlyBroadcastEntity> builder)
        {
            builder.HasKey(c => c.BroadcasterId);

            //builder.HasMany(c => c.Users);

        }
    }
}
