using PO_MANAGER.DbContexts;
using PO_MANAGER.Models;
using PO_MANAGER.NavigationService;
using PO_MANAGER.Services;
using PO_MANAGER.Services.PurchaseOrderCreator;
using PO_MANAGER.Services.PurchaseOrderProviders;
using PO_MANAGER.Stores;
using PO_MANAGER.ViewModels;
using System.Windows;

namespace PO_MANAGER
{
    /// <summary>
    /// Interaction logic for App.xaml
    ///         public NavigationBarViewModel(AccountStore accountStore,
    ///        NavigationService<PurchaseOrderListingViewModel> listingViewNavigationService,
    ///        NavigationService<CreatePurchaseOrderViewModel> createPoNavigationService,
    ///        NavigationService<LoginViewModel> loginViewNavigationService,
    ///        NavigationService<ManageUsersViewModel> manageUsersNavigationService)
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "";
        
        private readonly Shop _shop;
        private readonly ShopStore _shopStore;
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        private readonly Account _account;
        private readonly AccountStore _accountStore;

        private readonly PeopleStore _peopleStore;

        private readonly PoManagerDbContextFactory dbContextFactory;

        public App()
        {
            dbContextFactory = new PoManagerDbContextFactory(CONNECTION_STRING);
            IPurchaseOrderProvider _purchaseOrderProvider = new DatabasePurchaseOrderProvider(dbContextFactory);
            IPurchaseOrderCreator _purchaseOrderCreator = new DatabasePurchaseOrderCreator(dbContextFactory);
            
            
            PurchaseOrderBook _purchaseOrderBook = new PurchaseOrderBook(_purchaseOrderProvider, _purchaseOrderCreator);
            BearingBook _bearingBook = new BearingBook();
            _shop = new Shop("Bearing Shop", _purchaseOrderBook, _bearingBook);
            _account = new Account();
            _accountStore = new AccountStore();
            _shopStore = new ShopStore(_shop);
            _navigationStore = new NavigationStore();
            _modalNavigationStore = new ModalNavigationStore();


            _peopleStore = new PeopleStore();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //VIEW MODEL BASE
            //_navigationStore.CurrentViewModel = LoginViewModel();
            
            INavigationService navigationService = CreateLoginNavigationService();
            //INavigationService navigationService = CreateListingViewNavigationService();
            navigationService.Navigate();
            MainWindow = new MainWindow()
            {
                //make all bindings operational
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };

            MainWindow.Show();  
            base.OnStartup(e);
        }

        /*
        private LoginViewModel LoginViewModel()
        {
            return new LoginViewModel( _shopStore,
                new NavigationService<PurchaseOrderListingViewModel>(_navigationStore, PurchaseOrderListingViewModel) );
        }
        private CreatePurchaseOrderViewModel CreatePurchaseOrderViewModel()
        {
            return new CreatePurchaseOrderViewModel(_shopStore,
                new NavigationService<PurchaseOrderListingViewModel>(_navigationStore, PurchaseOrderListingViewModel) );
        }
        private EditPurchaseOrderViewModel EditPurchaseOrderViewModel()
        {
            return new EditPurchaseOrderViewModel(_shopStore,
                new NavigationService<PurchaseOrderListingViewModel>(_navigationStore, PurchaseOrderListingViewModel));
        }
        private NotesViewModel NotesViewModel()
        {
            return new NotesViewModel( _shopStore,
                new NavigationService<PurchaseOrderListingViewModel>(_navigationStore, PurchaseOrderListingViewModel) );
        }
        private ManageUsersViewModel ManageUsersViewModel()
        {
            return new ManageUsersViewModel( _shopStore,
                new NavigationService<PurchaseOrderListingViewModel>( _navigationStore, PurchaseOrderListingViewModel) );
        }
        private CreatePoReportViewModel ReportViewModel()
        {
            return new CreatePoReportViewModel( 
                new NavigationService<PurchaseOrderListingViewModel>(_navigationStore, PurchaseOrderListingViewModel) );

        }
        private PurchaseOrderListingViewModel PurchaseOrderListingViewModel()
        {
            return new PurchaseOrderListingViewModel(
                new NavigationService<CreatePoReportViewModel>(_navigationStore, ReportViewModel),
                new NavigationService<EditPurchaseOrderViewModel>(_navigationStore, EditPurchaseOrderViewModel) );

        }
        */
        //------------------------------------
        //public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        //------------------------------------



        //------------------------------------
        //          Login Navigation
        //------------------------------------
        private INavigationService CreateLoginNavigationService()
        {

            return new ModalNavigationService<LoginViewModel>(_modalNavigationStore,
                //() => new LoginViewModel(_accountStore, CreateListingViewNavigationService() ));
                () => CreateLoginViewModel() );
        }
        private LoginViewModel CreateLoginViewModel()
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(_modalNavigationStore),
                CreateListingViewNavigationService()
                );

            return new LoginViewModel( _accountStore , navigationService);
        }
        //------------------------------------
        //         End Login Navigation
        //------------------------------------
        private INavigationService CreatePoNavigationService()
        {
            return new LayoutNavigationService<CreatePurchaseOrderViewModel>(_navigationStore,
                () => new CreatePurchaseOrderViewModel(_shopStore, CreateListingViewNavigationService() ),
                CreateNavigationBarViewModel);
        }
        private INavigationService CreateEditPoNavigationService()
        {
            return new LayoutNavigationService<EditPurchaseOrderViewModel>(_navigationStore,
                () => new EditPurchaseOrderViewModel(_shopStore, CreateListingViewNavigationService()),
                CreateNavigationBarViewModel);
        }
        private INavigationService CreateReportViewNavigationService()
        {
            return new LayoutNavigationService<CreatePoReportViewModel>(_navigationStore,
                () => new CreatePoReportViewModel( CreateListingViewNavigationService() ),
                CreateNavigationBarViewModel);
        }
        private INavigationService CreateManageUsersNavigationService()
        {
            return new LayoutNavigationService<ManageUsersViewModel>(_navigationStore,
                () => new ManageUsersViewModel(_shopStore, CreateListingViewNavigationService()),
                CreateNavigationBarViewModel);
        }
        private INavigationService CreateAddPersonNavigationService()
        {
            CompositeNavigationService closeModalNavigationService = new CompositeNavigationService(
             new CloseModalNavigationService(_modalNavigationStore),
             CreateListingViewNavigationService()
             );
            
            
            return new ModalNavigationService<AddPersonViewModel>(
                _modalNavigationStore, 
                () => new AddPersonViewModel(_peopleStore, closeModalNavigationService) );
        }
        private INavigationService CreateListingViewNavigationService()
        {
            return new LayoutNavigationService<PurchaseOrderListingViewModel>
                (
                _navigationStore,
                //-------------
                () => new PurchaseOrderListingViewModel(
                    _peopleStore, _accountStore,

                    CreateReportViewNavigationService(), 
                    CreateEditPoNavigationService(),
                    CreateAddPersonNavigationService() ),
                //-------------
                CreateNavigationBarViewModel) ;
        }



        
        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(_accountStore,
                CreateListingViewNavigationService(),
                CreatePoNavigationService(),
                CreateLoginNavigationService(),
                CreateManageUsersNavigationService());
        }
        
        
    }
}
