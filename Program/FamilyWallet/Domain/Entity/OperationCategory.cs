using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enum;

namespace Domain.Entity
{
    public class OperationCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OperationType Type { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
