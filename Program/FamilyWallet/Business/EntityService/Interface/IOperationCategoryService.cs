using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enum;

namespace Business.EntityService.Interface
{
    public interface IOperationCategoryService
    {
        void Create(string name, OperationType operationType);
    }
}
