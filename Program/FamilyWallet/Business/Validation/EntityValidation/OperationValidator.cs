using System;
using Business.Exceptions;
using Business.Validation.EntityValidation.Interface;
using Domain.Entity;

namespace Business.Validation.EntityValidation
{
    public class OperationValidator : IEntityValidator<Operation>
    {
        public void Validate(Operation entity)
        {
            if (entity.OperationCategory == null)
                throw new InvalidForeignKeyException(typeof(OperationCategory).Name);

            if (entity.OperationInfo == null)
                throw new InvalidForeignKeyException(typeof(OperationInfo).Name);

            if (entity.PersonWallet == null)
                throw new InvalidForeignKeyException(typeof(PersonWallet).Name);

            throw new NotImplementedException();
        }
    }
}
