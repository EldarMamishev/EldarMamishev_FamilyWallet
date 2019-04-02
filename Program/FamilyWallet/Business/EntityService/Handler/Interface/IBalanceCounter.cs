using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using Domain.Enum;

namespace Business.EntityService.Handler.Interface
{
    public interface IBalanceCounter
    {
        decimal CountNewWalletBalance(decimal walletBalance, decimal operationBalance, OperationType operationType);
    }
}
