using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class FamilyViewModel : EntityViewModelBase
    {
        public string Name { get; set; }
        public IEnumerable<WalletViewModel> WalletViewModels { get; set; }
        public IEnumerable<PersonViewModel> PersonViewModels { get; set; }
    }
}
