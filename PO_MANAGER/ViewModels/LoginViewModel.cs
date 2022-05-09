using PO_MANAGER.Commands;
using PO_MANAGER.Models;
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
    public class LoginViewModel : ViewModelBase
    {
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

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }
        public LoginViewModel(AccountStore accountStore, INavigationService navigationService)
        {
            LoginCommand = new LoginCommand(this, accountStore, navigationService);
            ExitCommand = new LogoutCommand(accountStore);

        }
    }
}
