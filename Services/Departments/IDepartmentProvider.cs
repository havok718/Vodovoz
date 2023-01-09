using System.Collections.Generic;
using System.Threading.Tasks;
using Vodovoz.Models;

namespace Vodovoz.Services.Departments
{
    internal interface IDepartmentProvider
    {
        public Task<IEnumerable<Department>> GetAllDepartments();
    }
}
