using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class Career
    {
        [Key]
        public virtual Staff StaffID { get; set; }

        public virtual ICollection<Staff> ListOfStaffs { get; set; } = new List<Staff>();

        
        [Key]
        public virtual Provider ProviderID { get; set; }

        public virtual ICollection<Provider> ListOfProviders { get; set; } = new List<Provider>();

        [Key]
        public virtual Program ProgramID { get; set; }
        public virtual ICollection<Program> ListOfPrograms { get; set; } = new List<Program>();

        public Career()
        {
            ListOfStaffs = new HashSet<Staff>();
            ListOfProviders = new HashSet<Provider>();
            ListOfPrograms = new HashSet<Program>();
        }

        public DateTime StartDate { get; set; }

        public string Postion { get; set; }
    }
}
