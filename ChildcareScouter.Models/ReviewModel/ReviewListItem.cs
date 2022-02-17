using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ReviewModel
{
    public class ReviewListItem
    {
        public int CarproviderID { get; set; }

        [Display(Name = "Reviews:")]
        public int ReviewID { get; set; }

        public string Report { get; set; }
        
        public string Description { get; set; }
       
        public int Score { get; set; }

        [Display(Name = "Recommended")]
        public bool IsRecommended { get; set; }

        [Display(Name = "Recommended")]
        public bool IsReported { get; set; }

        [Display(Name = "Careprovider Name")]
        public string ProviderName { get; set; }

        [Display(Name ="Certificate")]
        public string CertificateName { get; set; }

        [Display(Name = "Certified")]
        public bool IsCertified { get; set; }

        [Display(Name ="")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
