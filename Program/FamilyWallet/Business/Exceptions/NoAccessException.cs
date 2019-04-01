using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class NoAccessException : Exception
    {
        public NoAccessException(string message) : base(message)
        { }
    }
}
