using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class PersonWalletViewModel : EntityViewModelBase
    {
        public PersonViewModel Person { get; set; }
        public FamilyWithPeopleViewModel Family { get; set; }
        public AccessModifier AccessModifier { get; set; }
    }
}
