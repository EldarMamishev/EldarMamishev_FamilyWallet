using System;
using Business.Validation.Interface;

namespace Business.Validation
{
    public class ArgumentValidator : IArgumentValidator
    {
        public void CheckForNull(object argument, string message)
        {
            if (argument == null)
                throw new ArgumentNullException(message);
        }
    }
}
