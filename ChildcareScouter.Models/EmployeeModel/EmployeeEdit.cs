using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.EmployeeModel
{
    public class EmployeeEdit
    {
        public int EmployeeID { get; set; }

        [MaxLength(80, ErrorMessage = "Name Needs to be 80 characters or less")]
        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [MaxLength(10)]
        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        [MaxLength(10)]
        public string Pronouns { get; set; }


        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        public string Email { get; set; }

        public double Salary { get; set; }

        [MinLength(18, ErrorMessage = "Age has to be 18 or above")]
        [MaxLength(89, ErrorMessage = "Age has to be below 89")]
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = ("Marital Status"))]
        [Range(1, 5, ErrorMessage = "Please select 1-5")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}
