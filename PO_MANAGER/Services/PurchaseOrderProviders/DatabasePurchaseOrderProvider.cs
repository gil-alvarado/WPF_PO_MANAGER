using PO_MANAGER.DbContexts;
using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services.PurchaseOrderProviders
{
    public class DatabasePurchaseOrderProvider : IPurchaseOrderProvider
    {
        private readonly PoManagerDbContextFactory _dbContextFactory;
        public DatabasePurchaseOrderProvider(PoManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders()
        {
            using(PoManagerContext DB_CONTEXT = _dbContextFactory.CreateDbContext())
            {
                //await Task.Delay(3000);

                ///PurchaseOrderDTO
                //IEnumerable<PurchaseOrder> purchaseOrders = DB_CONTEXT.PurchaseOrders.ToListAsync();
                //return purchaseOrders.Select(poDto => ToPurchaseOrder(poDto));
                return null;
            }
        }

        /*
         PurchaseOrder(string? pO, 
            DateTime originalShipDate, DateTime currentShipDate, DateTime etaDate, DateTime folloUpDate, 
            Supplier? supplier, string? status, string? category, 
            int? quantity, decimal? landedCost, decimal? invoicePrice, Bearing? bearing)
        */
        private static PurchaseOrder ToPurchaseOrder(PurchaseOrder poDto)
        {
            return new PurchaseOrder(poDto.PO,
                poDto.OriginalShipDate, poDto.CurrentShipDate, poDto.EtaDate, poDto.FolloUpDate,
                poDto.Supplier, "STATUS", "category",
                poDto.Quantity, poDto.LandedCost, poDto.InvoicePrice, poDto.Bearing);
        }
    }
}
