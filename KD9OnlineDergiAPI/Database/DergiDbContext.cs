using KD9OnlineDergiAPI.Database.Configurations;
using KD9OnlineDergiAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace KD9OnlineDergiAPI.Database
{
    public class DergiDbContext:DbContext
    {
        public DergiDbContext():base()
        {

        }

        public DbSet<Dergi> Dergiler { get; set; }
        public DbSet<Sayı> Sayılar { get; set; }
        public DbSet<YayınEvi> YayınEvleri { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-MLA1I95\\SQLEXPRESS;Database=KD9OnlineDergi;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DergiConfiguration());
            modelBuilder.ApplyConfiguration(new SayıConfiguration());
            modelBuilder.ApplyConfiguration(new YayınEviConfiiguration());
            modelBuilder.ApplyConfiguration(new YazarConfiguration());
            
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(YayınEviConfiiguration).Assembly);
        }
    }
}
