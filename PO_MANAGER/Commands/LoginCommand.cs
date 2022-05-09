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
using System.Windows;

namespace PO_MANAGER.Commands
{
    public  class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = navigationService;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            if ( string.Equals(_viewModel.Username, "Gil") && string.Equals(_viewModel.Password, "admin") )
            {
                Account account = new Account()
                {
                    Username = _viewModel.Username, //$"{_viewModel.Username}@test.com",
                    Role = "admin"

                };
                _accountStore.CurrentAccount = account;
                _navigationService.Navigate();
            }
            else if( string.Equals(_viewModel.Password, "pw") )
            {
                Account account = new Account()
                {
                    Username = _viewModel.Username, //$"{_viewModel.Username}@test.com",
                    Role = "standard"

                };
                _accountStore.CurrentAccount = account;
                _navigationService.Navigate();
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username)
                && !string.IsNullOrEmpty(_viewModel.Password)
                && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username)
                || e.PropertyName == nameof(LoginViewModel.Password)
                )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
