﻿using System;
using System.Collections.Generic;
using Business.EntityService.Base.Interface;
using Business.Validation.EntityValidation.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;
using Domain.Repository.Base;

namespace Business.EntityService.Base
{
    public abstract class EntityServiceBase<TEntity> : IEntityService<TEntity>
        where TEntity : EntityBase
    {
        private readonly IArgumentValidator argumentValidator;
        private readonly IEntityValidator<TEntity> entityValidator;
        private readonly IUnitOfWork unitOfWork;

        protected IArgumentValidator ArgumentValidator => this.argumentValidator;

        public EntityServiceBase(IUnitOfWork unitOfWork, IEntityValidator<TEntity> entityValidator, IArgumentValidator argumentValidator)
        {
            this.unitOfWork = unitOfWork 
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            this.entityValidator = entityValidator
                ?? throw new ArgumentNullException(nameof(entityValidator));

            this.argumentValidator = argumentValidator
                ?? throw new ArgumentNullException(nameof(argumentValidator));
        }

        protected IEntityValidator<TEntity> EntityValidator => this.entityValidator;

        public ICollection<TEntity> GetAll() => this.GetRepository().GetAll();

        public TEntity GetById(int id) => this.GetRepository().GetById(id);

        protected abstract IEntityRepository<TEntity> GetRepository();

        protected IUnitOfWork UnitOfWork => this.unitOfWork;
    }
}
