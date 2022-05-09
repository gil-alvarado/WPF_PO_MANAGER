using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO_MANAGER.Commands
{
    public class DeletePurchaseOrderCommand : CommandBase
    {
        private EditPurchaseOrderViewModel editPurchaseOrderViewModel;
        private ShopStore shopStore;
        private INavigationService listingViewNavigationService;

        public DeletePurchaseOrderCommand(EditPurchaseOrderViewModel editPurchaseOrderViewModel, ShopStore shopStore, 
            INavigationService listingViewNavigationService)
        {
            this.editPurchaseOrderViewModel = editPurchaseOrderViewModel;
            this.shopStore = shopStore;
            this.listingViewNavigationService = listingViewNavigationService;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("Deleted PO");
            listingViewNavigationService.Navigate();
        }
    }
}
