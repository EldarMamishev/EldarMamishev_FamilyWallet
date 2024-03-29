﻿using System.Collections.Generic;
using System.Linq;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class PersonRepository : EntityRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<Person> GetPeopleByFamilyId(int familyId)
            => this.dbContext.Set<Person>().Where(p => p.PersonFamilies.Any(pf => pf.FamilyID.Value == familyId)).ToList();

        public ICollection<Person> GetPeopleByWalletId(int walletId)
            => this.dbContext.Set<Person>().Where(p => p.PersonWallets.Any(pw => pw.WalletID.Value == walletId)).ToList();
    }
}
