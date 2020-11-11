using EFPlusTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPlusTest.Data.Mappers
{
    class SecondaryEntityMapper : IEntityTypeConfiguration<SecondaryEntity>
    {
        public void Configure(EntityTypeBuilder<SecondaryEntity> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.PropertyA)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.PropertyB)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.PropertyC)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
