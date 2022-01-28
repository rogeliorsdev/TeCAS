using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeCAS.SCA.Entities;

namespace TeCAS.SCA.DAL.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.AccountId)
                .IsRequired();

            builder.Property(x => x.CurrentBalance)
                .IsRequired();

            builder.Property(x => x.MovementAmount)
                .IsRequired();

            builder.Property(x => x.TypeTransaction)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.HasOne(d => d.Account)
                .WithMany(d => d.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Account");
        }
    }
}
