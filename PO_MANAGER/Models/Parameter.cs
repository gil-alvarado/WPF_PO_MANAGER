using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_MANAGER.Models
{
    public class Parameter
    {
        public string Name { get; set; }

        public Parameter(string Name)
        {
            this.Name = Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Parameter parameter 
                && parameter.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
        public static bool operator ==(Parameter para1, Parameter para2)
        {
            if (para1 is null && para2 is null)
                return true;

            return !(para1 is null) && para1.Equals(para2); 
        }
        public static bool operator !=(Parameter para1, Parameter para2)
        {
            return !(para1 == para2);   
        }
    }
}
