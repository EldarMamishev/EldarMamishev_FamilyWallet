namespace Business.Exceptions
{
    public class InvalidForeignKeyException : InvalidPropertyException
    {
        public InvalidForeignKeyException(string message)
            : base(message)
        { }
    }
}
