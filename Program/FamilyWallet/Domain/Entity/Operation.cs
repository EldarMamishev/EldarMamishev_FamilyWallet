﻿using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Operation : EntityBase
    {
        public int? PersonWalletID { get; set; }
        public virtual PersonWallet PersonWallet { get; set; }
        public int? OperationCategoryID { get; set; }
        public virtual OperationCategory OperationCategory { get; set; }
        public int? OperationInfoID { get; set; }
        public virtual OperationInfo OperationInfo { get; set; }
        public int? TransactionID { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}