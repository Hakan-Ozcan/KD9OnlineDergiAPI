using KD9OnlineDergiAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KD9OnlineDergiAPI.Database.Configurations
{
    public class YayınEviConfiiguration : IEntityTypeConfiguration<YayınEvi>
    {
        public void Configure(EntityTypeBuilder<YayınEvi> builder)
        {
            //İmplicit
            builder.HasKey(ye => ye.ID);
            //Explicit
            builder.HasIndex(ye => ye.Name).IsUnique();

            builder.HasMany(y => y.Dergiler).WithOne(y => y.yayınEvi).HasForeignKey(y => y.yayınEviId);
        }
    }
}
