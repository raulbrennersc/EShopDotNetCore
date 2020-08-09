using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class InvalidUpdateException : Exception 
    {
        public InvalidUpdateException(string message) : base(message) {}
    }
}
