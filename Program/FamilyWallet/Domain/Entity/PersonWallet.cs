using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity
{
    public class PersonWallet : EntityBase, IValidatableObject
    {
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? WalletID { get; set; }
        public virtual Wallet Wallet { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Person == null)
                yield return new ValidationResult(nameof(this.Person));

            if (this.Wallet == null)
                yield return new ValidationResult(nameof(this.Wallet));

            if (this.Operations == null || this.Operations.Count == 0)
                yield return new ValidationResult(nameof(this.Operations));
        }
    }
}