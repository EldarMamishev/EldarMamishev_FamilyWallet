using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService;
using Business.EntityService.Base.Interface;
using Business.EntityService.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Controllers.FamilyWallet.Base;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class FamilyController : EntityController<Family>
    {
        public FamilyController(IEntityService<Family> entityService, IUnitOfWork unitOfWork) : base(entityService, unitOfWork)
        { }

        [HttpGet]
        [Route("")]
        public IEnumerable<Family> Get()
            => this.UnitOfWork.FamilyRepository.GetAll();

        [HttpGet]
        [Route("/{id : int}")]
        public Family Get(int id)
            => this.UnitOfWork.FamilyRepository.GetById(id);

        [HttpGet]
        [Route("/person/{id: int}")]
        public IEnumerable<Family> GetByPersonId(int id)
            => this.UnitOfWork.FamilyRepository.GetFamiliesByPersonId(id);

        [HttpPost]
        [Route("/{personId : int}/{name : alpha}")]
        public StatusCodeResult Create(int personId, string name)
        {
            (this.EntityService as IFamilyService).Create(personId, name);

            return this.Ok();
        }

        [HttpPut]
        [Route("/{id : int}/{name : alpha}")]
        public StatusCodeResult Update(int id, string name)
        {
            (this.EntityService as IFamilyService).Update(id, name);

            return this.Ok();
        }
    }
}
