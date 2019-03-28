using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Repository.Base
{
    public interface IEntityRepository<TEntity> where TEntity : EntityBase
    {
        TEntity GetById(int Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}