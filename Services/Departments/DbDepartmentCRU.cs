using System;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.DbContexts;
using Vodovoz.DTOs;
using Vodovoz.Models;

namespace Vodovoz.Services.Departments
{
    internal class DbDepartmentCRU : IDepartmentCRU
    {
        private readonly VodovozDbContextFactory _dbContextFactory;

        public DbDepartmentCRU(VodovozDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateDepartment(Department department)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                DepartmentDTO departmentDTO = new DepartmentDTO()
                { 
                    Name = department.Name,
                    StaffMemberId = department.Head
                };

                context.Departments.Add(departmentDTO);
                await context.SaveChangesAsync();
                department.Id = departmentDTO.Id;
            }
        }

        public async Task RemoveDepartment(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                foreach (var department in context.Departments)
                {
                    if (department.Id == id)
                    {
                        context.Departments.Remove(department);
                        continue;
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateDepartment(Department department)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var departmentDTO = context.Departments.Where(x => x.Id == department.Id).FirstOrDefault();

                departmentDTO.Name = department.Name;
                departmentDTO.StaffMemberId = department.Head;

                await context.SaveChangesAsync();
            }
        }
    }
}
