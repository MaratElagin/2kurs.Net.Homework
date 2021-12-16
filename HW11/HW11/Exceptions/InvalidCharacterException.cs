using System;

namespace HW11.Exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException(string message)
            : base(message)
        {
        }
    }
}