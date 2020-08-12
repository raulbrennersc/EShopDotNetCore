using System;

namespace Services.Exceptions
{
    public class NotTheOwnerException : Exception
    {
        public NotTheOwnerException(string message) : base(message) { }
    }
}