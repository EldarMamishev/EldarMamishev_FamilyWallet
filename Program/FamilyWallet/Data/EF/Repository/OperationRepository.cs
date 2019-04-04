using System;
using System.Collections.Generic;
using System.Linq;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class OperationRepository : EntityRepository<Operation>, IOperationRepository
    {
        public OperationRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<Operation> GetOperationsByDatePeriod(DateTime fromDate, DateTime toDate)
            => this.dbContext.Set<Operation>().Where(o => o.OperationInfo.Date >= fromDate && o.OperationInfo.Date <= toDate).ToList();

        public ICollection<Operation> GetOperationsByFamilyId(int familyId)
            => this.dbContext.Set<Operation>().Where(o => o.PersonWallet.Wallet.FamilyID.Value == familyId).ToList();

        public ICollection<Operation> GetOperationsByOperationCategoryId(int operationCategoryId)
            => this.dbContext.Set<Operation>().Where(o => o.OperationCategoryID.Value == operationCategoryId).ToList();

        public ICollection<Operation> GetOperationsByOperationType(OperationType operationType)
            => this.dbContext.Set<Operation>().Where(o => o.OperationCategory.Type == operationType).ToList();

        public ICollection<Operation> GetOperationsByPersonId(int personId)
            => this.dbContext.Set<Operation>().Where(o => o.PersonWallet.PersonID.Value == personId).ToList();

        public ICollection<Operation> GetOperationsByTransactionId(int transactionId)
            => this.dbContext.Set<Operation>().Where(o => o.TransactionID.Value == transactionId).ToList();

        public ICollection<Operation> GetOperationsByWalletId(int walletId)
            => this.dbContext.Set<Operation>().Where(o => o.PersonWallet.WalletID.Value == walletId).ToList();
    }
}
