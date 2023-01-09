using System;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.DbContexts;
using Vodovoz.DTOs;
using Vodovoz.Models;

namespace Vodovoz.Services.Staff
{
    internal class DbStaffMemberCRU : IStaffMemberCRU
    {
        private readonly VodovozDbContextFactory _dbContextFactory;

        public DbStaffMemberCRU(VodovozDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateStaffMember(StaffMember staffMember)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                StaffMemberDTO staffMemberDTO = new StaffMemberDTO()
                {
                    LastName = staffMember.LastName,
                    SurName = staffMember.SurName,
                    Name = staffMember.Name,
                    Birthday = staffMember.Birthday,
                    Gender = staffMember.Gender,
                    DepartmentName = staffMember.DepartmentName
                };

                context.StaffMembers.Add(staffMemberDTO);
                await context.SaveChangesAsync();
                staffMember.Id = staffMemberDTO.Id;
            }
        }

        public async Task RemoveStaffMember(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                foreach (var staffMember in context.StaffMembers)
                {
                    if (staffMember.Id == id)
                    {
                        context.StaffMembers.Remove(staffMember);
                        continue;
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateStaffMember(StaffMember staffMember)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var staffMemberDTO = context.StaffMembers.Where(x => x.Id == staffMember.Id).FirstOrDefault();

                staffMemberDTO.LastName = staffMember.LastName;
                staffMemberDTO.SurName = staffMember.SurName;
                staffMemberDTO.Name = staffMember.Name;
                staffMemberDTO.Birthday = staffMember.Birthday;
                staffMemberDTO.Gender = staffMember.Gender;
                staffMemberDTO.DepartmentName = staffMember.DepartmentName;

                await context.SaveChangesAsync();
            }
        }
    }
}
