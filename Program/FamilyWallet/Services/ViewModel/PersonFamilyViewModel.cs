using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class PersonFamilyViewModel
    {
        public PersonViewModel Person { get; set; }
        public FamilyViewModel Family { get; set; }
    }
}
