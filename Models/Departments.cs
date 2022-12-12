using System.Collections.Generic;
using System.Linq;
using Vodovoz.Exceptions;

namespace Vodovoz.Models
{
    internal class Departments
    {
        private readonly List<Department> _departments;

        public Departments()
        {
            _departments= new List<Department>();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departments;
        }

        public void AddDepartment(Department incomingDepartment)
        {
            foreach (var existingDepartment in _departments)
            {
                if (existingDepartment.Id == incomingDepartment.Id)
                {
                    throw new DepartmentConflictException(existingDepartment, incomingDepartment);
                }
            }

            _departments.Add(incomingDepartment);
        }

        public Department GetDepartmentById(int id)
        {
            foreach (Department department in _departments)
            {
                if (department.Id == id)
                {
                    return department;
                }
            }

            throw new NoSuchDepartmentException();
        }
    }
}
