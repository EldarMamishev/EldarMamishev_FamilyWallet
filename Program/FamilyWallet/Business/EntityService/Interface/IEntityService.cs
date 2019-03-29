using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Interface
{
    public interface IEntityService<TEntity>
        where TEntity : EntityBase
    {
        IEntityRepository<TEntity> EntityRepository { get; }
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
