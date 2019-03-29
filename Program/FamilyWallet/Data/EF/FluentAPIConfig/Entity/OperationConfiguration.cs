using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class OperationConfiguration : EntityBaseConfiguration<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            base.Configure(builder);

            builder.HasOne(o => o.Transaction)
                .WithMany(t => t.Operations)
                .HasForeignKey(o => o.TransactionID)
                .IsRequired(false);

            builder.HasOne(o => o.OperationInfo)
                .WithMany(oi => oi.Operations)
                .HasForeignKey(o => o.OperationInfoID)
                .IsRequired(true);

            builder.HasOne(o => o.OperationCategory)
                .WithMany(oc => oc.Operations)
                .HasForeignKey(o => o.OperationCategoryID)
                .IsRequired(true);

            builder.HasOne(o => o.PersonWallet)
                .WithMany(pw => pw.Operations)
                .HasForeignKey(o => o.PersonWalletID)
                .IsRequired(true);
        }
    }
}
