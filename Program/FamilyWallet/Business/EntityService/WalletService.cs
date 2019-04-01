using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class WalletService : EntityServiceBase<Wallet>
    {
        public void AddUserToWallet(int id, int personId, int familyId, AccessModifier accessModifier)
        {
            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            if (wallet.FamilyID == null)
                wallet.FamilyID = familyId;
            else if (!this.UnitOfWork.PersonFamilyRepository.IsPersonInFamily(personId, familyId))
                throw new InvalidForeignKeyException(nameof(familyId));

            PersonWallet personWallet = new PersonWallet { WalletID = id, PersonID = personId, AccessModifier = accessModifier };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
        }

        public void CreateWalletBypersonId(int personId, string name, WalletType walletType, int balance = 0)
        {
            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Wallet wallet = new Wallet { Name = name, Type = walletType, Balance = balance };
            this.UnitOfWork.WalletRepository.Add(wallet);

            PersonWallet personWallet = new PersonWallet { WalletID = wallet.ID, PersonID = personId, AccessModifier = AccessModifier.Manage };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEntityRepository<Wallet> GetRepository()
            => this.UnitOfWork.WalletRepository;

        public void Update(int id, int? familyId, string name, WalletType walletType, int balance)
        {
            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(id) 
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            wallet.FamilyID = familyId;
            wallet.Name = name;
            wallet.Type = walletType;
            wallet.Balance = balance;

            this.UnitOfWork.WalletRepository.Update(wallet);
        }

        public void Rename(int id, string name)
        {
            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(id)
               ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            wallet.Name = name;
        }

        public WalletService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
