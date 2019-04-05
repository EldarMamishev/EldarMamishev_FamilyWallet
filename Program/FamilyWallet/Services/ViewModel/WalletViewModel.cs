using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Enum;
using Services.ViewModel.Base;

namespace Services.ViewModel
{
    public class WalletViewModel : EntityViewModelBase
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public WalletType WalletType { get; set; }
        public Family Family { get; set; }
        public IEnumerable<PersonWalletViewModel> PersonWallets { get; set; }
    }
}
