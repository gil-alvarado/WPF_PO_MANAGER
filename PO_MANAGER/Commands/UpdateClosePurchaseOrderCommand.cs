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
    public class UpdateClosePurchaseOrderCommand : CommandBase
    {
        private readonly EditPurchaseOrderViewModel editPurchaseOrderViewModel;
        private readonly ShopStore shopStore;
        private readonly INavigationService listingViewNavigationService;

        public UpdateClosePurchaseOrderCommand(EditPurchaseOrderViewModel editPurchaseOrderViewModel,
            ShopStore shopStore, INavigationService listingViewNavigationService)
        {
            this.editPurchaseOrderViewModel = editPurchaseOrderViewModel;
            this.shopStore = shopStore;
            this.listingViewNavigationService = listingViewNavigationService;

            this.editPurchaseOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(editPurchaseOrderViewModel.PurchaseOrder) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("PURCHASE ORDER UPDATED");
            listingViewNavigationService.Navigate();
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
