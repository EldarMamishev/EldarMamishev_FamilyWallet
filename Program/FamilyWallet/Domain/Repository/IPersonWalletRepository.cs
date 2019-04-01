using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IPersonWalletRepository : IEntityRepository<PersonWallet>
    {
        PersonWallet GetPersonWalletByPersonAndWallet(int personId, int walletId); 
    }
}
