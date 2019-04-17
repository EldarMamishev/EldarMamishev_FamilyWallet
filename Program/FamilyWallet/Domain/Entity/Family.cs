using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Family : EntityBase, IValidatableObject 
    {
        public string Name { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^[\s\w\p{P}]+$";

            if (!Regex.IsMatch(this.Name, pattern))
                yield return new ValidationResult(nameof(this.Name));

            if (this.PersonFamilies == null || this.PersonFamilies.Count == 0)
                yield return new ValidationResult(nameof(this.PersonFamilies));
        }
    }
}