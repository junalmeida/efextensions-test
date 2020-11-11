using EFPlusTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPlusTest.Data.Mappers
{
    class MainEntityMapper : IEntityTypeConfiguration<MainEntity>
    {
        public void Configure(EntityTypeBuilder<MainEntity> builder)
        {
            builder.Property(x => x.Id)
               .HasDefaultValueSql("newid()");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Secondaries)
                .WithOne().IsRequired();

            builder.Property(x => x.TestRound)
                .IsRequired();

            builder.HasIndex(x => x.TestRound);
        }
    }
}
