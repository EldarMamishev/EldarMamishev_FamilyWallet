using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Person : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
    }
}