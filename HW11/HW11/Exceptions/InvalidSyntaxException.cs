using System;

namespace HW11.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        public InvalidSyntaxException(string message)
            : base(message)
        {
        }
    }
}