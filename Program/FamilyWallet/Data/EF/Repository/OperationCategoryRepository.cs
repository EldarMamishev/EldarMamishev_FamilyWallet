using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class OperationCategoryRepository : EntityRepository<OperationCategory>, IOperationCategoryRepository
    {
        public OperationCategoryRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
