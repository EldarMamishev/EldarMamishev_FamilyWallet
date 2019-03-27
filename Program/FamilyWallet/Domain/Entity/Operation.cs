using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Operation
    {
        public int ID { get; set; }
        public int? PersonWalletID { get; set; }
        public virtual PersonWallet PersonWallet { get; set; }
        public int? OperationCategoryId { get; set; }
        public virtual OperationCategory OperationCategory { get; set; }
        public int? OperationInfoID { get; set; }
        public virtual OperationInfo OperationInfo { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
