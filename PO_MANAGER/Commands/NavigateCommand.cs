using PO_MANAGER.NavigationService;
using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Commands
{
    public class NavigateCommand: CommandBase 
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
