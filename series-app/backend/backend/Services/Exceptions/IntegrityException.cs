﻿using System;

namespace backend.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) 
            : base(message)
        {
        }
    }
}
