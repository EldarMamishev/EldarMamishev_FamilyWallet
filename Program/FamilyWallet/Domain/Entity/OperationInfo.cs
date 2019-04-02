using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class OperationInfo : EntityBase, IValidatableObject
    {
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^[\s\w\p{P}]{1, 100}$";
            if (this.Date.Date > DateTime.Now.Date)
                yield return new ValidationResult(nameof(this.Date));

            if (this.Balance <= 0)
                yield return new ValidationResult(nameof(this.Balance));

            if (this.Description.Length == 0 || Regex.IsMatch(this.Description, pattern))
                yield return new ValidationResult(nameof(this.Description));
        }
    }
}