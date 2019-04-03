using System;
using Business.EntityService.Base;
using Business.EntityService.Interface;
using Business.Exceptions;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class FamilyService : EntityServiceBase<Family>, IFamilyService
    {
        public void AddPersonToFamily(int id, int personId)
        {
            Family family = this.GetRepository().GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            PersonFamily personFamily = new PersonFamily() { FamilyID = id, PersonID = personId };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
            this.UnitOfWork.SaveChanges();
        }

        public void Create(int personId, string name)
        {
            CheckArgument.CheckForNull(name, nameof(name));

            Person person = this.UnitOfWork.PersonRepository.GetById(personId)
                ?? throw new InvalidForeignKeyException(typeof(Person).Name);

            Family family = new Family() { Name = name };
            this.GetRepository().Add(family);

            PersonFamily personFamily = new PersonFamily { PersonID = personId, FamilyID = family.ID };
            this.UnitOfWork.PersonFamilyRepository.Add(personFamily);
            this.UnitOfWork.SaveChanges();
        }

        public FamilyService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        { }

        protected override IEntityRepository<Family> GetRepository()
            => this.UnitOfWork.FamilyRepository;     

        public void Update(int id, string name)
        {
            CheckArgument.CheckForNull(name, nameof(name));

            Family family = this.GetRepository().GetById(id)
                ?? throw new InvalidPrimaryKeyException(typeof(Family).Name);

            family.Name = name;
            this.GetRepository().Update(family);
            this.UnitOfWork.SaveChanges();
        }
    }
}
