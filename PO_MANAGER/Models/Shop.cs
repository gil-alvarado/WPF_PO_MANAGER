using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class Shop
    {
        public string? Name { get; set; }
        private readonly PurchaseOrderBook _purchaseOrderBook;
        private readonly BearingBook _bearingBook;
        public Shop(string Name, PurchaseOrderBook purchaseOrderBook, BearingBook bearingBook)
        {
            this.Name = Name;
            _purchaseOrderBook = purchaseOrderBook;
            _bearingBook = bearingBook;
        }

        public Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrders()
        {
            //return _purchaseOrderBook.GetAllPurchaseOrders();
            return null;
        }
        public Task<IEnumerable<Bearing>> GetAllBearings()
        {
            //return _bearingBook.GetAllBearings();
            return null;
        }

        /*
        public Task AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderBook.AddPurchaseOrder(purchaseOrder);
        }
        public Task AddBearing(Bearing bearing)
        {
            _bearingBook.AddBearing(bearing);
        }
        */
    }
}
