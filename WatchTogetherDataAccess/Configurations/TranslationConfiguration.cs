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
    public class TranslationConfiguration : IEntityTypeConfiguration<TranslationEntity>
    {
        public void Configure(EntityTypeBuilder<TranslationEntity> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Translations);
        }
    }
}
