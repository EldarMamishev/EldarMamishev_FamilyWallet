﻿using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface ITransactionRepository : IEntityRepository<Transaction>
    {
    }
}
