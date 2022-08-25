using KD9OnlineDergiAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KD9OnlineDergiAPI.Database.Configurations
{
    public class YazarConfiguration : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.YazdığıSayılar).WithMany(x => x.Yazarlar);
        }
    }
}
