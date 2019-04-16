using Domain.Enum;

namespace Business.EntityService.Interface
{
    public interface IOperationCategoryService
    {
        void Create(string name, OperationType operationType);
    }
}
