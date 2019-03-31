﻿using System;
using System.Collections.Generic;
using System.Text;
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
        public WalletService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

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

        public void AddUserToWallet(int id, int userId, int familyId, AccessModifier accessModifier)
        {
            Wallet wallet = this.UnitOfWork.WalletRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Wallet).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(userId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            if (wallet.FamilyID == null)
                wallet.FamilyID = familyId;
            else if (!this.UnitOfWork.PersonFamilyRepository.IsPersonInFamily(userId, familyId))
                throw new InvalidForeignKeyException(nameof(familyId));

            PersonWallet personWallet = new PersonWallet { WalletID = id, PersonID = userId, AccessModifier = accessModifier };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
        }

        public void CreateWalletByUserId(int userId, string name, WalletType walletType, int balance = 0)
        {
            Wallet wallet = new Wallet { Name = name, Type = walletType, Balance = balance };
            this.UnitOfWork.WalletRepository.Add(wallet);

            PersonWallet personWallet = new PersonWallet { WalletID = wallet.ID, PersonID = userId, AccessModifier = AccessModifier.Manage };
            this.UnitOfWork.PersonWalletRepository.Add(personWallet);
        }

        public override void Delete(int id) 
            => this.Delete(id, this.UnitOfWork.WalletRepository);

        public override ICollection<Wallet> GetAll() 
            => this.GetAll(this.UnitOfWork.WalletRepository);

        public override Wallet GetById(int id) 
            => this.GetById(id, this.UnitOfWork.WalletRepository);
    }
}
