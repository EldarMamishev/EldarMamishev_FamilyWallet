using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IPersonFamilyRepository : IEntityRepository<PersonFamily>
    {
        bool IsPersonInFamily(int personId, int familyId);
    }
}
