using Microsoft.EntityFrameworkCore;
using PO_MANAGER.DTOs;
using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.DbContexts
{
    public class PoManagerContext : DbContext
    {
        public PoManagerContext(DbContextOptions options) : base(options)
        { }

        public DbSet<PurchaseOrderDTO> PurchaseOrders { get; set; }

        public DbSet<SupplierDTO> Suppliers { get; set; }

    }
}
