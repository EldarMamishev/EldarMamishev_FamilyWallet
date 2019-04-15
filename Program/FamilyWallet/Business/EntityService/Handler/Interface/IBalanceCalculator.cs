using Domain.Enum;

namespace Business.EntityService.Handler.Interface
{
    public interface IBalanceCalculator
    {
        decimal CountNewWalletBalance(decimal walletBalance, decimal operationBalance, OperationType operationType);
    }
}
