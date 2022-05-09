using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class Bearing
    {
        public string Name { get; set; }    

        public Bearing(string Name)
        {
            this.Name = Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Bearing bearing && bearing.Name == Name;  
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public static bool operator ==(Bearing bear1, Bearing bear2)
        {
            if (bear1 is null && bear2 is null)
                return true;

            return !(bear1 is null) 
                && bear1.Equals(bear2);
        }
        public static bool operator !=(Bearing bear1, Bearing bear2)
        {
            return !(bear1 == bear2);
        }
    }
}
