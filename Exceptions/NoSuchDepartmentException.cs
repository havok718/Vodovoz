using System;

namespace Vodovoz.Exceptions
{
    internal class NoSuchDepartmentException : Exception
    {
        public NoSuchDepartmentException()
        {
        }

        public NoSuchDepartmentException(string? message) : base(message)
        {
        }

        public NoSuchDepartmentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
