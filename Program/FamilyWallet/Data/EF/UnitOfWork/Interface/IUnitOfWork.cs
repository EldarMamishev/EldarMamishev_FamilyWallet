using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repository;

namespace Data.EF.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IFamilyRepository FamilyRepository { get; set; }
        IOperationCategoryRepository OperationCategoryRepository { get; set; }
        IOperationInfoRepository OperationInfoRepository { get; set; }
        IOperationRepository OperationRepository { get; set; }
        IPersonFamilyRepository PersonFamilyRepository { get; set; }
        IPersonRepository PersonRepository { get; set; }
        IPersonWalletRepository PersonWalletRepository { get; set; }
        ITransactionRepository TransactionRepository { get; set; }
        IWalletRepository WalletRepository { get; set; }
    }
}
