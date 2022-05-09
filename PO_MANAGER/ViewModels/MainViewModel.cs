using PO_MANAGER.Commands;
using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PO_MANAGER.ViewModels
{
    //MainWindow XAML: views:ReservationListingView DataContext="{Binding CurrentViewModel}"
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsModalOpen;
        
        public MainViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
        }

        private void OnCurrentModalViewModelChanged()
        {
             OnPropertyChanged(nameof(CurrentModalViewModel));
             OnPropertyChanged(nameof(IsModalOpen));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }

}
