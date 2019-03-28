using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Wallet: EntityBase
    {
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
    }
}
