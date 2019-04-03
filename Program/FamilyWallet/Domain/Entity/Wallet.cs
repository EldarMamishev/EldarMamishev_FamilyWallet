using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity
{
    public class Wallet : EntityBase
    {
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }
        public string Name { get; set; }
        public WalletType Type { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^[\s\w\p{P}]{1, 30}$";

            if (!Regex.IsMatch(this.Name, pattern))
                yield return new ValidationResult(nameof(this.Name));

            if (this.Balance < 0)
                yield return new ValidationResult(nameof(this.Balance));
        }
    }
}