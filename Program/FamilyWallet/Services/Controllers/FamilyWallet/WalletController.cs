using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletService walletService;
        private readonly IWalletRepository walletRepository;

        public WalletController(IWalletService walletService, IWalletRepository walletRepository)
        {
            this.walletService = walletService;
            this.walletRepository = walletRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Wallet> Get() => this.walletRepository.GetAll();

        [HttpGet]
        [Route("{id:int}")]
        public Wallet Get(int id) => this.walletRepository.GetById(id);

        [HttpGet]
        [Route("person/{id:int}")]
        public IEnumerable<Wallet> GetByPersonId(int id)
            => this.walletRepository.GetWalletsByPersonId(id);

        [HttpGet]
        [Route("family/{id:int}")]
        public IEnumerable<Wallet> GetByFamilyId(int id)
            => this.walletRepository.GetWalletsByFamilyId(id);

    }
}
