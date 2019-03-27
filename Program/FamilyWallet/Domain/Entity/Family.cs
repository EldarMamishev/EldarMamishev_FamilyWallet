using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Family
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
