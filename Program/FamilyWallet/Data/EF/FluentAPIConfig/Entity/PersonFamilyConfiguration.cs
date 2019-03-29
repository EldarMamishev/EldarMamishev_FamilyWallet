using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class PersonFamilyConfiguration : EntityBaseConfiguration<PersonFamily>
    {
        public override void Configure(EntityTypeBuilder<PersonFamily> builder)
        {
            base.Configure(builder);

            builder.HasOne(pf => pf.Person)
                .WithMany(p => p.PersonFamilies)
                .HasForeignKey(pf => pf.PersonID)
                .IsRequired(true);

            builder.HasOne(pf => pf.Family)
                .WithMany(f => f.PersonFamilies)
                .HasForeignKey(pf => pf.FamilyID)
                .IsRequired(true);
        }
    }
}
