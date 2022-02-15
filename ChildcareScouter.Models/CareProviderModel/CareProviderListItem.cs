using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CareproviderModel
{
    public class CareproviderListItem
    {
        public int CompanyID { get; set; }

        [Display(Name ="Providers")]
        public int CareproviderID { get; set; }

        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }

        [Display(Name = "Provider Title")]
        public string ProviderTitle { get; set; }

        [Display(Name = "Contact Info")]
        public string ContactInfo { get; set; }
    }
}
