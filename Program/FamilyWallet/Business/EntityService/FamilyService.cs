using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Business.Validation.EntityValidation.Interface;
using Business.Validation.Interface;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class FamilyService : EntityServiceBase<Family>
    {
        public void AddPersonToFamily(int id, int personId)
        {
            Family family = this.UnitOfWork.FamilyRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            PersonFamily personFamily = new PersonFamily() { FamilyID = id, PersonID = personId };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
            this.UnitOfWork.SaveChanges();
        }

        public void Create(int personId, string name)
        {
            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);
            this.ArgumentValidator.CheckForNull(name, nameof(name));

            Family family = new Family() { Name = name };
            this.UnitOfWork.FamilyRepository.Add(family);

            PersonFamily personFamily = new PersonFamily { PersonID = personId, FamilyID = family.ID };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
            this.UnitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FamilyService(IUnitOfWork unitOfWork, IEntityValidator<Family> entityValidator, IArgumentValidator argumentValidator) 
            : base(unitOfWork, entityValidator, argumentValidator)
        { }

        protected override IEntityRepository<Family> GetRepository()
            => this.UnitOfWork.FamilyRepository;     

        public void Update(int id, string name)
        {
            Family family = this.UnitOfWork.FamilyRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);
            this.ArgumentValidator.CheckForNull(name, nameof(name));

            family.Name = name;
            this.UnitOfWork.FamilyRepository.Update(family);
            this.UnitOfWork.SaveChanges();
        }
    }
}
