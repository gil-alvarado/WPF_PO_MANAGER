using PO_MANAGER.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly AccountStore _accountStore;
        public LogoutCommand(AccountStore accountStore)
        {
            _accountStore = accountStore;   
        }
        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            _accountStore.Logout();
        }
    }
}
