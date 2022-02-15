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
        public int CompanyID { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Name Needs to be 80 characters or less")]
        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(10)]
        public string Pronouns { get; set; }
        
        [Required]
        [MaxLength(20, ErrorMessage = "Please enter only 20 characters to describe your Identity.")]
        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        [Required]
        public int Age { get; set; }


        public string Email { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
