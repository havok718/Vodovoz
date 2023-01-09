using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Departments
{
    internal interface IDepartmentConflictValidator
    {
        Task<Department> GetConflictingDepartment(Department department);
    }
}
