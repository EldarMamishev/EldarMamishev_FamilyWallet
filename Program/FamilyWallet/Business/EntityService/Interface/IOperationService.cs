using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Base.Interface;
using Domain.Entity;
using Domain.Enum;

namespace Business.EntityService.Interface
{
    public interface IOperationService : IEntityService<Operation>
    {
        void CreateOneWalletOperation(int personId, int walletId, decimal balance, string description, string operationName, OperationType operationType, DateTime? date);
        void CreateTransaction(int frompersonId, int fromWalletId, int topersonId, int toWalletId, decimal balance, string description, DateTime? date);
    }
}
