using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Validation.EntityValidation.Interface;
using Business.Validation.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class PersonService : EntityServiceBase<Person>
    {
        public void Create(string name, string surname)
        {
            this.ArgumentValidator.CheckForNull(name, nameof(name));
            this.ArgumentValidator.CheckForNull(surname, nameof(surname));

            Person person = new Person() { Name = name, Surname = surname };
            this.UnitOfWork.PersonRepository.Add(person);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
               
        protected override IEntityRepository<Person> GetRepository()
            => this.UnitOfWork.PersonRepository;

        public PersonService(IUnitOfWork unitOfWork, IEntityValidator<Person> entityValidator, IArgumentValidator argumentValidator) 
            : base(unitOfWork, entityValidator, argumentValidator)
        { }
    }
}
