using System.Collections.Generic;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IOperationCategoryRepository : IEntityRepository<OperationCategory>
    {
        OperationCategory GetOperationCategoryByTypeAndName(OperationType operationType, string name);
        ICollection<OperationCategory> GetOperationCategoriesByType(OperationType operationType); 
    }
}
