using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService.Base.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity.Base;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers.FamilyWallet.Base
{
    public class EntityController<TEntity> : Controller
        where TEntity : EntityBase
    {
        private IEntityService<TEntity> entityService;
        private IUnitOfWork unitOfWork;

        public EntityController(IEntityService<TEntity> entityService, IUnitOfWork unitOfWork)
        {
            this.entityService = entityService;
            this.unitOfWork = unitOfWork;
        }

        protected IEntityService<TEntity> EntityService => this.entityService;

        protected IUnitOfWork UnitOfWork => this.unitOfWork;
    }
}
