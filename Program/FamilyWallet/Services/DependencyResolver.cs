using Business.EntityService;
using Business.EntityService.Handler;
using Business.EntityService.Handler.Interface;
using Business.EntityService.Interface;
using Data.EF;
using Data.EF.Repository;
using Data.EF.UnitOfWork;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository;
using Domain.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class DependencyResolver
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddTransient<DbContext, FamilyWalletContext>();
            ConfigureEntities(services);
            ConfigureServices(services);
        }

        static void ConfigureEntities(IServiceCollection services)
        {
            services.AddTransient<IEntityRepository<Person>, PersonRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<IEntityRepository<Wallet>, WalletRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();

            services.AddTransient<IEntityRepository<Family>, FamilyRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();

            services.AddTransient<IEntityRepository<PersonFamily>, PersonFamilyRepository>();
            services.AddTransient<IPersonFamilyRepository, PersonFamilyRepository>();

            services.AddTransient<IEntityRepository<PersonWallet>, PersonWalletRepository>();
            services.AddTransient<IPersonWalletRepository, PersonWalletRepository>();

            services.AddTransient<IEntityRepository<Operation>, OperationRepository>();
            services.AddTransient<IOperationRepository, OperationRepository>();

            services.AddTransient<IEntityRepository<OperationInfo>, OperationInfoRepository>();
            services.AddTransient<IOperationInfoRepository, OperationInfoRepository>();

            services.AddTransient<IEntityRepository<OperationCategory>, OperationCategoryRepository>();
            services.AddTransient<IOperationCategoryRepository, OperationCategoryRepository>();

            services.AddTransient<IEntityRepository<Transaction>, TransactionRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IFamilyService, FamilyService>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IOperationCategoryService, OperationCategoryService>();

            services.AddTransient<IBalanceCalculator, BalanceCalculator>();
        }
    }
}
