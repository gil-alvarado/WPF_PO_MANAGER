using PO_MANAGER.DbContexts;
using PO_MANAGER.DTOs;
using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services.PurchaseOrderCreator
{
    public class DatabasePurchaseOrderCreator : IPurchaseOrderCreator
    {
        /// <summary>
        /// access DBset with acquired session to interact with daatbase and application
        /// </summary>
        private readonly PoManagerDbContextFactory _dbContextFactory;

        public DatabasePurchaseOrderCreator(PoManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using( PoManagerContext context = _dbContextFactory.CreateDbContext())
            {
                PurchaseOrderDTO purchaseOrderDTO = ToReservationDTO(purchaseOrder);

                context.PurchaseOrders.Add(purchaseOrderDTO);   
                await context.SaveChangesAsync();   //update database
            }
        }
        /// <summary>
        /// converto Reservation to ReservationDTO to inserto int database
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        private PurchaseOrderDTO ToReservationDTO(PurchaseOrder purchaseOrder)
        {
            return new PurchaseOrderDTO
            {
                PurchaseOrder = purchaseOrder.PO
            };
        }
    }
}
