using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(x => x.INE)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
