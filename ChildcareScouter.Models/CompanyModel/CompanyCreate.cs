using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CompanyModel
{
   public class CompanyCreate
    {
        [Required]
        [Display(Name = "Comapany Name")]
        [MaxLength(30, ErrorMessage = "Please enter only 30 characters")]
        public string CompanyName { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage ="Please enter only 100 characters")]
        public string Location { get; set; }

        
        [Display(Name = "$: Price")]
        public double Price { get; set; }
    }
}
