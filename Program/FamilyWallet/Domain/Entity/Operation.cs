using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Operation : EntityBase, IValidatableObject
    {
        public int? PersonWalletID { get; set; }
        public virtual PersonWallet PersonWallet { get; set; }
        public int? OperationCategoryID { get; set; }
        public virtual OperationCategory OperationCategory { get; set; }
        public int? OperationInfoID { get; set; }
        public virtual OperationInfo OperationInfo { get; set; }
        public int? TransactionID { get; set; }
        public virtual Transaction Transaction { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PersonWallet == null)
                yield return new ValidationResult(nameof(this.PersonWallet));

            if (this.OperationInfo == null)
                yield return new ValidationResult(nameof(this.OperationInfo));

            if (this.OperationCategory == null)
                yield return new ValidationResult(nameof(this.OperationCategory));
        }
    }
}