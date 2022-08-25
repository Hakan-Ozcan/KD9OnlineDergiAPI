using KD9OnlineDergiAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KD9OnlineDergiAPI.Database.Configurations
{
    public class DergiConfiguration : IEntityTypeConfiguration<Dergi>
    {
        public void Configure(EntityTypeBuilder<Dergi> builder)
        {
            builder.HasKey(d=>d.ID);
            builder.HasIndex(d => d.dergiAdı).IsUnique();
            builder.HasOne(x => x.yayınEvi).WithMany(x => x.Dergiler).HasForeignKey(x => x.yayınEviId);
        }
    }
}
