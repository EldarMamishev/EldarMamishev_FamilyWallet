using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.EntityService.Interface;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.ViewModel;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class FamilyController : Controller
    {
        private readonly IFamilyService familyService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FamilyController(IFamilyService familyService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            CheckArgument.CheckForNull(familyService, nameof(familyService));
            CheckArgument.CheckForNull(unitOfWork, nameof(unitOfWork));
            CheckArgument.CheckForNull(mapper, nameof(mapper));

            this.familyService = familyService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<FamilyViewModel> Get() => this.unitOfWork.FamilyRepository.GetAll()
            .Select(f => this.mapper.Map<Family, FamilyViewModel>(f));

        [HttpGet]
        [Route("{id:int}")]
        public FamilyWithPeopleViewModel Get(int id)
        {
            Family family = this.unitOfWork.FamilyRepository.GetById(id);
            IEnumerable<PersonViewModel> people = this.unitOfWork.PersonRepository.GetPeopleByFamilyId(id).Select(p => this.mapper.Map<Person, PersonViewModel>(p));

            return new FamilyWithPeopleViewModel() { ID = family.ID, Name = family.Name, People = people };
        }

        [HttpGet]
        [Route("person/{id:int}")]
        public IEnumerable<FamilyWithPeopleViewModel> GetByPersonId(int id)
        {
            Person person = this.unitOfWork.PersonRepository.GetById(id);
            IEnumerable<FamilyViewModel> families = this.unitOfWork.FamilyRepository.GetFamiliesByPersonId(id).Select(f => this.mapper.Map<Family, FamilyViewModel>(f));
            IEnumerable<FamilyWithPeopleViewModel> familiesWithPeople = families
                .Select(f => new FamilyWithPeopleViewModel() { ID = f.ID, Name = f.Name, People = this.unitOfWork.PersonRepository.GetPeopleByFamilyId(f.ID)
                .Select(p => this.mapper.Map<Person, PersonViewModel>(p)) });

            return familiesWithPeople;
        }

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
