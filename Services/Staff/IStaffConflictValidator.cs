using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal interface IStaffConflictValidator
    {
        Task<StaffMember> GetConflictingStaffMember(StaffMember staffMember);
    }
}
