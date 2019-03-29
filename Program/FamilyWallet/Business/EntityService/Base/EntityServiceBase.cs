using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Interface;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Base
{
    public class EntityServiceBase<TEntity> : IEntityService<TEntity>
        where TEntity : EntityBase
    {
        protected IEntityRepository<TEntity> entityRepository;

        public IEntityRepository<TEntity> EntityRepository => this.entityRepository;

        public EntityServiceBase(IEntityRepository<TEntity> repository)
        {
            this.entityRepository = repository;
        }

        public ICollection<TEntity> GetAll() => this.EntityRepository.GetAll();

        public TEntity GetById(int id) => this.EntityRepository.GetById(id);
    }
}
