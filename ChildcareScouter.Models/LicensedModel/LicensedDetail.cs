using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.LicensedModel
{
    public class LicensedDetail
    {
        [Display(Name ="Provider Name")]
        public string ProviderName { get; set; }
        [Display(Name = "License #")]
        public int LicensedID { get; set; }

        [Display(Name = "Name of Certificate")]
        public string CertificateName { get; set; }

        [Display(Name = "Date Acquired")]
        public DateTime DateRequired { get; set; } = DateTime.MinValue;

        [Display(Name = "Background Checks")]
        public bool CriminalBackground { get; set; }
        public bool Inspection { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
