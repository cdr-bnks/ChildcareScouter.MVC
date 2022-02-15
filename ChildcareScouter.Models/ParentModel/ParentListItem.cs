using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ParentModel
{
    public class ParentListItem
    {
        public int CompanyID { get; set; }

        [Display(Name ="Parents")]
        public int ParentID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }
        
        public int Age { get; set; }

        public string Email { get; set; }
    }
}
