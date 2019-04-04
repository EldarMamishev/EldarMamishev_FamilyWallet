using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService;
using Business.EntityService.Base.Interface;
using Business.EntityService.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class FamilyController : Controller
    {
        private readonly IFamilyService familyService;
        private readonly IFamilyRepository familyRepository;

        public FamilyController(IFamilyService familyService, IFamilyRepository familyRepository)
        {
            this.familyService = familyService;
            this.familyRepository = familyRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Family> Get() => this.familyRepository.GetAll();

        [HttpGet]
        [Route("{id:int}")]
        public Family Get(int id) => this.familyRepository.GetById(id);

        [HttpGet]
        [Route("person/{id:int}")]
        public IEnumerable<Family> GetByPersonId(int id) 
            => this.familyRepository.GetFamiliesByPersonId(id);
    }
}
