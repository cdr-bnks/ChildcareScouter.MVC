using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.CareproviderModel
{
    public class CareproviderCreate
    {
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at Least 2 characters.")]
        [MaxLength(20, ErrorMessage = "Please reduce the number of characters")]
        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please eneter at least 5 charaters.")]
        [MaxLength(40, ErrorMessage = "PLease reduce the number of Characters.")]
        [Display(Name = "Provider Title")]
        public string ProviderTitle { get; set; }

        [Required]
        [MaxLength(90)]
        [MinLength(3, ErrorMessage = "Please provide add more characters to your contact Info")]
        [Display(Name = "Contact Info")]
        public string ContactInfo { get; set; }

        [Required]
        [Display(Name = "Full Time")]
        public bool FullTime { get; set; }
    }
}
