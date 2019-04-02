using System;
using Business.EntityService.Base;
using Business.EntityService.Interface;
using Business.Static;
using Business.Validation.EntityValidation.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class PersonService : EntityServiceBase<Person>, IPersonService
    {
        public void Create(string name, string surname)
        {
            CheckArgument.CheckForNull(name, nameof(name));
            CheckArgument.CheckForNull(surname, nameof(surname));

            Person person = new Person() { Name = name, Surname = surname };
            this.GetRepository().Add(person);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
               
        protected override IEntityRepository<Person> GetRepository()
            => this.UnitOfWork.PersonRepository;

        public PersonService(IUnitOfWork unitOfWork, IEntityValidator<Person> entityValidator) 
            : base(unitOfWork, entityValidator)
        { }
    }
}
