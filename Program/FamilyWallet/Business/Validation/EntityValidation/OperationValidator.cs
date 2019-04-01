using System;
using Business.Validation.EntityValidation.Interface;
using Domain.Entity;

namespace Business.Validation.EntityValidation
{
    public class OperationValidator : IEntityValidator<Operation>
    {
        public void Validate(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}
