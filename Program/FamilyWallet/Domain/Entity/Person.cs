using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Person : EntityBase, IValidatableObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^\w{1, 10}([\-\`\'\s])?\w{2, 15}$";

            if (Regex.IsMatch(this.Name, pattern))
                yield return new ValidationResult(nameof(Name));

            if (Regex.IsMatch(this.Surname, pattern))
                yield return new ValidationResult(nameof(Surname));
        }
    }
}