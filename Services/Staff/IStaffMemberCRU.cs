using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal interface IStaffMemberCRU
    {
        Task CreateStaffMember(StaffMember staffMember);
        Task UpdateStaffMember(StaffMember staffMember);
        Task RemoveStaffMember(int id);
    }
}
