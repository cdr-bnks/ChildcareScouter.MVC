using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public abstract class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentifyAs { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Religion { get; set; }
    }
}
