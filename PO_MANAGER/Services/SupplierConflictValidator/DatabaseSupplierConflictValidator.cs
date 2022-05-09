using PO_MANAGER.DbContexts;
using PO_MANAGER.DTOs;
using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services.SupplierConflictValidator
{
    public class DatabaseSupplierConflictValidator : ISupplierConflictValidator
    {
        private readonly PoManagerDbContextFactory _dbContextFactory;
        public DatabaseSupplierConflictValidator(PoManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Task<Supplier> GetConflictingSupplier(Supplier supplier)
        {
            using(PoManagerContext context = _dbContextFactory.CreateDbContext())
            {
                return null;
            }
            return null;
        }
        private static Supplier ToSupplier(SupplierDTO supplier)
        {
            return new Supplier(supplier.Name);
        }
    }
}
