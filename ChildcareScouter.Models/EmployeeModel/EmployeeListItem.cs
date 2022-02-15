using System.ComponentModel.DataAnnotations;

namespace ChildcareScouter.Models.EmployeeModel
{
    public class EmployeeListItem
    {
        [Display(Name = "Employees")]
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        [Display(Name="Gender")]
        public string IdentifyAs { get; set; }

        
        public double Salary { get; set; }


        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
    }
}
