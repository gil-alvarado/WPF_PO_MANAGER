using PO_MANAGER.Services.PurchaseOrderCreator;
using PO_MANAGER.Services.PurchaseOrderProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class PurchaseOrderBook
    {
        private readonly IPurchaseOrderProvider purchaseOrderProvider;
        private readonly IPurchaseOrderCreator purchaseOrderCreator;

        public PurchaseOrderBook(IPurchaseOrderProvider _purchaseOrderProvider, IPurchaseOrderCreator _purchaseOrderCreator)
        {
            purchaseOrderProvider = _purchaseOrderProvider;
            purchaseOrderCreator = _purchaseOrderCreator;
        }
        public Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return purchaseOrderProvider.GetAllPurchaseOrders();
        }
        public Task AddPurchaseOrder(PurchaseOrder purchaseOrder) => purchaseOrderCreator.CreatePurchaseOrder(purchaseOrder);
    }
}
