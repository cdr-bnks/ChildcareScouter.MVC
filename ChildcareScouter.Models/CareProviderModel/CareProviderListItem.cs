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
        public int CareproviderID { get; set; }
        public int CompanyID { get; set; }

        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }

        [Display(Name = "Provider Title")]
        public string ProviderTitle { get; set; }

        [Display(Name = "Contact Info")]
        public string ContactInfo { get; set; }

        [Display(Name ="Children Enrolled")]
        public int ChildrenEnrolled { get; set; }

        [Display(Name ="Employee No")]
        public int Staff { get; set; }

        [Display(Name ="Full Time")]
        public bool FullTIme { get; set; }

        [Display(Name ="")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
