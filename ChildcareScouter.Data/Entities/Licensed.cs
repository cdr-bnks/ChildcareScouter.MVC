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
        [ForeignKey(nameof(Careprovider))]
        public int LicensedID { get; set; }
      
        public virtual Careprovider Careprovider { get; set; }

        //[ForeignKey(nameof(User))]
        //public string OwnerID { get; set; }
        //public virtual ApplicationUser User { get; set; }


        //[Required]
        //[Column(TypeName = "OwnerID")]
        //public Guid OwnerID { get; set; }

        [Required]
        public string CertificateName { get; set; }
        
        [Required]
        public bool Certified { get; set; }
        
        [Required]
        public bool BackgroundChecks  { get; set; }
        
        [Required]
        public bool Inspection { get; set; }

        [Required]
        public DateTime DateRequired { get; set; } = DateTime.MinValue;

        [Required]
        public bool CPRTraining { get; set; }

        [Required]
            public int ChildNumber { get; set; }

        [Required]
        public bool StateRegistered { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
