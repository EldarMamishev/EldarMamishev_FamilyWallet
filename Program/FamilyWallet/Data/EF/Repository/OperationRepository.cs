using System;
using System.Collections.Generic;
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
        {
            throw new NotImplementedException();
        }

        public ICollection<Operation> GetOperationsByTransactionId(int transactionId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Operation> GetOperationsByWalletId(int walletId)
        {
            throw new NotImplementedException();
        }
    }
}
