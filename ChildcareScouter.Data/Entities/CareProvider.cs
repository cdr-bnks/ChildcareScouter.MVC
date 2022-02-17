using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChildcareScouter.Data.Entities
{
    public class Careprovider
    {
        [Key]
        public int CareproviderID { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> ListOfEmployees { get; set; }
        public virtual ICollection<Child> ChildrenEnrolled { get; set; }


        public Careprovider()
        {
            ListOfEmployees = new HashSet<Employee>();
            ChildrenEnrolled = new HashSet<Child>();
        }

        public virtual Licensed Licensed { get; set; }

        //[Required]
        //public Guid User { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public string ProviderName { get; set; }

        [Required]
        public string ProviderTitle { get; set; }

        [Required]
        public string ContactInfo { get; set; }

        [Required]
        public bool FullTime { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
