using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class OperationInfo : EntityBase
    {
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}