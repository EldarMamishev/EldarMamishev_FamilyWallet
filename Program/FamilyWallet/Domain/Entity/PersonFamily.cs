using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class PersonFamily : EntityBase
    {
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? FamilyID { get; set; }
        public virtual Family Family { get; set; }
    }
}