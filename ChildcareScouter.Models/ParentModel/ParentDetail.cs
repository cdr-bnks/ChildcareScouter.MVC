using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ParentModel
{
     public class ParentDetail
    {
        public int CompanyID { get; set; }
       
        [Display(Name = "Parent #")]
        public int ParentID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }
        
        public string Email { get; set; }

        public int Age { get; set; }

        public double PhoneNumber { get; set; }

        [Display(Name = "")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
