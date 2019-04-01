using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.EntityValidation.Interface
{
    public interface IEntityValidator<TEntity>
    {
        void Validate(TEntity entity);
    }
}
