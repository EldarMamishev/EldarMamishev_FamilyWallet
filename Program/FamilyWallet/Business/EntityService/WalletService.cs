using System;
using Business.EntityService.Base;
using Business.EntityService.Interface;
using Business.Exceptions;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class WalletService : EntityServiceBase<Wallet>, IWalletService
    {
        public void AddUserToWallet(int id, int personId, int familyId, AccessModifier accessModifier)
        {
            Wallet wallet = this.GetRepository().GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            if (wallet.FamilyID == null)
                wallet.FamilyID = familyId;
            else if (!this.UnitOfWork.PersonFamilyRepository.IsPersonInFamily(personId, familyId))
                throw new InvalidForeignKeyException(nameof(familyId));

            PersonWallet personWallet = new PersonWallet { WalletID = id, PersonID = personId, AccessModifier = accessModifier };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
            this.UnitOfWork.SaveChanges();
        }

        public void CreateWalletByPersonId(int personId, string name, WalletType walletType, decimal balance = 0)
        {
            CheckArgument.CheckForNull(name, nameof(name));

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Wallet wallet = new Wallet { Name = name, Type = walletType, Balance = balance };
            this.GetRepository().Add(wallet);

            PersonWallet personWallet = new PersonWallet { WalletID = wallet.ID, PersonID = personId, AccessModifier = AccessModifier.Manage };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
            this.UnitOfWork.SaveChanges();
        }

        protected override IEntityRepository<Wallet> GetRepository()
            => this.UnitOfWork.WalletRepository;

        public void Rename(int id, string name)
        {
            CheckArgument.CheckForNull(name, nameof(name));

            Wallet wallet = this.GetRepository().GetById(id) 
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            wallet.Name = name;

            this.GetRepository().Update(wallet);
            this.UnitOfWork.SaveChanges();
        }

        public WalletService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        { }
    }
}
