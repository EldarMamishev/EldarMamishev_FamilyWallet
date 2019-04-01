using System;
using System.Collections.Generic;
using Business.EntityService.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Base
{
    public abstract class EntityServiceBase<TEntity> : IEntityService<TEntity>
        where TEntity : EntityBase
    {
        public EntityServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork 
                ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ICollection<TEntity> GetAll() => this.GetRepository().GetAll();

        public TEntity GetById(int id) => this.GetRepository().GetById(id);

        protected abstract IEntityRepository<TEntity> GetRepository();

        private IUnitOfWork unitOfWork;

        protected IUnitOfWork UnitOfWork => this.unitOfWork;
    }
}
