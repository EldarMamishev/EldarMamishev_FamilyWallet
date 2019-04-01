using System;

namespace Business.Exceptions
{
    public class NoAccessException : Exception
    {
        public NoAccessException(string message) : base(message)
        { }
    }
}
