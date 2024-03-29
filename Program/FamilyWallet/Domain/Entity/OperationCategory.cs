﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity
{
    public class OperationCategory : EntityBase
    {
        public string Name { get; set; }
        public OperationType Type { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string pattern = @"^[\s\w\p{P}]{1, 30}$";

            if (!Regex.IsMatch(this.Name, pattern))
                yield return new ValidationResult(nameof(this.Name));
        }
    }
}