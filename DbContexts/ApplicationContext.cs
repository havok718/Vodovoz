using Microsoft.EntityFrameworkCore;
using Vodovoz.DTOs;

namespace Vodovoz.DbContexts
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StaffMemberDTO> StaffMembers { get; set; }
        public DbSet<DepartmentDTO> Departments { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<ProductDTO> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDTO>().HasKey(x => new { x.Id, x.ProductId });
        }
    }
}
