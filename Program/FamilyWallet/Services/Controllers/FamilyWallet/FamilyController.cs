using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.EntityService;
using Business.EntityService.Base.Interface;
using Business.EntityService.Interface;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Services.ViewModel;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class FamilyController : Controller
    {
        private readonly IFamilyService familyService;
        private readonly IFamilyRepository familyRepository;
        private readonly IMapper mapper;

        public FamilyController(IFamilyService familyService, IFamilyRepository familyRepository, IMapper mapper)
        {
            CheckArgument.CheckForNull(familyService, nameof(familyService));
            CheckArgument.CheckForNull(familyRepository, nameof(familyRepository));
            CheckArgument.CheckForNull(mapper, nameof(mapper));

            this.familyService = familyService;
            this.familyRepository = familyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<FamilyViewModel> Get() => this.familyRepository.GetAll()
            .Select(f => this.mapper.Map<Family, FamilyViewModel>(f));

        [HttpGet]
        [Route("{id:int}")]
        public FamilyViewModel Get(int id) => this.mapper.Map<Family, FamilyViewModel>(this.familyRepository.GetById(id));

        [HttpGet]
        [Route("person/{id:int}")]
        public IEnumerable<FamilyViewModel> GetByPersonId(int id) => this.familyRepository.GetFamiliesByPersonId(id)
            .Select(f => this.mapper.Map<Family, FamilyViewModel>(f));

        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] PersonFamilyViewModel personFamily)
        {
            this.familyService.Create(personFamily.Person.ID, personFamily.Family.Name);

            return this.Ok();
        }

        [HttpPost]
        [Route("person")]
        public ActionResult AddPersonToFamily([FromBody] PersonFamilyViewModel personFamily)
        {
            this.familyService.AddPersonToFamily(personFamily.Family.ID, personFamily.Person.ID);

            return this.Ok();
        }

        [HttpPut]
        [Route("")]
        public ActionResult Update([FromBody] FamilyViewModel family)
        {
            this.familyService.Update(family.ID, family.Name);

            return this.Ok();
        }
    }
}
