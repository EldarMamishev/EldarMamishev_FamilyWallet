using Data.EF.FluentAPIConfig.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.FluentAPIConfig
{
    public sealed class ModelConfigurationHandler
    {
        public void SetConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new PersonFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            modelBuilder.ApplyConfiguration(new PersonWalletConfiguration());
            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new OperationInfoConfiguration());
            modelBuilder.ApplyConfiguration(new OperationCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
