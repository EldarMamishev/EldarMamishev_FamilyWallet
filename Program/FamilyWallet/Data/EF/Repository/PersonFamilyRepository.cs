using Data.EF.Repository.Base;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.EF.Repository
{
    public class PersonFamilyRepository : EntityRepository<PersonFamily>, IPersonFamilyRepository
    {
        public PersonFamilyRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
