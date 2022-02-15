using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.EmployeeModel
{
    public enum MaritalStatus
    {
        Married = 1,
        Single,
        Seperated,
        Widowed,
        Divorced,

    }
    public class EmployeeCreate
    {
        [Required]
        [MaxLength(80, ErrorMessage = "Name Needs to be 80 characters or less")]
        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =true)]
        [MaxLength(10)]
        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        [Required(AllowEmptyStrings =true)]
        [MaxLength(10)]
        public string Pronouns { get; set; }


        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        [MinLength(18, ErrorMessage ="Age has to be 18 or above")]
        [MaxLength(89, ErrorMessage ="Age has to be below 89")]
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
       
        [Required]
        [Display(Name =("Marital Status"))]
        [Range(1,5, ErrorMessage ="Please select 1-5")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}
