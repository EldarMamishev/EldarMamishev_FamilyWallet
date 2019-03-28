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
            => this.dbContext.Set<Wallet>().Where(w => w.FamilyID.Value == familyId).ToList();

        public ICollection<Wallet> GetWalletsByPersonId(int personId)
            => this.dbContext.Set<Wallet>().Where(w => w.PersonWallets.Any(pw => pw.PersonID.Value == personId)).ToList();

        public ICollection<Wallet> GetWalletsByType(WalletType type)
            => this.dbContext.Set<Wallet>().Where(w => w.Type == type).ToList();
    }
}
