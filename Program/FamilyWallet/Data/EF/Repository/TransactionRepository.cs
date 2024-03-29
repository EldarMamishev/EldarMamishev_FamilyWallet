﻿using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class TransactionRepository : EntityRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
