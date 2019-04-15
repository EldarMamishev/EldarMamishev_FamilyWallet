using AutoMapper;
using Business.EntityService.Interface;
using Business.Static;
using Domain.Repository;

namespace Services.Controllers.FamilyWallet
{
    public class PersonController
    {
        private readonly IPersonService personService;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService, IPersonRepository personRepository, IMapper mapper)
        {
            CheckArgument.CheckForNull(personService, nameof(personService));
            CheckArgument.CheckForNull(personRepository, nameof(personRepository));
            CheckArgument.CheckForNull(mapper, nameof(mapper));

            this.personService = personService;
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
    }
}
