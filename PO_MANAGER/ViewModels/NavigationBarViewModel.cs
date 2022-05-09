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
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public ICommand NavigateListingViewCommand { get; }
        public ICommand NavigateCreatePoCommand { get; }
        public ICommand ManageUsersCommand { get; }
        public ICommand LogoutCommand { get; }

        public string Username => _accountStore.CurrentAccount.Username;
        public bool IsLoggedIn => _accountStore.IsLoggedIn;
        public bool IsAdmin  => _accountStore.IsAdmin;
        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService listingViewNavigationService,
            INavigationService createPoNavigationService,
            INavigationService loginViewNavigationService,
            INavigationService manageUsersNavigationService)
        {

            _accountStore = accountStore;

            NavigateListingViewCommand = new NavigateCommand(listingViewNavigationService);
            NavigateCreatePoCommand = new NavigateCommand(createPoNavigationService);
            ManageUsersCommand = new NavigateCommand(manageUsersNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }
        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }
    }
}
