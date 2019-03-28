using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Transaction: EntityBase
    {
        public int? ToOperationID { get; set; }
        public virtual Operation ToOperation { get; set; }
        public int? FromOperationID { get; set; }
        public virtual Operation FromOperation { get; set; }
    }
}