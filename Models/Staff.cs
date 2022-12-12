using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.Exceptions;
using Vodovoz.Services.Staff;

namespace Vodovoz.Models
{
    internal class Staff
    {
        private readonly IStaffMemberProvider _staffMemberProvider;
        private readonly IStaffMemberCRU _staffMemberCRU;
        private readonly IStaffConflictValidator _staffConflictValidator;

        public Staff(IStaffMemberProvider staffMemberProvider, IStaffMemberCRU staffMemberCRU, IStaffConflictValidator staffConflictValidator)
        {
            _staffMemberProvider = staffMemberProvider;
            _staffMemberCRU = staffMemberCRU;
            _staffConflictValidator = staffConflictValidator;
        }

        public async Task<IEnumerable<StaffMember>> GetStaffMembers()
        {
            return await _staffMemberProvider.GetAllStaffMembers();
        }

        public async Task AddStaffMember(StaffMember staffMember)
        {
            StaffMember conflictingStaffMember = await _staffConflictValidator.GetConflictingStaffMember(staffMember);

            if (conflictingStaffMember != null) 
            {
                throw new StaffConflictException(conflictingStaffMember, staffMember);
            }

            await _staffMemberCRU.CreateStaffMember(staffMember);
            var lastStaffMember = _staffMemberProvider.GetAllStaffMembers();
        }

        public async Task EditStaffMember(StaffMember staffMember)
        {
            await _staffMemberCRU.UpdateStaffMember(staffMember);
        }

        internal async Task RemoveStaffMember(int id)
        {
            await _staffMemberCRU.RemoveStaffMember(id);
        }
    }
}
