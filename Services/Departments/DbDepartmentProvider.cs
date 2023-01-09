using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.DbContexts;
using Vodovoz.DTOs;
using Vodovoz.Models;

namespace Vodovoz.Services.Departments
{
    internal class DbDepartmentProvider : IDepartmentProvider
    {
        private readonly VodovozDbContextFactory _dbContextFactory;

        public DbDepartmentProvider(VodovozDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            using(ApplicationContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DepartmentDTO> departmentDTOs = await context.Departments.ToListAsync();
                return departmentDTOs.Select(x => new Department(x.Id, x.Name, x.StaffMemberId));
            }
        }
    }
}
