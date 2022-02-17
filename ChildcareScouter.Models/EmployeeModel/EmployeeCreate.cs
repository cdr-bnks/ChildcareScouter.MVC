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

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Required]
        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        [Range (18,89, ErrorMessage ="Please select age between 18 and above")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }
       
        [Required]
        [Display(Name =("Marital Status"))]
        [Range(1,5, ErrorMessage ="Please select 1-5")]
        public MaritalStatus MaritalStatus { get; set; }
    }
}
