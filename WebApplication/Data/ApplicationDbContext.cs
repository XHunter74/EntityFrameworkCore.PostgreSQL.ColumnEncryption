using AltairCA.EntityFrameworkCore.PostgreSQL.ColumnEncryption.EfExtension;
using Microsoft.EntityFrameworkCore;

namespace EncryptionTest.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Testings> Testings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseEncryptionFunctions("NBJ42RKQ2vQoYFZOj1C83921vHExVhVp1PlOAK6gjbMZI");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasPostgresExtension("pgcrypto");
            builder.UseEncryptAttribute("NBJ42RKQ2vQoYFZOj1C83921vHExVhVp1PlOAK6gjbMZI");
        }
    }
}