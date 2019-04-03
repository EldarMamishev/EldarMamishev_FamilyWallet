using System.Linq;
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

        public bool IsPersonInFamily(int personId, int familyId)
            => this.dbContext.Set<PersonFamily>().Any(pf => pf.PersonID.Value == personId && pf.FamilyID.Value == familyId);
    }
}
