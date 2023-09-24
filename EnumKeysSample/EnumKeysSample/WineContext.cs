using Microsoft.EntityFrameworkCore;

namespace EnumKeysSample
{
    public class WineContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<WineTypeDetails> WineTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wines.db");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Wine>()
                .Property(w => w.Type)
                .HasConversion<int>();

            mb.Entity<WineTypeDetails>()
                .Property(t => t.Type)
                .HasConversion<int>();

            mb.Entity<WineTypeDetails>()
                .HasKey(t => t.Type);

            mb
                .Entity<WineTypeDetails>()
                .HasMany(w => w.Wines)
                .WithOne(t => t.TypeDetails)
                .HasForeignKey(w => w.Type)
                .HasPrincipalKey(t => t.Type);

            mb.Entity<WineTypeDetails>().HasData(
              Enum.GetValues(typeof(WineType))
                       .Cast<WineType>()
                       .Select(t => new WineTypeDetails()
                       {
                           Type = t,
                           Name = t.ToString()
                       })
                );
        }
    }
}
