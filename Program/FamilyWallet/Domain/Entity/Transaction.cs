using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Transaction : EntityBase
    {
        public virtual ICollection<Operation> Operations { get; set; }
    }
}