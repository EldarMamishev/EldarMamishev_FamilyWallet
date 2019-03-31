using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Base
{
    public abstract class EntityServiceBase<TEntity> : IEntityService<TEntity>
        where TEntity : EntityBase
    {

        public abstract void Delete(int id);

        protected void Delete(int id, IEntityRepository<TEntity> entityRepository) => entityRepository.Delete(entityRepository.GetById(id));

        public EntityServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract ICollection<TEntity> GetAll();

        protected ICollection<TEntity> GetAll(IEntityRepository<TEntity> entityRepository) => entityRepository.GetAll();

        protected TEntity GetById(int id, IEntityRepository<TEntity> entityRepository) => entityRepository.GetById(id);

        public abstract TEntity GetById(int id);

        protected IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork => this.unitOfWork;
    }
}
