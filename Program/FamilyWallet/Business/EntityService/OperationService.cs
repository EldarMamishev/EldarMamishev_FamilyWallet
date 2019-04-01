using System;
using System.Collections.Generic;
using System.Text;
using Business.EntityService.Base;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;

namespace Business.EntityService
{
    public class OperationService : EntityServiceBase<Operation>
    {
        public override void Delete(int id)
            => this.Delete(id, this.UnitOfWork.OperationRepository);

        public override ICollection<Operation> GetAll()
            => this.GetAll(this.UnitOfWork.OperationRepository);

        public override Operation GetById(int id)
            => this.GetById(id, this.UnitOfWork.OperationRepository);

        public OperationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
