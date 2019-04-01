using System;
using Business.Validation.EntityValidation.Interface;
using Domain.Entity;

namespace Business.Validation.EntityValidation
{
    public class FamilyValidator : IEntityValidator<Family>
    {
        public void Validate(Family entity)
        {
            throw new NotImplementedException();
        }
    }
}
