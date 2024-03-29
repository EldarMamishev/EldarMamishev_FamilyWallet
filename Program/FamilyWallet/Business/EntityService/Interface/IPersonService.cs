﻿using Business.EntityService.Base.Interface;
using Domain.Entity;

namespace Business.EntityService.Interface
{
    public interface IPersonService : IEntityService<Person>
    {
        void Create(string name, string surname);
    }
}
