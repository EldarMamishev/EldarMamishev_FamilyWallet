using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Base
{
    public abstract class EntityBase : IValidatableObject
    {
        public int ID { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return new ValidationResult(string.Empty);
        }
    }
}