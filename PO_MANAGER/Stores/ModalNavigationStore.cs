using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public bool IsModalOpen => CurrentViewModel != null;//close modal
        public void Close()
        {
            CurrentViewModel = null;
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged;
    }
}
