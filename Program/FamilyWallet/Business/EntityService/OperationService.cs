using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;

namespace Business.EntityService
{
    public class OperationService : EntityServiceBase<Operation>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Operation> GetAll()
            => this.GetAll(this.UnitOfWork.OperationRepository);

        public override Operation GetById(int id)
            => this.GetById(id, this.UnitOfWork.OperationRepository);

        public OperationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public void CreateOneWalletOperation(int userId, int walletId, int balance, string description, string operationName, OperationType operationType, DateTime? date)
        {
            Person person = this.UnitOfWork.PersonRepository.GetById(userId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(walletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            if (balance <= 0)
                throw new InvalidPropertyException(nameof(balance));

            PersonWallet personWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(userId, walletId)
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

        public void CreateTransaction(int fromUserId, int fromWalletId, int toUserId, int toWalletId, int balance, string description, DateTime? date)
        {
            Person fromPerson = this.UnitOfWork.PersonRepository.GetById(fromUserId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Person toPerson = this.UnitOfWork.PersonRepository.GetById(toUserId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet fromWallet = this.UnitOfWork.WalletRepository.GetById(fromWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            Wallet toWallet = this.UnitOfWork.WalletRepository.GetById(toWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            if (balance <= 0)
                throw new InvalidPropertyException(nameof(balance));

            PersonWallet fromPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(fromUserId, fromWalletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            PersonWallet toPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(toUserId, toWalletId)
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

        private void CountNewWalletBalance(Wallet wallet, int balance, OperationType operationType)
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
    }
}
