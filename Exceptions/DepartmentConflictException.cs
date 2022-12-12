using System;
using Vodovoz.Models;

namespace Vodovoz.Exceptions
{
    internal class DepartmentConflictException : Exception
    {
        public Department ExistingDepartment { get; }
        public Department IncomingDepartment { get; }

        public DepartmentConflictException(Department existingDepartment, Department incomingDepartment)
        {
            ExistingDepartment = existingDepartment;
            IncomingDepartment = incomingDepartment;
        }

        public DepartmentConflictException(string? message, Department existingDepartment, Department incomingDepartment) : base(message)
        {
            ExistingDepartment = existingDepartment;
            IncomingDepartment = incomingDepartment;
        }

        public DepartmentConflictException(string? message, Exception? innerException, Department existingDepartment, Department incomingDepartment) : base(message, innerException)
        {
            ExistingDepartment = existingDepartment;
            IncomingDepartment = incomingDepartment;
        }
    }
}
