using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class OperationCategoryConfiguration : EntityBaseConfiguration<OperationCategory>
    {
        public override void Configure(EntityTypeBuilder<OperationCategory> builder)
        {
            base.Configure(builder);

            builder.HasMany(oc => oc.Operations)
                .WithOne(o => o.OperationCategory)
                .HasForeignKey(o => o.OperationCategoryID)
                .IsRequired(true);
        }
    }
}
