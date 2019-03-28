using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.UnitOfWork.Interface;
using Domain.Repository;

namespace Data.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFamilyRepository FamilyRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IOperationCategoryRepository OperationCategoryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IOperationInfoRepository OperationInfoRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IOperationRepository OperationRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPersonFamilyRepository PersonFamilyRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPersonRepository PersonRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPersonWalletRepository PersonWalletRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITransactionRepository TransactionRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWalletRepository WalletRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
