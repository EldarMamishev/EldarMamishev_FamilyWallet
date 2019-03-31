using System;
using System.Collections.Generic;
using System.Text;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Interface
{
    public interface IEntityService<TEntity>
        where TEntity : EntityBase
    {
        void Delete(int id);
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
        IUnitOfWork UnitOfWork { get; }
    }
}
