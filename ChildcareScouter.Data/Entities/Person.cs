using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public abstract class Person
    { 
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Required]
        public string IdentifyAs { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public string Race { get; set; }    

        [Required]
        public string Religion { get; set; }        
    }
}
