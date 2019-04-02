using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Family : EntityBase, IValidatableObject 
    {
        public string Name { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @""
            if(Name)
        }
    }
}