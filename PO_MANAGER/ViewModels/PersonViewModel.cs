﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.ViewModels
{
    public class PersonViewModel :ViewModelBase
    {
        public string Name { get; }
        public PersonViewModel(string name)
        {
            Name = name;
        }
    }
}
