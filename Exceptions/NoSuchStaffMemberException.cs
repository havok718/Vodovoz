using System;

namespace Vodovoz.Exceptions
{
    internal class NoSuchStaffMemberException : Exception
    {
        public NoSuchStaffMemberException()
        {
        }

        public NoSuchStaffMemberException(string? message) : base(message)
        {
        }

        public NoSuchStaffMemberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
