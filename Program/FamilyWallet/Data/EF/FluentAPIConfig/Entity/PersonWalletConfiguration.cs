using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class PersonWalletConfiguration : EntityBaseConfiguration<PersonWallet>
    {
        public override void Configure(EntityTypeBuilder<PersonWallet> builder)
        {
            base.Configure(builder);

            builder.HasOne(pw => pw.Person)
                .WithMany(p => p.PersonWallets)
                .HasForeignKey(pw => pw.PersonID)
                .IsRequired(true);

            builder.HasOne(pw => pw.Wallet)
                .WithMany(w => w.PersonWallets)
                .HasForeignKey(pw => pw.WalletID)
                .IsRequired(true);
        }
    }
}
