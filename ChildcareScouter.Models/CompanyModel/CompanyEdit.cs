using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CompanyModel
{
    public class CompanyEdit
    {
        public int CompanyID { get; set; }

        [Display(Name = "Comapany Name")]
        public string CompanyName { get; set; }

        public string Location { get; set; }

        [Display(Name = "$: Price")]
        public double Price { get; set; }
    }
}
