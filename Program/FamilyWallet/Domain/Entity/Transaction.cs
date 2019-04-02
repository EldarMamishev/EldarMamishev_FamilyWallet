using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Transaction : EntityBase, IValidatableObject
    {
        public virtual ICollection<Operation> Operations { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Operations == null || this.Operations.Count != 2)
                yield return new ValidationResult(nameof(this.Operations));
        }
    }
}