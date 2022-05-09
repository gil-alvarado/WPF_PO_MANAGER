using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.DTOs
{
    public class PurchaseOrderDTO
    {
        /*
                return new PurchaseOrder(poDto.PO,
        poDto.OriginalShipDate, poDto.CurrentShipDate, poDto.EtaDate, poDto.FolloUpDate,
        poDto.Supplier, "STATUS", "category",
        poDto.Quantity, poDto.LandedCost, poDto.InvoicePrice, poDto.Bearing);
        
         */
        [Key]
        public Guid Id { get; set; }    
        public string? PurchaseOrder { get; set; }
        public DateTime OriginalShipDate { get; }
        public DateTime CurrentShipDate { get; }
        public DateTime EtaDate { get; }
        public DateTime FolloUpDate { get; }
        public string? Supplier { get; }
        public string? Status { get; } //NOT NULL (YES/NO) 
        public string? Category { get; } //MultiLine PO

        //ORDER DETAILS
        public int? Quantity { get; }
        public decimal? LandedCost { get; }
        public decimal? InvoicePrice { get; }
        public string? Bearing { get; }


    }
}
