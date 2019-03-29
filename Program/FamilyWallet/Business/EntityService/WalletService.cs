using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Base;
using Domain.Entity;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class WalletService : EntityServiceBase<Wallet>
    {
        public WalletService(IEntityRepository<Wallet> repository) : base(repository)
        { }


    }
}
