using System.Collections.Generic;
using System.Linq;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class OperationRepository : EntityRepository<Operation>, IOperationRepository
    {
        public OperationRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<Operation> GetOperationsByPersonId(int personId)
            => this.dbContext.Set<Operation>().Where(o => o.PersonWallet.PersonID.Value == personId).ToList();

        public ICollection<Operation> GetOperationsByTransactionId(int transactionId)
            => this.dbContext.Set<Operation>().Where(o => o.TransactionID.Value == transactionId).ToList();

        public ICollection<Operation> GetOperationsByWalletId(int walletId)
            => this.dbContext.Set<Operation>().Where(o => o.PersonWallet.WalletID.Value == walletId).ToList();
    }
}
