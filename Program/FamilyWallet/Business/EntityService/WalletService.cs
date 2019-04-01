using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Business.Validation.EntityValidation.Interface;
using Business.Validation.Interface;
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
            this.UnitOfWork.SaveChanges();
        }

        public void CreateWalletByPersonId(int personId, string name, WalletType walletType, decimal balance = 0)
        {
            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            this.ArgumentValidator.CheckForNull(name, nameof(name));

            Wallet wallet = new Wallet { Name = name, Type = walletType, Balance = balance };
            this.UnitOfWork.WalletRepository.Add(wallet);

            PersonWallet personWallet = new PersonWallet { WalletID = wallet.ID, PersonID = personId, AccessModifier = AccessModifier.Manage };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEntityRepository<Wallet> GetRepository()
            => this.UnitOfWork.WalletRepository;

        public void Rename(int id, string name)
        { 
            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(id) 
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            this.ArgumentValidator.CheckForNull(name, nameof(name));

            wallet.Name = name;

            this.UnitOfWork.WalletRepository.Update(wallet);
            this.UnitOfWork.SaveChanges();
        }

        public WalletService(IUnitOfWork unitOfWork, IEntityValidator<Wallet> entityValidator, IArgumentValidator argumentValidator) 
            : base(unitOfWork, entityValidator, argumentValidator)
        { }
    }
}
