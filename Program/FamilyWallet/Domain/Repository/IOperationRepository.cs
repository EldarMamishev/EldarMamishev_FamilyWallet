using System.Collections.Generic;
using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        ICollection<Operation> GetOperationsByPersonId(int personId);
        ICollection<Operation> GetOperationsByWalletId(int walletId);
        ICollection<Operation> GetOperationsByTransactionId(int transactionId);
    }
}
