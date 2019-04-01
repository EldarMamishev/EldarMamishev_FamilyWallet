using Business.EntityService.Base.Interface;
using Domain.Entity;
using Domain.Enum;

namespace Business.EntityService.Interface
{
    public interface IWalletService : IEntityService<Wallet>
    {
        void AddUserToWallet(int id, int personId, int familyId, AccessModifier accessModifier);
        void CreateWalletByPersonId(int personId, string name, WalletType walletType, decimal balance);
        void Rename(int id, string name);
    }
}
