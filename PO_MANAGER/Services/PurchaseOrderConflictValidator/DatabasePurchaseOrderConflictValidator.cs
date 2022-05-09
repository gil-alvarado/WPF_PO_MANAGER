using PO_MANAGER.DbContexts;
using PO_MANAGER.DTOs;
using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services.PurchaseOrderConflictValidator
{
    public class DatabasePurchaseOrderConflictValidator : IPurchaseOrderConflictValidator
    {
        private readonly PoManagerDbContextFactory _poManagerDbContextFactory;
        public DatabasePurchaseOrderConflictValidator(PoManagerDbContextFactory dbContextFactory)
        {
            _poManagerDbContextFactory = dbContextFactory;
        }

        public Task<PurchaseOrder> GetConflictingPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using(PoManagerContext context = _poManagerDbContextFactory.CreateDbContext())
            {
                PurchaseOrderDTO dto = context.PurchaseOrders
                    .Where(p => p.PurchaseOrder.Equals(purchaseOrder.PO))
                    .FirstOrDefault();
                if(dto == null)
                    return null;
                return null;
                //return ToPurchaseOrder(dto);
            }
        }

        private static PurchaseOrder ToPurchaseOrder(PurchaseOrderDTO poDto)
        {
            return new PurchaseOrder(poDto.PurchaseOrder,
                poDto.OriginalShipDate, poDto.CurrentShipDate, poDto.EtaDate, poDto.FolloUpDate,
                new Supplier(poDto.Supplier), "STATUS", "category",
                poDto.Quantity, poDto.LandedCost, poDto.InvoicePrice, new Bearing(poDto.Bearing));
        }
    }
}
