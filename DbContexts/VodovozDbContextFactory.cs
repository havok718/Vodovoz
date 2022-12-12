using Microsoft.EntityFrameworkCore;

namespace Vodovoz.DbContexts
{
    internal class VodovozDbContextFactory
    {
        private readonly string _connString;

        public VodovozDbContextFactory(string connString)
        {
            _connString = connString;
        }

        public ApplicationContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlite(_connString).Options;

            return new ApplicationContext(options);
        }
    }
}
