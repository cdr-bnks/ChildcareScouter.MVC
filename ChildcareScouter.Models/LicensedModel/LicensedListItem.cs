using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.LicensedModel
{
    public class LicensedListItem
    {
        [Display(Name ="Provider Name")]
        public string ProviderName { get; set; }

        [Display(Name ="Licenses")]
        public int LicensedID { get; set; }

        [Display(Name ="Name of Certificate")]
        public string CertificateName { get; set; }

        [Display(Name = "Date Acquired")]
        public DateTime DateRequired { get; set; } = DateTime.MinValue;

        [Display(Name ="Background Checks")]
        public bool BackgroundChecks { get; set; }
        public bool Inspection { get; set; }
        public bool Certified { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
