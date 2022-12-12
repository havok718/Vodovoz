using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vodovoz.Models
{
    internal class Main
    {
        private readonly Staff _staff;
        private readonly Departments _departments;
        private readonly Orders _orders;

        public Main(Staff staff)
        {
            _staff = staff;
            _departments = new Departments();
            _orders = new Orders();
        }

        public async Task AddStaffMember(StaffMember staffMember)
        {
            await _staff.AddStaffMember(staffMember);
        }

        public async Task EditStaffMember(StaffMember staffMember)
        {
            await _staff.EditStaffMember(staffMember);
        }

        public async Task<IEnumerable<StaffMember>> GetAllStaffMembers()
        {
            return await _staff.GetStaffMembers();
        }

        public void AddDepartment(Department department)
        {
            _departments.AddDepartment(department);
        }

        public void AddOrder(Order order)
        {
            _orders.AddOrder(order);
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _departments.GetDepartmentById(departmentId);
        }

        internal async Task RemoveStaffMember(int id)
        {
            await _staff.RemoveStaffMember(id);
        }
    }
}
