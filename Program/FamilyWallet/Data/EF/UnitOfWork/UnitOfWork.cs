using System;
using System.Collections.Generic;
using System.Text;
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
            ?? (familyRepository = new FamilyRepository(dbContext));

        public IOperationCategoryRepository OperationCategoryRepository => this.operationCategoryRepository
            ?? (this.operationCategoryRepository = new OperationCategoryRepository(dbContext));

        public IOperationInfoRepository OperationInfoRepository => this.operationInfoRepository
            ?? (this.operationInfoRepository = new OperationInfoRepository(dbContext));

        public IOperationRepository OperationRepository => this.operationRepository
            ?? (this.operationRepository = new OperationRepository(dbContext));

        public IPersonFamilyRepository PersonFamilyRepository => this.personFamilyRepository
            ?? (this.personFamilyRepository = new PersonFamilyRepository(dbContext));

        public IPersonRepository PersonRepository => this.personRepository
            ?? (this.personRepository = new PersonRepository(dbContext));

        public IPersonWalletRepository PersonWalletRepository => this.personWalletRepository
            ?? (this.personWalletRepository = new PersonWalletRepository(dbContext));

        public ITransactionRepository TransactionRepository => this.transactionRepository
            ?? (this.transactionRepository = new TransactionRepository(dbContext));

        public IWalletRepository WalletRepository => this.walletRepository
            ?? (this.walletRepository = new WalletRepository(dbContext));
    }
}
