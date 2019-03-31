using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class InvalidPrimaryKeyException : Exception
    {
        public InvalidPrimaryKeyException(string message)
            : base(message)
        { }
    }
}
