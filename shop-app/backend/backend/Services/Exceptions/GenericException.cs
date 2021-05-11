using System;

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
