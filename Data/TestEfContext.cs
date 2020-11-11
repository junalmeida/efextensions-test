using EFPlusTest.Data.Mappers;
using EFPlusTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFPlusTest.Data
{
    public class TestEfContext : DbContext
    {
        public TestEfContext()
        {
        }

        public DbSet<MainEntity> MainEntitites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainEntityMapper).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=ef-test;Trusted_Connection=True;",
                cfg =>
                {
                    cfg.CommandTimeout(100);
                    cfg.EnableRetryOnFailure();
                });
        }
    }
}
