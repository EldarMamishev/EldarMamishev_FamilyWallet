using System;
using Business.Validation.EntityValidation.Interface;
using Domain.Entity;

namespace Business.Validation.EntityValidation
{
    public class PersonValidator : IEntityValidator<Person>
    {
        public void Validate(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
