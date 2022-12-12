using System.Collections.Generic;
using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal interface IStaffMemberProvider
    {
        public Task<IEnumerable<StaffMember>> GetAllStaffMembers();
    }
}
