using System.Collections.Generic;
using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IFamilyRepository : IEntityRepository<Family>
    {
        ICollection<Family> GetFamiliesByPersonId(int personId);
    }
}
