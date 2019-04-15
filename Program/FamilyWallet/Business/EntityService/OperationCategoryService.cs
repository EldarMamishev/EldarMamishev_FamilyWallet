using Business.EntityService.Base;
using Business.EntityService.Interface;
using Business.Static;
using Data.EF.UnitOfWork.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Repository.Base;

namespace Business.EntityService
{
    public class OperationCategoryService : EntityServiceBase<OperationCategory>, IOperationCategoryService
    {
        public void Create(string name, OperationType operationType)
        {
            CheckArgument.CheckForNull(name, nameof(name));

            OperationCategory operationCategory = new OperationCategory() { Name = name, Type = operationType };
            this.GetRepository().Add(operationCategory);
            this.UnitOfWork.SaveChanges();
        }

        protected override IEntityRepository<OperationCategory> GetRepository()
            => this.UnitOfWork.OperationCategoryRepository;

        public OperationCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
