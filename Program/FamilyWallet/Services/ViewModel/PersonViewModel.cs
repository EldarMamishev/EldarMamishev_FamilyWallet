using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class PersonViewModel : EntityViewModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public SocialViewModel SocialViewModel { get; set; }
        public IEnumerable<PersonWalletViewModel> PersonWallets { get; set; }
        public IEnumerable<FamilyViewModel> Families { get; set; }
    }
}
