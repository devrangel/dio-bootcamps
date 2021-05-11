using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Exceptions
{
    public class GenericException : ApplicationException
    {
        public GenericException(string message) 
            : base(message)
        {
        }
    }
}
