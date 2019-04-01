namespace Business.Validation.EntityValidation.Interface
{
    public interface IEntityValidator<TEntity>
    {
        void Validate(TEntity entity);
    }
}
