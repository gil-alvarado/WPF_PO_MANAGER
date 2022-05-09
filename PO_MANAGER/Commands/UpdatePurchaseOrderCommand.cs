using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO_MANAGER.Commands
{
    public class UpdatePurchaseOrderCommand : CommandBase
    {
        private readonly EditPurchaseOrderViewModel createPurchaseOrderViewModel;
        private readonly ShopStore shopStore;
        private readonly INavigationService listingViewNavigationService;

        public UpdatePurchaseOrderCommand(EditPurchaseOrderViewModel createPurchaseOrderViewModel, 
            ShopStore shopStore, INavigationService listingViewNavigationService)
        {
            this.createPurchaseOrderViewModel = createPurchaseOrderViewModel;
            this.shopStore = shopStore;
            this.listingViewNavigationService = listingViewNavigationService;

            this.createPurchaseOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(createPurchaseOrderViewModel.PurchaseOrder) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("PURCHASE ORDER UPDATED");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatePurchaseOrderViewModel.PurchaseOrder))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
