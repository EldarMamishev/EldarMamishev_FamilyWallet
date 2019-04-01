using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.Interface
{
    public interface IArgumentValidator
    {
        void CheckForNull(object argument, string message);
    }
}
