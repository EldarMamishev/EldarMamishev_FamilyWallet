using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService.Base.Interface;
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
        [Route("/{id}")]
        public Family Get(int id)
            => this.UnitOfWork.FamilyRepository.GetById(id);

        [HttpGet]
        [Route("/person/{id: int}")]
        public IEnumerable<Family> GetByPersonId(int id)
            => this.UnitOfWork.FamilyRepository.GetFamiliesByPersonId(id);

        [HttpPost]
        [Route("")]
        public StatusCodeResult Create()
        {

        }
    }
}
