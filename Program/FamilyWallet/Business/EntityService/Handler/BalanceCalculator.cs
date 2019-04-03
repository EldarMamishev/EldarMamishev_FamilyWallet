using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Handler.Interface;
using Domain.Enum;

namespace Business.EntityService.Handler
{
    public class BalanceCalculator : IBalanceCalculator
    {
        public decimal CountNewWalletBalance(decimal walletBalance, decimal operationBalance, OperationType operationType)
        {
            decimal newBalance = walletBalance;

            switch (operationType)
            {
                case OperationType.Earning:
                    newBalance += operationBalance;
                    break;
                case OperationType.Spending:
                    newBalance -= operationBalance;
                    break;
            }

            return newBalance;
        }
    }
}
