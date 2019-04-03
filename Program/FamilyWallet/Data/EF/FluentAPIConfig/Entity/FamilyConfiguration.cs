using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class FamilyConfiguration : EntityBaseConfiguration<Family>
    {
        public override void Configure(EntityTypeBuilder<Family> builder)
        {
            base.Configure(builder);

            builder.HasMany(f => f.PersonFamilies)
                .WithOne(pf => pf.Family)
                .HasForeignKey(pf => pf.FamilyID)
                .IsRequired(true);

            builder.HasMany(f => f.Wallets)
                .WithOne(w => w.Family)
                .HasForeignKey(w => w.FamilyID)
                .IsRequired(false);

            builder.Property(f => f.Name)
                .IsRequired(true);
        }
    }
}
