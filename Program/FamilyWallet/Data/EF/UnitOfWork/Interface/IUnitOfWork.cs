using Domain.Repository;

namespace Data.EF.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IFamilyRepository FamilyRepository { get; }
        IOperationCategoryRepository OperationCategoryRepository { get; }
        IOperationInfoRepository OperationInfoRepository { get; }
        IOperationRepository OperationRepository { get; }
        IPersonFamilyRepository PersonFamilyRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPersonWalletRepository PersonWalletRepository { get; }
        void SaveChanges();
        ITransactionRepository TransactionRepository { get; }
        IWalletRepository WalletRepository { get; }
    }
}
