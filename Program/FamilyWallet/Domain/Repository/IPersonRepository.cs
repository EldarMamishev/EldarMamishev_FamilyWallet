using System.Collections.Generic;
using Domain.Entity;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public interface IPersonRepository : IEntityRepository<Person>
    {
        ICollection<Person> GetPeopleByFamilyId(int familyId);
        ICollection<Person> GetPeopleByWalletId(int walletId);
    }
}
