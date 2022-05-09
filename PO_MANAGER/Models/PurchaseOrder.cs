using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class PurchaseOrder
    {
        public string? PO { get; }
        public DateTime OriginalShipDate { get; }
        public DateTime CurrentShipDate { get; }
        public DateTime EtaDate { get; }
        public DateTime FolloUpDate { get; }
        public Supplier? Supplier { get; }
        public string? Status { get; } //NOT NULL (YES/NO) 
        public string? Category { get; } //MultiLine PO
        
        //ORDER DETAILS
        public int? Quantity { get; }   
        public decimal? LandedCost { get; } 
        public decimal? InvoicePrice { get; }   
        public Bearing? Bearing { get; }

        public PurchaseOrder(string? pO, 
            DateTime originalShipDate, DateTime currentShipDate, DateTime etaDate, DateTime folloUpDate, 
            Supplier? supplier, string? status, string? category, 
            int? quantity, decimal? landedCost, decimal? invoicePrice, Bearing? bearing)
        {
            PO = pO;
            OriginalShipDate = originalShipDate;
            CurrentShipDate = currentShipDate;
            EtaDate = etaDate;
            FolloUpDate = folloUpDate;
            Supplier = supplier;
            Status = status;
            Category = category;
            Quantity = quantity;
            LandedCost = landedCost;
            InvoicePrice = invoicePrice;
            Bearing = bearing;
        }
    }
}
