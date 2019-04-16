using System.Collections.Generic;
using Data.EF.FluentAPIConfig;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class FamilyWalletContext : DbContext
    {
        public FamilyWalletContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ModelConfigurationHandler().SetConfigurations(modelBuilder);
        }

        private void Initialize()
        {
            Person person = new Person() { Name = "Bob", Surname = "Smith" };
            this.People.Add(person);

            List<Family> families = new List<Family>()
            {
                new Family() { Name = "Parents" },
                new Family() { Name = "Pair" },
                new Family() { Name = "Friends" }
            };
            families.ForEach(f => this.Families.Add(f));

            List<PersonFamily> personFamilies = new List<PersonFamily>()
            {
                new PersonFamily{ PersonID = person.ID, FamilyID = families[0].ID},
                new PersonFamily{ PersonID = person.ID, FamilyID = families[1].ID},
                new PersonFamily{ PersonID = person.ID, FamilyID = families[2].ID}
            };
            personFamilies.ForEach(pf => this.PersonFamilies.Add(pf));

            this.SaveChanges();
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationCategory> OperationCategories { get; set; }
        public DbSet<OperationInfo> OperationInfos { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonFamily> PersonFamilies { get; set; }
        public DbSet<PersonWallet> PersonWallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
