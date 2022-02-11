using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class CareProvider
    {
        [Key]
        public int CareProviderID { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> ListOfEmployees { get; set; }
        public virtual ICollection<Child1> ChildrenEnrolled { get; set; }


        public CareProvider()
        {
            ListOfEmployees = new HashSet<Employee>();
            ChildrenEnrolled = new HashSet<Child1>();
        }

        public virtual Licensed Licensed { get; set; }


        [Required]
        public string ProviderName { get; set; }

        [Required]
        public string ProviderTitle{ get; set; }

        [Required]
        public string ContactInfo { get; set; }

        [Required]
        public  bool FullTime { get; set; }
    }
}
