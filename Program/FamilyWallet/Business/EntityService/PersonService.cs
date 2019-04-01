﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Base;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;

namespace Business.EntityService
{
    public class PersonService : EntityServiceBase<Person>
    {       
        public void Create(string name, string surname)
        {
            Person person = new Person() { Name = name, Surname = surname };
            this.UnitOfWork.PersonRepository.Add(person);
        }

        public override void Delete(int id)
            => this.Delete(id, this.UnitOfWork.PersonRepository);

        public override ICollection<Person> GetAll()
            => this.GetAll(this.UnitOfWork.PersonRepository);

        public override Person GetById(int id)
            => this.GetById(id, this.UnitOfWork.PersonRepository);

        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
