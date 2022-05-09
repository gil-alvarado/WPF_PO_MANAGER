using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using PO_MANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO_MANAGER.Commands
{
    public class AddPersonCommand : CommandBase
    {
        private readonly AddPersonViewModel _addPersonViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _closeModalNavigationService;

        public AddPersonCommand(AddPersonViewModel addPersonViewModel, 
            PeopleStore peopleStore, 
            INavigationService closeModalNavigationService)
        {
            _addPersonViewModel = addPersonViewModel;
            _peopleStore = peopleStore;
            _closeModalNavigationService = closeModalNavigationService;
        }

        public override void Execute(object? parameter)
        {
            string name = _addPersonViewModel.Name;
            _peopleStore.AddPerson(name);
          
            _closeModalNavigationService.Navigate();
        }
    }
}
