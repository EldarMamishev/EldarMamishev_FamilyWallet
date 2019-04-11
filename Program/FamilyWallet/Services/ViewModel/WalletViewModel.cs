using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Enum;

namespace Services.ViewModel
{
    public class WalletViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public WalletType WalletType { get; set; }
    }
}
