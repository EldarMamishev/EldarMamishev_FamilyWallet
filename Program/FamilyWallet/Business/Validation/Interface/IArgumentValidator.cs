namespace Business.Validation.Interface
{
    public interface IArgumentValidator
    {
        void CheckForNull(object argument, string message);
    }
}
