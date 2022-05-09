using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services.PurchaseOrderCreator
{
    public interface IPurchaseOrderCreator
    {
        Task CreatePurchaseOrder(PurchaseOrder purchaseOrder);
    }
}
