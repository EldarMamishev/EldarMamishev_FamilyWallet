using System;
using System.Collections.Generic;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        ICollection<Operation> GetOperationsByDatePeriod(DateTime fromDate, DateTime toDate);
        ICollection<Operation> GetOperationsByFamilyId(int familyId);
        ICollection<Operation> GetOperationsByOperationCategoryId(int operationCategoryId);
        ICollection<Operation> GetOperationsByOperationType(OperationType operationType);
        ICollection<Operation> GetOperationsByPersonId(int personId);
        ICollection<Operation> GetOperationsByTransactionId(int transactionId);
        ICollection<Operation> GetOperationsByWalletId(int walletId);
        ICollection<Operation> GetOperationsByPersonAndWalletId(int personId, int walletId);
    }
}
