using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.EntityService.Interface;
using Business.Static;
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
        public FamilyWithPeopleViewModel Get(int id) => this.mapper.Map<Family, FamilyWithPeopleViewModel>(this.familyRepository.GetById(id));

        [HttpGet]
        [Route("person/{id:int}")]
        public IEnumerable<FamilyWithPeopleViewModel> GetByPersonId(int id) => this.familyRepository.GetFamiliesByPersonId(id)
            .Select(f => this.mapper.Map<Family, FamilyWithPeopleViewModel>(f));

        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] FamilyNamePersonIdViewModel personFamily)
        {
            this.familyService.Create(personFamily.PersonID, personFamily.FamilyName);

            return this.Ok();
        }

        [HttpPost]
        [Route("person")]
        public ActionResult AddPersonToFamily([FromBody] PersonFamilyViewModel personFamily)
        {
            this.familyService.AddPersonToFamily(personFamily.FamilyID, personFamily.PersonID);

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
