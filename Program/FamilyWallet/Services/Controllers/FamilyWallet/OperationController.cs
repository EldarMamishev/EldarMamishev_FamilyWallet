using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityService.Interface;
using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers.FamilyWallet
{
    [Route("api/[controller]")]
    public class OperationController : Controller
    {
        private readonly IOperationService operationService;
        private readonly IOperationRepository operationRepository;

        public OperationController(IOperationService operationService, IOperationRepository operationRepository)
        {
            this.operationService = operationService;
            this.operationRepository = operationRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Operation> Get()
            => this.operationRepository.GetAll();

        [HttpGet]
        [Route("{id}")]
        public Operation Get(int id)
            => this.operationRepository.GetById(id);

        [HttpGet]
        [Route("wallet/{id}")]
        public IEnumerable<Operation> GetOperationsByWalletId(int id)
            => this.operationRepository.GetOperationsByWalletId(id);

        [HttpGet]
        [Route("person/{id}")]
        public IEnumerable<Operation> GetOperationsByPersonId(int id)
            => this.operationRepository.GetOperationsByPersonId(id);

        [HttpGet]
        [Route("person/{personId}/wallet/{walletId}")]
        [Route("wallet/{walletId}/person/{personId}")]
        public IEnumerable<Operation> GetOperationsByPersonAndWalletId(int personId, int walletId)
            => this.operationRepository.GetOperationsByPersonAndWalletId(personId, walletId);

        [HttpGet]
        [Route("transaction/{id}")]
        public IEnumerable<Operation> GetOperations(int id)
            => this.operationRepository.GetOperationsByTransactionId(id);
    }
}
