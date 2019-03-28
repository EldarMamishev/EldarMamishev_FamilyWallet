using System.Collections.Generic;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IWalletRepository : IEntityRepository<Wallet>
    {
        ICollection<Wallet> GetWalletsByFamilyId(int familyId);
        ICollection<Wallet> GetWalletsByPersonId(int personId);
        ICollection<Wallet> GetWalletsByType(WalletType type);
    }
}
