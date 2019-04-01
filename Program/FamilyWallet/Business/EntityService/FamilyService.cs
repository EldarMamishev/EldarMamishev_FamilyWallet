using System;
using System.Collections.Generic;
using Business.EntityService.Base;
using Business.Exceptions;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;

namespace Business.EntityService
{
    public class FamilyService : EntityServiceBase<Family>
    {
        public void Create(int userId, string name)
        {
            Family family = new Family() { Name = name };
            this.UnitOfWork.FamilyRepository.Add(family);

            PersonFamily personFamily = new PersonFamily { PersonID = userId, FamilyID = family.ID };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Family> GetAll()
            => this.GetAll(this.UnitOfWork.FamilyRepository);

        public override Family GetById(int id)
            => this.GetById(id, this.UnitOfWork.FamilyRepository);

        public FamilyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }        

        public void Update(int id, string name)
        {
            Family family = this.UnitOfWork.FamilyRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);

            this.UnitOfWork.FamilyRepository.Update(family);
        }

        public void AddPersonToFamily(int id, int userId)
        {
            Family family = this.UnitOfWork.FamilyRepository.GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(userId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            PersonFamily personFamily = new PersonFamily() { FamilyID = id, PersonID = userId };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
        }
    }
}
