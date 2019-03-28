using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Family: EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}