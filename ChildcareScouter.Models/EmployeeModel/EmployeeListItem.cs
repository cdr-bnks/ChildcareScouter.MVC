using System.ComponentModel.DataAnnotations;
using System;

namespace ChildcareScouter.Models.EmployeeModel
{
    public class EmployeeListItem
    {
        [Display(Name = "Employees")]
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }

        public string Email { get; set; }

        public double Salary { get; set; }

        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }

        [Display(Name = ("Marital Status"))]
        [Range(1, 5, ErrorMessage = "Please select 1-5")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = ("Number of Postions"))]
        public int ListOfPositions { get; set; }

        [Display(Name ="")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
