﻿using System;
using Business.EntityService.Base;
using Business.EntityService.Handler.Interface;
using Business.EntityService.Interface;
using Business.Exceptions;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class OperationService : EntityServiceBase<Operation>, IOperationService
    {
        private readonly IBalanceCalculator balanceCalculator;

        public void CreateOneWalletOperation(int personId, int walletId, int operationCategoryId, decimal balance, string description, DateTime? date)
        {
            CheckArgument.CheckForNull(description, nameof(description));

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);             

            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(walletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            OperationCategory operationCategory = this.UnitOfWork.OperationCategoryRepository.GetById(operationCategoryId)
                ?? throw new InvalidForeignKeyException(typeof(OperationCategory).Name);

            PersonWallet personWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(personId, walletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            wallet.Balance = balanceCalculator.CountNewWalletBalance(wallet.Balance, balance, operationCategory.Type);
            this.UnitOfWork.WalletRepository.Update(wallet);

            OperationInfo operationInfo = new OperationInfo() { Balance = balance, Description = description, Date = date ?? DateTime.Now };
            this.UnitOfWork.OperationInfoRepository.Add(operationInfo);

            Operation operation = new Operation() { OperationCategoryID = operationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = personWallet.ID };
            this.GetRepository().Add(operation);
            this.UnitOfWork.SaveChanges();
        }        

        public void CreateTransaction(int fromPersonId, int fromWalletId, int toPersonId, int toWalletId, decimal balance, string description, DateTime? date)
        {
            CheckArgument.CheckForNull(description, nameof(description));

            Person fromPerson = this.UnitOfWork.PersonRepository.GetById(fromPersonId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Person toPerson = this.UnitOfWork.PersonRepository.GetById(toPersonId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet fromWallet = this.UnitOfWork.WalletRepository.GetById(fromWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            Wallet toWallet = this.UnitOfWork.WalletRepository.GetById(toWalletId)
                ?? throw new InvalidForeignKeyException(typeof(Wallet).Name);

            PersonWallet fromPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(fromPersonId, fromWalletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            PersonWallet toPersonWallet = this.UnitOfWork.PersonWalletRepository.GetPersonWalletByPersonAndWallet(toPersonId, toWalletId)
                ?? throw new InvalidPropertyException(typeof(PersonWallet).Name);

            OperationCategory fromOperationCategory = this.UnitOfWork.OperationCategoryRepository.GetOperationCategoryByTypeAndName(OperationType.Spending, typeof(Transaction).Name);
            if (fromOperationCategory == null)
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

            fromWallet.Balance = balanceCalculator.CountNewWalletBalance(fromWallet.Balance, balance, fromOperationCategory.Type);
            this.UnitOfWork.WalletRepository.Update(fromWallet);

            toWallet.Balance = balanceCalculator.CountNewWalletBalance(toWallet.Balance, balance, toOperationCategory.Type);
            this.UnitOfWork.WalletRepository.Update(toWallet);

            OperationInfo operationInfo = new OperationInfo() { Balance = balance, Description = description, Date = date ?? DateTime.Now };
            this.UnitOfWork.OperationInfoRepository.Add(operationInfo);

            Transaction transaction = new Transaction();
            this.UnitOfWork.TransactionRepository.Add(transaction);

            Operation fromOperation = new Operation() { OperationCategoryID = fromOperationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = fromPersonWallet.ID, TransactionID = transaction.ID };
            this.GetRepository().Add(fromOperation);

            Operation toOperation = new Operation() { OperationCategoryID = toOperationCategory.ID, OperationInfoID = operationInfo.ID, PersonWalletID = toPersonWallet.ID, TransactionID = transaction.ID };
            this.GetRepository().Add(toOperation);
            this.UnitOfWork.SaveChanges();
        }

        protected override IEntityRepository<Operation> GetRepository()
            => this.UnitOfWork.OperationRepository;

        public OperationService(IUnitOfWork unitOfWork, IBalanceCalculator balanceCalculator) 
            : base(unitOfWork)
        {
            CheckArgument.CheckForNull(balanceCalculator, nameof(balanceCalculator));
            this.balanceCalculator = balanceCalculator;
        }
    }
}
