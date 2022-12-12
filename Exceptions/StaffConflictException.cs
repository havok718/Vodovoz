using System;
using Vodovoz.Models;

namespace Vodovoz.Exceptions
{
    internal class StaffConflictException : Exception
    {
        public StaffMember ExistingMember { get; }
        public StaffMember IncomingMember { get; }

        public StaffConflictException(StaffMember existingMember, StaffMember incomingMember)
        {
            ExistingMember = existingMember;
            IncomingMember = incomingMember;
        }

        public StaffConflictException(string? message, StaffMember existingMember, StaffMember incomingMember) : base(message)
        {
            ExistingMember = existingMember;
            IncomingMember = incomingMember;
        }

        public StaffConflictException(string? message, Exception? innerException, StaffMember existingMember, StaffMember incomingMember) : base(message, innerException)
        {
            ExistingMember = existingMember;
            IncomingMember = incomingMember;
        }
    }
}
