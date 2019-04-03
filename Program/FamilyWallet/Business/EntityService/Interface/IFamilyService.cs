using Business.EntityService.Base.Interface;
using Domain.Entity;

namespace Business.EntityService.Interface
{
    public interface IFamilyService : IEntityService<Family>
    {
        void AddPersonToFamily(int id, int personId);
        void Create(int personId, string name);
        void Update(int id, string name);
    }
}
