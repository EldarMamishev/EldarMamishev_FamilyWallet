using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Data.EF
{
    public class FamilyWalletContext : DbContext
    {
        public FamilyWalletContext() : base()
        { }

        public FamilyWalletContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Family> Families { get; }
        public DbSet<Operation> Operations { get; }
        public DbSet<OperationCategory> OperationCategories { get; }
        public DbSet<OperationInfo> OperationInfos { get; }
        public DbSet<Person> People { get; }
        public DbSet<PersonFamily> PersonFamilies { get; }
        public DbSet<PersonWallet> PersonWallets { get; }
        public DbSet<Transaction> Transactions { get; }
        public DbSet<Wallet> Wallets { get; }
    }
}
