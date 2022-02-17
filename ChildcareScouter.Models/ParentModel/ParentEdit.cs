using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ParentModel
{
    public class ParentEdit
    {
        public int CompanyID { get; set; }
        public int ParentID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [Display(Name="Phone Number")]
        public double PhoneNumber { get; set; }
    }
}
