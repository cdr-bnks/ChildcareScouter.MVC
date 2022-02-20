using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ParentModel
{
    public class ParentCreate
    {

        [Required]
        public int CompanyID { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Name Needs to be 80 characters or less")]
        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Required]
        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ethnicity")]
        public string Race { get; set; }

        [Required]
        public string Religion { get; set; }
    }
}
