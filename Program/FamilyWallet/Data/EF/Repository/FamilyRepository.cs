using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class FamilyRepository : EntityRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(DbContext dbContext) : base(dbContext)
        { }

        public ICollection<Family> GetFamiliesByPersonId(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
