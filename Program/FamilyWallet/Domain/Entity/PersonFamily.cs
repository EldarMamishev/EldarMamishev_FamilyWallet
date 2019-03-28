using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class PersonFamily
    {
        public int ID { get; set; }
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }
    }
}
