using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Business.Validation.EntityValidation.Interface;
using Business.Validation.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class OperationService : EntityServiceBase<Operation>
    {
        public void CreateOneWalletOperation(int personId, int walletId, decimal balance, string description, string operationName, OperationType operationType, DateTime? date)
        {
            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(walletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            this.ArgumentValidator.CheckForNull(description, nameof(description));
            this.ArgumentValidator.CheckForNull(operationName, nameof(operationName));

            PersonWallet personWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(personId, walletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            OperationCategory operationCategory = this.UnitOfWork.OperationCategoryRepository.GetOperationCategoryByTypeAndName(operationType, operationName);
            if(operationCategory == null)
            {
                operationCategory = new OperationCategory() { Type = operationType, Name = operationName };
                this.UnitOfWork.OperationCategoryRepository.Add(operationCategory);
            }

            this.CountNewWalletBalance(wallet, balance, operationType);

            OperationInfo operationInfo = new OperationInfo() { Balance = balance, Description = description, Date = date ?? DateTime.UtcNow };
            this.UnitOfWork.OperationInfoRepository.Add(operationInfo);

            Operation operation = new Operation() { OperationCategoryID = operationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = personWallet.ID };
            this.UnitOfWork.OperationRepository.Add(operation);
        }

        private void CountNewWalletBalance(Wallet wallet, decimal balance, OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Earning:
                    wallet.Balance += balance;
                    break;
                case OperationType.Spending:
                    wallet.Balance -= balance;
                    break;
            }

            this.UnitOfWork.WalletRepository.Update(wallet);
        }

        public void CreateTransaction(int frompersonId, int fromWalletId, int topersonId, int toWalletId, decimal balance, string description, DateTime? date)
        {
            Person fromPerson = this.UnitOfWork.PersonRepository.GetById(frompersonId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Person toPerson = this.UnitOfWork.PersonRepository.GetById(topersonId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet fromWallet = this.UnitOfWork.WalletRepository.GetById(fromWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            Wallet toWallet = this.UnitOfWork.WalletRepository.GetById(toWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            this.ArgumentValidator.CheckForNull(description, nameof(description));

            PersonWallet fromPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(frompersonId, fromWalletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            PersonWallet toPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(topersonId, toWalletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            OperationCategory fromOperationCategory = this.UnitOfWork.OperationCategoryRepository.GetOperationCategoryByTypeAndName(OperationType.Spending, typeof(Transaction).Name);
            if(fromOperationCategory == null)
            {
                fromOperationCategory = new OperationCategory() { Type = OperationType.Spending, Name = typeof(Transaction).Name };
                this.UnitOfWork.OperationCategoryRepository.Add(fromOperationCategory);
            }

            OperationCategory toOperationCategory = this.UnitOfWork.OperationCategoryRepository.GetOperationCategoryByTypeAndName(OperationType.Earning, typeof(Transaction).Name);
            if (toOperationCategory == null)
            {
                toOperationCategory = new OperationCategory() { Type = OperationType.Earning, Name = typeof(Transaction).Name };
                this.UnitOfWork.OperationCategoryRepository.Add(toOperationCategory);
            }

            this.CountNewWalletBalance(fromWallet, balance, fromOperationCategory.Type);
            this.CountNewWalletBalance(toWallet, balance, toOperationCategory.Type);

            OperationInfo operationInfo = new OperationInfo() { Balance = balance, Description = description, Date = date ?? DateTime.UtcNow };
            this.UnitOfWork.OperationInfoRepository.Add(operationInfo);

            Transaction transaction = new Transaction();
            this.UnitOfWork.TransactionRepository.Add(transaction);

            Operation fromOperation = new Operation() { OperationCategoryID = fromOperationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = fromPersonWallet.ID, TransactionID = transaction.ID };
            this.UnitOfWork.OperationRepository.Add(fromOperation);

            Operation toOperation = new Operation() { OperationCategoryID = toOperationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = toPersonWallet.ID, TransactionID = transaction.ID };
            this.UnitOfWork.OperationRepository.Add(toOperation);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEntityRepository<Operation> GetRepository()
            => this.UnitOfWork.OperationRepository;

        public OperationService(IUnitOfWork unitOfWork, IEntityValidator<Operation> entityValidator, IArgumentValidator argumentValidator) 
            : base(unitOfWork, entityValidator, argumentValidator)
        { }
    }
}
