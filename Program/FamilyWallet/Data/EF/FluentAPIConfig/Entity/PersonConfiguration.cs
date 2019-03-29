using Data.EF.FluentAPIConfig.Entity.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.FluentAPIConfig.Entity
{
    public class PersonConfiguration : EntityBaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.HasMany(p => p.PersonFamilies)
                .WithOne(pf => pf.Person)
                .HasForeignKey(pf => pf.PersonID)
                .IsRequired(true);

            builder.HasMany(p => p.PersonWallets)
                .WithOne(pw => pw.Person)
                .HasForeignKey(pw => pw.PersonID)
                .IsRequired(true);
        }
    }
}
