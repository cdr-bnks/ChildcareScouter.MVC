using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CareproviderModel
{
    public class CareproviderDetail
    {
        public int CareproviderID { get; set; }
        public int CompanyID { get; set; }
        
        [Display(Name ="Provider")]
        public string ProviderName { get; set; } 
        
        [Display(Name ="Title")]
        public string ProviderTitle { get; set; }
        
        [Display(Name ="Contact Info")]
        public string ContactInfo { get; set; }
        
        [Display(Name ="Full Time")]
        public bool FullTime { get; set; }

        [Display(Name ="Provider License")]
        public string Certificate { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }

    }
}
