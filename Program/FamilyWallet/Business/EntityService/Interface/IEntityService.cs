using System.Collections.Generic;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;

namespace Business.EntityService.Interface
{
    public interface IEntityService<TEntity>
        where TEntity : EntityBase
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
