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
    public class ManageUsersViewModel : ViewModelBase
    {
        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string? _lastName;  
        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        /*
        private string? _role;
        public string? Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        */

        private string? _username;
        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CloseCommand { get; }

        public ManageUsersViewModel(ShopStore shopStore, 
            INavigationService listingViewNavigationService)
        {
            AddCommand = new AddUserCommand(this);
            UpdateCommand = new UpdateUserCommand(this);
            DeleteCommand = new DeleteUserCommand(this);
            CloseCommand = new NavigateCommand(listingViewNavigationService);
        }
    }
}
