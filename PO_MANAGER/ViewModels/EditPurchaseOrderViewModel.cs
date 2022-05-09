using PO_MANAGER.Commands;
using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PO_MANAGER.ViewModels
{
    public class EditPurchaseOrderViewModel : ViewModelBase
    {
        private string? _purchaseOrder;
        public string? PurchaseOrder
        {
            get
            {
                return _purchaseOrder;
            }
            set
            {
                _purchaseOrder = value;
                OnPropertyChanged(nameof(PurchaseOrder));
            }
        }

        private string? _bearingNumber;
        public string? BearingNumber
        {
            get => _bearingNumber;
            set
            {
                _bearingNumber = value;
                OnPropertyChanged(nameof(BearingNumber));
            }
        }

        private string? _supplier;
        public string? Supplier
        {
            get => _supplier;
            set
            {
                _supplier = value;
                OnPropertyChanged(nameof(Supplier));
            }
        }

        private string? _parameter;
        public string? Parameter
        {
            get => _parameter;
            set
            {
                _parameter = value;
                OnPropertyChanged(nameof(Parameter));
            }
        }

        //--------------------------------------
        //              STATUS/CONFIRMED
        //--------------------------------------

        //unsigned int
        private ushort? _quantity;
        public ushort? Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private decimal? _invoicePrice;
        public decimal? InvoicePrice
        {
            get => _invoicePrice;
            set
            {
                _invoicePrice = value;
                OnPropertyChanged(nameof(InvoicePrice));
            }
        }
        private decimal? _landingCost;
        public decimal? LandingCost
        {
            get => _landingCost;
            set
            {
                _landingCost = value;
                OnPropertyChanged(nameof(LandingCost));
            }
        }

        private DateTime _originalShipDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime OriginalShipDate
        {
            get => _originalShipDate;
            set
            {
                _originalShipDate = value;
                OnPropertyChanged(nameof(OriginalShipDate));
            }
        }

        private DateTime _etaDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime EtaDate
        {
            get => _etaDate;
            set
            {
                _etaDate = value;
                OnPropertyChanged(nameof(EtaDate));
            }
        }

        private DateTime _currentShipDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime CurrentShipDate
        {
            get => _currentShipDate;
            set
            {
                _currentShipDate = value;
                OnPropertyChanged(nameof(CurrentShipDate));
            }
        }

        private DateTime _followUpDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime FollowUpDate
        {
            get => _followUpDate;
            set
            {
                _followUpDate = value;
                OnPropertyChanged(nameof(FollowUpDate));
            }
        }

        public ICommand UpdateClosePoCommand { get; }
        public ICommand UpdatePoCommand { get; }
        public ICommand DeletePoCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand RemoveAttachmentCommand { get; }
        public ICommand AddEmailCommand { get; }
        public EditPurchaseOrderViewModel(ShopStore shopStore, 
            INavigationService listingViewNavigationService)
        {
            UpdatePoCommand = new UpdatePurchaseOrderCommand(this, shopStore, listingViewNavigationService);
            UpdateClosePoCommand = new UpdateClosePurchaseOrderCommand(this, shopStore, listingViewNavigationService);
            DeletePoCommand = new DeletePurchaseOrderCommand(this, shopStore, listingViewNavigationService);
            CancelCommand = new NavigateCommand(listingViewNavigationService);
            RemoveAttachmentCommand = new AttachmentManagementCommand(this, false);
            AddEmailCommand = new AttachmentManagementCommand(this, true);
        }
    }
}
