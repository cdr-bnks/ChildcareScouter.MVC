using System;
using System.ComponentModel.DataAnnotations;

namespace ChildcareScouter.Models.ChildModel
{
    public class ChildListItem
    {
        public int ParentID { get; set; }

        [Display(Name = "Children")]
        public int ChildID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Food Allergens")]
        public FoodAllergens FoodAllergens { get; set; }
    }
}
