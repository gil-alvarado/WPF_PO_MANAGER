using PO_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Stores
{
    public class AccountStore
    {
        private Account _currentAccount;

        public Account CurrentAccount
        {
            get => _currentAccount; 
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke();
            }
        }
        /*
        public AccountStore(Account currentAccount)
        {
            _currentAccount = currentAccount;   
        }
        */

        public void Logout()
        {
            CurrentAccount = null;
        }

        public AccountStore()
        {
        }
        public bool IsLoggedIn => CurrentAccount != null;
        public bool IsAdmin => CurrentAccount.Role.Equals("admin");

        public event Action CurrentAccountChanged;
    }
}
