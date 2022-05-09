using PO_MANAGER.Commands;
using PO_MANAGER.Models;
using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PO_MANAGER.ViewModels
{
    public class PurchaseOrderListingViewModel : ViewModelBase  
    {
        private string? _purchaseOrder;
        public string? PurchaseOrder
        {
            get => _purchaseOrder;
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

        private DateTime? _startDate = 
            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public DateTime? StartTime
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime? _endTime =
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public DateTime? EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        /*
         * BOOLEAN HELPERS
         */
        private bool? HasStartDateBeforeEndDate => StartTime < EndTime;

        /*
         * COMMANDS
         */

        public ICommand RefreshCommand { get; }
        public ICommand CreateReportCommand { get; }


        /*
         * NAVIGATION BAR
         */

        private readonly ObservableCollection<PersonViewModel> _purchaseOrders;
        public IEnumerable<PersonViewModel> Orders => _purchaseOrders;

        private readonly PeopleStore _peopleStore;
        private readonly AccountStore _accountStore;
        public ICommand AddPersonCommand { get; }
        public PurchaseOrderListingViewModel( PeopleStore peopleStore, AccountStore accountStore,
            INavigationService createReportNavigationService,
            INavigationService createEditNavigationService, 
            INavigationService addPersonNavigationCommand 
            ) 
        {
            _peopleStore = peopleStore;
            _accountStore = accountStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationCommand);

            RefreshCommand = new NavigateCommand(createEditNavigationService);
            //CreatePoCommand = new NavigateCommand<CreatePurchaseOrderViewModel>(createPoNavigationService);
            CreateReportCommand = new NavigateCommand(createReportNavigationService);

            _purchaseOrders = new ObservableCollection<PersonViewModel>();

            _purchaseOrders.Add(new PersonViewModel("Gil"));
            _purchaseOrders.Add(new PersonViewModel("Dad"));

            _peopleStore.PersonAdded += OnPersonAdded;

        }

        private void OnPersonAdded(string name)
        {
            _purchaseOrders.Add(new PersonViewModel(name));
            foreach(PersonViewModel person in _purchaseOrders)
            {
                MessageBox.Show(person.Name);
            }
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            
            base.Dispose();
        }

        private void OnCurrentAccountChanged()
        {

        }

        ~PurchaseOrderListingViewModel()
        {

        }

 
    }
}
