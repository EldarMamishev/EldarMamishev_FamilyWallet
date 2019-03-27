using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class OperationInfo
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
