using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class InvalidPrimaryKeyException : InvalidPropertyException
    {
        public InvalidPrimaryKeyException(string message)
            : base(message)
        { }
    }
}
