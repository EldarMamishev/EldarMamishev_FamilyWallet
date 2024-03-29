﻿using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class OperationInfoRepository : EntityRepository<OperationInfo>, IOperationInfoRepository
    {
        public OperationInfoRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
