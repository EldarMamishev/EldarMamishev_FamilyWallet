using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Wallet
    {
        public int ID { get; set; }
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
    }
}
