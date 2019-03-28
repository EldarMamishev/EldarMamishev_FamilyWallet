using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
