using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CompanyModel
{
    public class CompanyListItem
    {
        [Display(Name = "Companies")]
        public int CompanyID { get; set; }

        [Display(Name = "Comapany Name")]
        public string CompanyName { get; set; }

        public string Location { get; set; }

        [Display(Name = "$: Price")]
        public double Price { get; set; }

        [MaxLength(1100, ErrorMessage = " 1,100 characters only ")]
        public string Policy { get; set; }

        [Display(Name ="")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
