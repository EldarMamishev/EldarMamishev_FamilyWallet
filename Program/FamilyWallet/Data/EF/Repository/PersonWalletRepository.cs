using System.Linq;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class PersonWalletRepository : EntityRepository<PersonWallet>, IPersonWalletRepository
    {
        public PersonWalletRepository(DbContext dbContext) : base(dbContext)
        { }

        public PersonWallet GetPersonWalletByPersonAndWallet(int personId, int walletId)
            => this.dbContext.Set<PersonWallet>().FirstOrDefault(pw => pw.PersonID == personId && pw.WalletID == walletId);
    }
}
