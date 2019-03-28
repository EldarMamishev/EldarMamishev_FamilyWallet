using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity
{
    public class PersonWallet: EntityBase
    {
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? WalletID { get; set; }
        public virtual Wallet Wallet { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}