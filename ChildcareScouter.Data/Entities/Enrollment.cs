using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class Enrollment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime EnrolledDate { get; set; }

        [ForeignKey(nameof(Program))]
        public virtual ICollection<Program> ListOfPrograms { get; set; } = new List<Program>();

        [ForeignKey(nameof(Child))]
        public virtual ICollection<Child> ListOfChildren { get; set; } = new List<Child>();
       
        public Enrollment()
        {
            ListOfPrograms = new HashSet<Program>();
            ListOfChildren = new HashSet<Child>();
        }

    }
}
