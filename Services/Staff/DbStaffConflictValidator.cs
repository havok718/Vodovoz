using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.DbContexts;
using Vodovoz.DTOs;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal class DbStaffConflictValidator : IStaffConflictValidator
    {
        private readonly VodovozDbContextFactory _dbContextFactory;

        public DbStaffConflictValidator(VodovozDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<StaffMember> GetConflictingStaffMember(StaffMember staffMember)
        {
            using (ApplicationContext context = _dbContextFactory.CreateDbContext())
            {
                StaffMemberDTO staffMemberDTO = await context.StaffMembers
                    .Where(x => x.LastName == staffMember.LastName).Where(x => x.SurName == staffMember.SurName)
                    .Where(x => x.Name == staffMember.Name)
                    .Where(x => x.Birthday.Equals(staffMember.Birthday))
                    .Where(x => x.Gender == staffMember.Gender)
                    .Where(x => x.DepartmentName == staffMember.DepartmentName)
                    .FirstOrDefaultAsync();

                if (staffMemberDTO == null)
                {
                    return null;
                }

                return new StaffMember(staffMemberDTO.Id, staffMemberDTO.LastName, staffMemberDTO.SurName, staffMemberDTO.Name, staffMemberDTO.Birthday, staffMemberDTO.Gender, staffMemberDTO.DepartmentName);
            }
        }
    }
}
