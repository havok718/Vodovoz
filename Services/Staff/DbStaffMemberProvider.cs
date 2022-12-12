using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.DbContexts;
using Vodovoz.DTOs;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal class DbStaffMemberProvider : IStaffMemberProvider
    {
        private readonly VodovozDbContextFactory _dbContextFactory;

        public DbStaffMemberProvider(VodovozDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<StaffMember>> GetAllStaffMembers()
        {
            using (ApplicationContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<StaffMemberDTO> staffMemberDTOs = await context.StaffMembers.ToListAsync();
                return staffMemberDTOs.Select(x => new StaffMember(x.Id, x.LastName, x.SurName, x.Name, x.Birthday, x.Gender, x.Department));
            }
        }
    }
}
