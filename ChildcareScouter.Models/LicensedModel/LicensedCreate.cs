using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.LicensedModel
{
   public class LicensedCreate
    {
        public int LicensedID { get; set; }

        public int CareproviderID { get; set; }

        [Required]
        [Display(Name = "Name of Certificate")]
        [MinLength(5, ErrorMessage = "Please eneter at least 5 charaters.")]
        [MaxLength(60, ErrorMessage = "PLease reduce the number of Characters.")]
        public string CertificateName { get; set; }

        [Required]
        [Display(Name = "Date Acquired")]
        public DateTime DateRequired { get; set; } = DateTime.MinValue;

        [Required]
        [Display(Name = "Background Checks")]
        public bool CriminalBackground { get; set; }
        
        [Required]
        public bool Inspection { get; set; }
    }
}
