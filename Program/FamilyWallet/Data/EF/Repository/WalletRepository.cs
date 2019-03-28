using System.Collections.Generic;
using System.Linq;
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
            => dbContext.Set<Wallet>().Where(w => w.FamilyID.Equals(familyId)).ToList();

        public ICollection<Wallet> GetWalletsByPersonId(int personId)
            => dbContext.Set<Wallet>().Where(w => w.PersonWallets.Any(pw => pw.PersonID.Equals(personId))).ToList();

        public ICollection<Wallet> GetWalletsByType(WalletType type)
            => dbContext.Set<Wallet>().Where(w => w.Type.Equals(type)).ToList();
    }
}
