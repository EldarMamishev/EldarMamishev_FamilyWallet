using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class PersonFamily : EntityBase, IValidatableObject
    {
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Family == null)
                yield return new ValidationResult(nameof(this.Family));

            if (this.Person == null)
                yield return new ValidationResult(nameof(this.Person));
        }
    }
}