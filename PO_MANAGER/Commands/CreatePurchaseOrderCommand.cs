using PO_MANAGER.Models;
using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Commands
{
    public class CreatePurchaseOrderCommand : CommandBase
    {
        private readonly CreatePurchaseOrderViewModel createPurchaseOrderViewModel;
        private readonly ShopStore shopStore;
        private readonly INavigationService listingViewNavigationService;

        public CreatePurchaseOrderCommand(CreatePurchaseOrderViewModel createPurchaseOrderViewModel, 
            ShopStore shopStore,
            INavigationService listingViewNavigationService)
        {
            this.createPurchaseOrderViewModel = createPurchaseOrderViewModel;
            this.shopStore = shopStore;
            this.listingViewNavigationService = listingViewNavigationService;

            createPurchaseOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(createPurchaseOrderViewModel.PurchaseOrder)
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.BearingNumber)
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.Supplier)
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.Parameter)
                && createPurchaseOrderViewModel.Quantity > 0
                && createPurchaseOrderViewModel.InvoicePrice > 0
                && createPurchaseOrderViewModel.LandingCost > 0
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.OriginalShipDate.ToString())
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.EtaDate.ToString())
                && !string.IsNullOrEmpty(createPurchaseOrderViewModel.CurrentShipDate.ToString())
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder(
                createPurchaseOrderViewModel.PurchaseOrder,
                createPurchaseOrderViewModel.OriginalShipDate,
                createPurchaseOrderViewModel.CurrentShipDate,
                createPurchaseOrderViewModel.EtaDate,
                createPurchaseOrderViewModel.FollowUpDate,
                new Supplier(createPurchaseOrderViewModel.Supplier),
                "STATUS",
                "Category",
                createPurchaseOrderViewModel.Quantity,
                createPurchaseOrderViewModel.LandingCost,
                createPurchaseOrderViewModel.InvoicePrice,
                new Bearing(createPurchaseOrderViewModel.BearingNumber));

            listingViewNavigationService.Navigate();

        }
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatePurchaseOrderViewModel.PurchaseOrder)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.BearingNumber)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.Supplier)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.Parameter)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.Quantity)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.InvoicePrice)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.LandingCost)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.OriginalShipDate)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.EtaDate)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.CurrentShipDate)
                || e.PropertyName == nameof(CreatePurchaseOrderViewModel.FollowUpDate)
                )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
