using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Departments
{
    internal interface IDepartmentCRU
    {
        Task CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task RemoveDepartment(int id);
    }
}
