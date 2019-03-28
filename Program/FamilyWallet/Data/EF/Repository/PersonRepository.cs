using System;
using System.Collections.Generic;
using System.Text;
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
        {
            throw new NotImplementedException();
        }

        public ICollection<Person> GetPeopleByWalletId(int walletId)
        {
            throw new NotImplementedException();
        }
    }
}
