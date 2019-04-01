using System;

namespace Business.Exceptions
{
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException(string message)
            : base(message)
        { }
    }
}

