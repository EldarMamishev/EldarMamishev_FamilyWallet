﻿using System.Collections.Generic;
using System.Linq;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class OperationCategoryRepository : EntityRepository<OperationCategory>, IOperationCategoryRepository
    {
        public OperationCategoryRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<OperationCategory> GetOperationCategoriesByType(OperationType operationType)
            => this.dbContext.Set<OperationCategory>().Where(oc => oc.Type == operationType).ToList();

        public OperationCategory GetOperationCategoryByTypeAndName(OperationType operationType, string name)
            => this.dbContext.Set<OperationCategory>().FirstOrDefault(oc => oc.Type == operationType && oc.Name.ToUpper() == name.ToUpper());
    }
}
