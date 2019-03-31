using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Exceptions
{
    public class InvalidForeignKeyException : Exception
    {
        public InvalidForeignKeyException(string message)
            : base(message)
        { }
    }
}
