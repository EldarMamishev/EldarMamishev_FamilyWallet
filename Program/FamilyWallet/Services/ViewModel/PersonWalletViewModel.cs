using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;

namespace Services.ViewModel
{
    public class PersonWalletViewModel
    {
        public PersonViewModel Person { get; set; }
        public FamilyWithPeopleViewModel Family { get; set; }
        public AccessModifier AccessModifier { get; set; }
    }
}
