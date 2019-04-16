using System;
using Business.EntityService.Base.Interface;
using Domain.Entity;

namespace Business.EntityService.Interface
{
    public interface IOperationService : IEntityService<Operation>
    {
        void CreateOneWalletOperation(int personId, int walletId, int operationCategoryId, decimal balance, string description, DateTime? date);
        void CreateTransaction(int frompersonId, int fromWalletId, int topersonId, int toWalletId, decimal balance, string description, DateTime? date);
    }
}
