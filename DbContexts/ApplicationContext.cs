using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.DTOs;

namespace Vodovoz.DbContexts
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StaffMemberDTO> StaffMembers { get; set; }
    }
}
