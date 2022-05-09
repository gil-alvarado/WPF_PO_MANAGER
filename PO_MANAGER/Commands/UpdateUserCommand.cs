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
    public class UpdateUserCommand : CommandBase
    {
        private readonly ManageUsersViewModel _manageUsersViewModel;
        public UpdateUserCommand(ManageUsersViewModel manageUsersViewMoldel)
        {
            _manageUsersViewModel = manageUsersViewMoldel;

            _manageUsersViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_manageUsersViewModel.FirstName)
                && !string.IsNullOrEmpty(_manageUsersViewModel.LastName)
                && !string.IsNullOrEmpty(_manageUsersViewModel.Username)
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Added New User");
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (
                e.PropertyName == nameof(ManageUsersViewModel.FirstName)
                || e.PropertyName == nameof(ManageUsersViewModel.LastName)
                || e.PropertyName == nameof(ManageUsersViewModel.Username)
                )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
