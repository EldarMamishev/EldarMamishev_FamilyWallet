using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Person : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^\w{1, 10}([\-\`\'\s])?\w{2, 15}$";
            string antiPattern = @"\d";

            if (!Regex.IsMatch(this.Name, pattern) || Regex.IsMatch(this.Name, antiPattern))
                yield return new ValidationResult(nameof(Name));

            if (!Regex.IsMatch(this.Surname, pattern) || Regex.IsMatch(this.Name, antiPattern)) ;
                yield return new ValidationResult(nameof(Surname));
        }
    }
}