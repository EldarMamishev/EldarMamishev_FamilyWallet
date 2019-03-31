using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class NoEntityExistingException : Exception
    {
        public NoEntityExistingException(string message) 
            : base(message)
        { }
    }
}
