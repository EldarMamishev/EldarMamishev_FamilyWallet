using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<PersonWallet> PersonWallets { get; set; }
        public virtual ICollection<PersonFamily> PersonFamilies { get; set; }
    }
}
