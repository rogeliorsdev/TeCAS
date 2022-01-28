using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.DAL.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.NoAccount)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false);

            builder.Property(x => x.TypeAccount)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.HasOne(d => d.Customer)
                .WithMany(d => d.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Customer");
        }
    }
}
