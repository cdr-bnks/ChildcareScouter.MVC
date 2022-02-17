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
        
        [Display(Name="Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        public string Email { get; set; }

        public double Salary { get; set; }

        [Range(18, 89, ErrorMessage ="Required age above 18")]
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }

        [Display(Name = ("Marital Status"))]
        [Range(1, 5, ErrorMessage = "Please select 1-5")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}
