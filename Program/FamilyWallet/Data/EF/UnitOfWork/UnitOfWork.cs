using Data.EF.Repository;
using Data.EF.UnitOfWork.Interface;
using Domain.Repository;

namespace Data.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private FamilyWalletContext dbContext;
        private IFamilyRepository familyRepository;
        private IOperationCategoryRepository operationCategoryRepository;
        private IOperationInfoRepository operationInfoRepository;
        private IOperationRepository operationRepository;
        private IPersonFamilyRepository personFamilyRepository;
        private IPersonRepository personRepository;
        private IPersonWalletRepository personWalletRepository;
        private ITransactionRepository transactionRepository;
        private IWalletRepository walletRepository;

        public IFamilyRepository FamilyRepository => this.familyRepository 
            ?? (familyRepository = new FamilyRepository(this.dbContext));

        public IOperationCategoryRepository OperationCategoryRepository => this.operationCategoryRepository
            ?? (this.operationCategoryRepository = new OperationCategoryRepository(this.dbContext));

        public IOperationInfoRepository OperationInfoRepository => this.operationInfoRepository
            ?? (this.operationInfoRepository = new OperationInfoRepository(this.dbContext));

        public IOperationRepository OperationRepository => this.operationRepository
            ?? (this.operationRepository = new OperationRepository(this.dbContext));

        public IPersonFamilyRepository PersonFamilyRepository => this.personFamilyRepository
            ?? (this.personFamilyRepository = new PersonFamilyRepository(this.dbContext));

        public IPersonRepository PersonRepository => this.personRepository
            ?? (this.personRepository = new PersonRepository(this.dbContext));

        public IPersonWalletRepository PersonWalletRepository => this.personWalletRepository
            ?? (this.personWalletRepository = new PersonWalletRepository(this.dbContext));

        public void SaveChanges()
            => this.dbContext.SaveChanges();

        public ITransactionRepository TransactionRepository => this.transactionRepository
            ?? (this.transactionRepository = new TransactionRepository(this.dbContext));

        public UnitOfWork(FamilyWalletContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWalletRepository WalletRepository => this.walletRepository
            ?? (this.walletRepository = new WalletRepository(this.dbContext));
    }
}
