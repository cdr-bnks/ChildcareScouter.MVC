using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
   public class Licensed
    {
        [ForeignKey(nameof(Careproviders))]
        public int LicensedID { get; set; }
      
        public virtual Careprovider Careproviders { get; set; }

        [Required]
        public Guid User { get; set; }

        //[Required]
        //public string User { get; set; }

        [Required]
        public string CertificateName { get; set; }
        
        [Required]
        public bool Certified { get; set; }
        
        [Required]
        public bool BackgroundChecks  { get; set; }
        
        [Required]
        public bool Inspection { get; set; }
        
        [Required]
        public DateTime DateRequired { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
