using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class OperationInfoConfiguration : EntityBaseConfiguration<OperationInfo>
    {
        public override void Configure(EntityTypeBuilder<OperationInfo> builder)
        {            
            base.Configure(builder);

            builder.HasMany(oi => oi.Operations)
                .WithOne(o => o.OperationInfo)
                .HasForeignKey(o => o.OperationInfoID)
                .IsRequired(true);

            builder.Property(oi => oi.Date)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()")
                .IsRequired(true);

            builder.Property(oi => oi.Description)
                .IsRequired(true);

            builder.Property(oi => oi.Balance)
                .IsRequired(true);
        }
    }
}
