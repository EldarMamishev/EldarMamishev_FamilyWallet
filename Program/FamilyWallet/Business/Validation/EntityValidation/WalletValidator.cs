using System;
using Business.Validation.EntityValidation.Interface;
using Domain.Entity;

namespace Business.Validation.EntityValidation
{
    public class WalletValidator : IEntityValidator<Wallet>
    {
        public void Validate(Wallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
