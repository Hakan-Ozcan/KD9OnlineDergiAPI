using KD9OnlineDergiAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KD9OnlineDergiAPI.Database.Configurations
{
    public class SayıConfiguration : IEntityTypeConfiguration<Sayı>
    {
        public void Configure(EntityTypeBuilder<Sayı> builder)
        {
            builder.HasKey(x => new { x.DergiId, x.sayı });
            builder.HasOne(x=>x.Dergi).WithMany(x=>x.Sayılar).HasForeignKey(x=>x.DergiId);
        }
    }

}
