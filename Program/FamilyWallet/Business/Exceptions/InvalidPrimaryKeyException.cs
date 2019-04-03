namespace Business.Exceptions
{
    public class InvalidPrimaryKeyException : InvalidPropertyException
    {
        public InvalidPrimaryKeyException(string message)
            : base(message)
        { }
    }
}
