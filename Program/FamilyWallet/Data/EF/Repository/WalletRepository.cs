using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class WalletRepository : EntityRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<Wallet> GetWalletsByFamilyId(int familyId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Wallet> GetWalletsByPersonId(int personId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Wallet> GetWalletsByType(WalletType type)
        {
            throw new NotImplementedException();
        }
    }
}
