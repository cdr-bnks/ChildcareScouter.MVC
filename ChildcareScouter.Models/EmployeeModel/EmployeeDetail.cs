using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.EmployeeModel
{
    public class EmployeeDetail
    {
        [Display(Name = "Employee #")]
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Gender")]
        public string IdentifyAs { get; set; }


        public double Salary { get; set; }


        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
