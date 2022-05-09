using PO_MANAGER.NavigationService;
using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public CloseModalNavigationService(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public void Navigate()
        {
            _modalNavigationStore.Close();
        }
    }
}
