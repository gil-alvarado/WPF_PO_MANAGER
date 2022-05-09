using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.DbContexts
{
    public class PoManagerDbContextFactory
    {
        private readonly string _connectionString;
        public PoManagerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public PoManagerContext CreateDbContext()
        {
            //DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            //return new PoManagerContext(options);
            return null;
        }
    }
}
