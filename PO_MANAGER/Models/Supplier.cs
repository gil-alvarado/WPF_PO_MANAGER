using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class Supplier
    {
        public string Name { get; set; }    

        public Supplier(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Supplier supplier 
                && supplier.Name == Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public static bool operator ==(Supplier sup1, Supplier sup2)
        {
            if (sup1 is null && sup2 is null)
                return true;

            return !(sup1 is null) && sup1.Equals(sup2);
        }
        public static bool operator !=(Supplier sup1, Supplier sup2)
        {
            return !(sup1 == sup2); 
        }
    }
}
