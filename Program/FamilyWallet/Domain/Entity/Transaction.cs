using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Transaction
    {
        public int ID { get; set; }
        public int? ToOperationID { get; set; }
        public virtual Operation ToOperation { get; set; }
        public int? FromOperationID { get; set; }
        public virtual Operation FromOperation { get; set; }
    }
}
