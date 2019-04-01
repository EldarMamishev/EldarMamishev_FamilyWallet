using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class InvalidPropertyException : Exception
    {
        public InvalidPropertyException(string message)
            : base(message)
        { }
    }
}

