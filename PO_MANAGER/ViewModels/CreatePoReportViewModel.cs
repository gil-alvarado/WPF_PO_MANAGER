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
    public class CreatePoReportViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; }
        public ICommand FinishCommand { get; }
        public CreatePoReportViewModel( INavigationService navigationService)
        {
            CancelCommand = new NavigateCommand(navigationService);
            FinishCommand = new NavigateCommand(navigationService);
        }
    }
}
