using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class WalletConfiguration : EntityBaseConfiguration<Wallet>
    {
        public override void Configure(EntityTypeBuilder<Wallet> builder)
        {
            base.Configure(builder);

            builder.HasOne(w => w.Family)
                .WithMany(f => f.Wallets)
                .HasForeignKey(w => w.FamilyID)
                .IsRequired(false);

            builder.HasMany(w => w.PersonWallets)
                .WithOne(pw => pw.Wallet)
                .HasForeignKey(pw => pw.WalletID)
                .IsRequired(true);
        }
    }
}
