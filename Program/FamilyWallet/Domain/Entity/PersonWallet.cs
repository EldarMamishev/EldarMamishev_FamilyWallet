using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enum;

namespace Domain.Entity
{
    public class PersonWallet
    {
        public int ID { get; set; }
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? WalletID { get; set; }
        public virtual Wallet Wallet { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
