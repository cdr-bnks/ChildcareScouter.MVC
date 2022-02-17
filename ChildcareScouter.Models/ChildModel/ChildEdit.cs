using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ChildModel
{
    public class ChildEdit
    {
        public int ChildID { get; set; }

        [Display(Name = "Child's Name")]
        public string ChildName { get; set; }

        [Display(Name = "Date Of Birth", Prompt = "Please enter the Date/Month/Year your were born?")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        [Display(Name ="Child Needs")]
        public string ChildNeeds { get; set; }

        public int Age { get; set; }

        [Display(Name = "Food Allergens")]
        public FoodAllergens FoodAllergens { get; set; }
    }
}
