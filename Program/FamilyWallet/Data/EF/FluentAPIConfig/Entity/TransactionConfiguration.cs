using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class TransactionConfiguration : EntityBaseConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.HasMany(t => t.Operations)
                .WithOne(o => o.Transaction)
                .HasForeignKey(o => o.TransactionID)
                .IsRequired(false);
        }
    }
}
